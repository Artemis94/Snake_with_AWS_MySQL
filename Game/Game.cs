using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using MySqlConnector;

namespace Snake_with_AWS_MySQL
{

    /// <summary>
    /// This is the Game window, the user can play the game here.
    /// </summary>
    public partial class Game : Form 
    {
        private DatabaseHandler db;
        private int tileRows = 30;
        private int tileCols = 45;
        private PictureBox[,] Tiles;
        private Snake henry;
        private Bite snakeBite;
        private static Random r = new Random();

        private Image tileImage;
        private List<Image> Bites=new List<Image>();
        private GameObject currentGame;
        private bool ticked;
        private int interval;
        private List<Bite> mushrooms;
        private Image mushroomImage;
        private int lastPointsEarned;
        private int pointsMultiplier;

        /// <summary>
        /// Initializes a new Instance of the Game calss(the Game window). 
        /// </summary>
        public Game()
        {
           InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            db = DatabaseHandler.Instance;
             mushrooms = new List<Bite>();

            interval = 200;
            timer.Interval = interval;
            this.BackColor = Color.Beige;
            ImageLoad();
            Tiles = new PictureBox[tileRows, tileCols];
            InitializeField();
            henry = new Snake(new int[] {tileRows/2,(tileCols/2)+1 }, new int[] { tileRows / 2, 
                (tileCols / 2) }, new int[] { tileRows / 2, (tileCols / 2) - 1 });

            this.snakeBite = NewBite();

            currentGame = new GameObject(0, DateTime.Now, 4, 0);
            lbGameState.Text = "A játék indításához momj meg egy billentyűt.";
            ticked = true;
            lastPointsEarned = 0;
            pointsMultiplier = 1;


            DrawBite(snakeBite);            

            InitializeSnake();  

            this.Show();
            this.KeyDown += GameStart;
        }

        /// <summary>
        /// Sets the games's speed, based on the set defficulty.
        /// </summary>
        private void SetDifficulty()
        {
            switch (LoggedInUser.loggedinuser.Game_difficulty)
            {
                case 1:
                    if (interval > 10)
                        interval =interval -14;
                    else if (interval>2)
                        interval = interval - 1;
                    break;
                case 2:
                    if (interval > 10)
                        interval = interval - 9;
                    else if (interval > 2)
                        interval = interval - 1;
                    break;
                case 3:
                    interval = 120;
                    break;
                case 4:
                    if (interval > 10)
                        interval = interval - 9;
                    else if (interval > 2)
                        interval = interval - 1;
                    break;
            }
            timer.Interval = interval;
        }

        /// <summary>
        /// Loads the images required for the game's user interface.
        /// </summary>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when an image is not found.</exception>
        private void ImageLoad()
        {
            try
            {
                tileImage = Image.FromFile("..\\..\\Images\\tile1.bmp");
                for (int i = 1; i < 4; i++)
                {
                    Bites.Add(new Bitmap("..\\..\\Images\\bite" + i + ".png"));
                }
                mushroomImage = new Bitmap("..\\..\\Images\\mushroom.png");
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("A játék futásához szükséges egy vagy több kép nem található.");
            }
        }

        /// <summary>
        /// Initializes the game field.
        /// </summary>
        private void InitializeField()
        {
            for (int row = 0; row < tileRows; row++)
            {
                for (int col = 0; col < tileCols; col++)
                {
                    PictureBox p = new PictureBox();

                    p.SetBounds(col * 20, row * 20, 20, 20);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.BackColor = Color.Beige;
                    this.Controls.Add(p);

                    Tiles[row, col] = p;
                    Tiles[row, col].BackColor = Color.Bisque;
                    if ((row == 0 || col == 0) || (row == tileRows - 1 || col == tileCols - 1))
                    {
                        p.Image = tileImage;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the snake in it's starting pozition.
        /// </summary>
        private void InitializeSnake()
        {
            int x = tileRows / 2;
            int y = tileCols / 2;                    

            Tiles[henry.SnakeTail.X, henry.SnakeTail.Y].Image = henry.SnakeTail.Img;
            Tiles[henry.Body[0].X, henry.Body[0].Y].Image = henry.Body[0].Img;
            Tiles[henry.SnakeHead.X, henry.SnakeHead.Y].Image = henry.SnakeHead.Img;
        }


        /// <summary>
        /// Randomly generates coordinates for an empty space on the field.
        /// </summary>
        /// <returns>An integer array with 2 elemnts.</returns>
        private int[] BiteCoordinates()
        {
            int x;
            int y;
            bool notOk;
            do
            {
                x = r.Next(1, tileRows - 1);
                y = r.Next(1, tileCols - 1);
                notOk = false;
                if (henry.ContainsPosition(x, y))
                    notOk = true;
                if (mushroomsContansPosition(x, y)!=-1)
                    notOk = true;
                if (snakeBite!=null)
                    if (snakeBite.X == x && snakeBite.Y == y)
                        notOk = true;
                
            } while (notOk);
            return new int[] { x, y };
        }



        private Bite NewBite()
        {
            int[] coordinates = BiteCoordinates();
            int type= r.Next(0, 3);
            return new Bite(coordinates[0], coordinates[1], Bites[type], 10, (BiteTypes)type);
        }

        /// <summary>
        /// Determines if there is a mushroom on the given coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>-1 if there is no mushroom on the given position, otherwise an integer number.</returns>
        private int mushroomsContansPosition(int x, int y) {
            for (int i = 0; i < mushrooms.Count; i++) {
                if (mushrooms[i].X == x && mushrooms[i].Y == y)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Makes the necessary steps when the snake eats, makes the snake grow, calculates points, and places a 
        /// new Bite on the field. (And mushrooms if necessary)
        /// </summary>
        private void CollisionBite()
        {
            if(henry.SnakeHead.X==snakeBite.X && henry.SnakeHead.Y== snakeBite.Y) {
                int bitepoints = 10*pointsMultiplier;

                lastPointsEarned = bitepoints;
                currentGame.Points += lastPointsEarned;
                henry.Growing=true;


                this.snakeBite = NewBite();
                DrawBite(snakeBite);

                if (currentGame.Difficulty==4) {
                    int mushroompoints = -10;
                    int mc = mushrooms.Count;
                    for (int i = 0; i < 5; i++) {
                        int[] xy = BiteCoordinates();
                        mushrooms.Add(new Bite(xy[0], xy[1], mushroomImage, mushroompoints, BiteTypes.Mushroom));
                        DrawBite(mushrooms[mc+i]);
                    }
                    if (henry.Snakelength % 6 == 0)
                        pointsMultiplier++;
                }
                
                SetDifficulty();
            }

        }


        private void CollisionMushroom() {
            int collided = mushroomsContansPosition(henry.SnakeHead.X, henry.SnakeHead.Y);
            if (collided!=-1) {
                currentGame.Points += mushrooms[collided].Points;
                lastPointsEarned= mushrooms[collided].Points;
                mushrooms.Remove(mushrooms[collided]);
            }
        }

        private void CollisionSelf()
        {
            if (henry.YouHitYourself())
            {
                GameOver(2);
            }
        }

        private void CollisionWall()
        {
                if (henry.SnakeHead.X == 0 || henry.SnakeHead.Y == 0
                    || henry.SnakeHead.X == tileRows - 1 || henry.SnakeHead.Y == tileCols - 1)
                {
                    Tiles[henry.SnakeHead.X, henry.SnakeHead.Y].BackColor = Color.Red;
                    GameOver(3);
                }
        }


        private void DrawBite(Bite m) {
            Tiles[m.X, m.Y].Image = m.Img;
        }


        private void DrawSnake()
        {
            Tiles[henry.SnakeHead.X, henry.SnakeHead.Y].Image = henry.SnakeHead.Img;


            Tiles[henry.Body[0].X, henry.Body[0].Y].Image = henry.Body[0].Img;

            if (!henry.Growing)
            {
                Tiles[henry.SnakeTail.X, henry.SnakeTail.Y].Image = henry.SnakeTail.Img;
                Tiles[henry.BehindTheTail.X, henry.BehindTheTail.Y].Image = null;
            }
            else
            {
                henry.Growing = false;
            }

        }


        private void gameCycle(object sender, EventArgs e)
        {
            henry.Move();

            GameStateWrite();

            DrawSnake();
            CollisionSelf();
            CollisionWall();
            CollisionMushroom();
            CollisionBite();
            ticked = true;
        }

        private void GameStateWrite() {
            string diffi = "";
            switch (currentGame.Difficulty) {
                case 1:
                    diffi = "SzáguldozóSziszegő";
                    break;
                case 2:
                    diffi = "Gyorsuló";
                    break;
                case 3:
                    diffi = "Állandó";
                    break;
                case 4:
                    diffi = "Gombák!";
                    break;
            }
            lbGameState.Text = "Kígyóhossz: " + henry.Snakelength + "     Pontok: " + currentGame.Points + "     Játékmód: " + diffi + "     Utolsó pont: " + lastPointsEarned;
        }


        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (ticked)
            {
                ticked = false;
                switch (e.KeyCode)
                {
                    case Keys.Right:
                    case Keys.D:
                        if (henry.SnakeHead.Direction != 3)
                            henry.SnakeHead.Direction = 1;
                        break;
                    case Keys.Down:
                    case Keys.S:
                        if (henry.SnakeHead.Direction != 4)
                            henry.SnakeHead.Direction = 2;
                        break;
                    case Keys.Left:
                    case Keys.A:
                        if (henry.SnakeHead.Direction != 1)
                            henry.SnakeHead.Direction = 3;
                        break;
                    case Keys.Up:
                    case Keys.W:
                        if (henry.SnakeHead.Direction != 2)
                            henry.SnakeHead.Direction = 4;
                        break;
                    case Keys.Escape:
                        timer.Enabled = false;
                        GameOver(4);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Starts the game, when a key is pressed on the keyboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStart(object sender, KeyEventArgs e)
        {
            this.KeyDown -= GameStart;

            lbGameState.Text = "Kígyóhossz: " + henry.Snakelength + "     Pontok: " + currentGame.Points + "     Játékmód: " + LoggedInUser.loggedinuser.Game_difficulty;

            this.KeyDown += KeyDownHandler;
            timer.Tick += gameCycle;
            timer.Enabled = true;
        }
               


        private void GameOver(int reason)
        {
            timer.Enabled = false;
            string message="";
            switch (reason)
            {
                case 1:
                    message = "Falnak Ütköztél.\nGAME OVER";
                    break;
                case 2:
                    message = "A kígyód beleütközött önmagába.\nGAME OVER";
                    break;
                case 3:
                    message = "Falnak Ütküztél\nGAME OVER";
                    break;
                case 4:
                    message = "Leállítottad a játékot.\nGAME OVER";
                    break;
            }

            message += "\n\nSzerzett Pontok: " + this.currentGame.Points + "\nKígyóhossz: " + henry.Snakelength + "\n\nSzeretnéd elmenteni a játékot?";

            DialogResult d = MessageBox.Show(message, "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (d == DialogResult.Yes)
                {
                    if (db.SaveGame(currentGame))
                    {
                        MessageBox.Show("Sikeres mentés.");
                    }
                    else
                        MessageBox.Show("Nem sikerült a mentés.");
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }


            this.Close();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }

    }
}
