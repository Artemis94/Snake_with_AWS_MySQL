using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{
    class Snake
    {
        private SnakeElement snakeHead;
        private List<SnakeElement> body;
        private SnakeElement snakeTail;
        private SnakeElement behindTheTail;

        private bool growing;

        /// <summary>
        /// The Snake's head.
        /// </summary>
        public SnakeElement SnakeHead { get => snakeHead; set => snakeHead = value; }

        /// <summary>
        /// The Snake's body.
        /// </summary>
        public List<SnakeElement> Body { get => body; set => body = value; }

        /// <summary>
        /// The Snake's tail.
        /// </summary>
        public SnakeElement SnakeTail { get => snakeTail; set => snakeTail = value; }

        /// <summary>
        /// The position behind the Snake's tail.
        /// </summary>
        public SnakeElement BehindTheTail { get => behindTheTail; set => behindTheTail = value; }



        private List<Image> heads;
        private List<Image> tails;
        private List<Image> turns;
        private List<Image> middles;

        /// <summary>
        /// Gets the snake's current length.
        /// </summary>
        public int Snakelength { get { return body.Count + 2; } }

        /// <summary>
        /// Gets or sets whether or not the snake is growing at the moment.
        /// </summary>
        public bool Growing { get => growing; set => growing = value; }

        /// <summary>
        /// Initializes a new instance of the Snake class. 
        /// </summary>
        /// <param name="h">An integer array, the head's starting coordinates.</param>
        /// <param name="m">An integer array, the middle's starting coordinates.</param>
        /// <param name="t">An integer array, the tail's starting coordinates.</param>
        public Snake(int[] h, int[] m, int[] t)
        {
            ImageLoad();


            body = new List<SnakeElement>();

            snakeHead = new SnakeElement(h[0], h[1], heads[0], 1);
            body.Add(new SnakeElement(m[0], m[1], middles[0], 1));
            snakeTail = new SnakeElement(t[0], t[1], tails[0], 1);

            behindTheTail= new SnakeElement(t[0]-1, t[1], null, 1);

            growing = false;
        }

        /// <summary>
        /// Loads the images required for the snake's appearence.
        /// </summary>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when an image is not found.</exception>
        private void ImageLoad()
        {
            try
            {
                heads = new List<Image>();
                tails = new List<Image>();
                turns = new List<Image>();
                middles = new List<Image>();
                Image h = Image.FromFile("..\\..\\Images\\Snake_head.png");
                heads.Add(new Bitmap(h));
                Image t = Image.FromFile("..\\..\\Images\\Snake_tail.png");
                tails.Add(new Bitmap(t));
                Image turn = Image.FromFile("..\\..\\Images\\Snake_turning.png");
                turns.Add(new Bitmap(turn));
                Image m = Image.FromFile("..\\..\\Images\\Snake_middle.png");
                middles.Add(new Bitmap(m));
                m.RotateFlip(RotateFlipType.Rotate90FlipNone);
                middles.Add(new Bitmap(m));

                for (int i = 1; i <= 3; i++)
                {

                    heads.Add(new Bitmap((Image)heads[i - 1]));
                    heads[i].RotateFlip(RotateFlipType.Rotate90FlipNone);


                    tails.Add(new Bitmap((Image)tails[i - 1].Clone()));
                    tails[i].RotateFlip(RotateFlipType.Rotate90FlipNone);


                    turns.Add(new Bitmap((Image)turns[i - 1].Clone()));
                    turns[i].RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("A játék futásához szükséges egy vagy több kép nem található.");
            }
        }


        private void Turning()
        {
            if (snakeHead.Direction != body[0].Direction)
            {
                snakeHead.Img = heads[snakeHead.Direction - 1];



                switch (body[0].Direction)
                {
                    case 1:                         //Was going east. 
                        switch (snakeHead.Direction)
                        {
                            case 2:                 //now going south.
                                body[0].Img = turns[0];
                                break;
                            case 4:                 //now going north.
                                body[0].Img= turns[1]; 
                                break;
                        }
                        break;
                    case 2:                     //was going south
                        switch (snakeHead.Direction)
                        {
                            case 1:             //now going east
                                body[0].Img = turns[2];
                                break;
                            case 3:             //now going west
                                body[0].Img = turns[1];
                                break;
                        }
                        break;
                    case 3:                     //was going west
                        switch (snakeHead.Direction)
                        {
                            case 2:             //now going south
                                body[0].Img = turns[3];
                                break;
                            case 4:             //now going north
                                body[0].Img = turns[2];
                                break;
                        }
                        break;
                    case 4:                     //was going north
                        switch (snakeHead.Direction)
                        {
                            case 1:             //now going east
                                body[0].Img = turns[3];
                                break;
                            case 3:             //now going west
                                body[0].Img = turns[0];
                                break;
                        }
                        break;
                }
            }
            else
            {
                if (body[0].Direction == 1 || body[0].Direction == 3)
                {
                    body[0].Img = middles[0];
                }
                else
                    body[0].Img = middles[1];

            }

            
             snakeTail.Img = tails[snakeTail.Direction-1];     
        }

        /// <summary>
        /// Determines whether or not the snake has collided with itself.
        /// </summary>
        /// <returns>True if the snake has collided with itself, otherwise false.</returns>
        public bool YouHitYourself()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[i].X == snakeHead.X && body[i].Y == snakeHead.Y)
                    return true;
            }

            if (snakeTail.X == snakeHead.X && snakeTail.Y == snakeHead.Y)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determins whether or not the coordinates received are inside the snake.
        /// </summary>
        /// <param name="x">Integer number.</param>
        /// <param name="y">Integer number.</param>
        /// <returns>True if the coordinates are whithin the snake, otherwise false.</returns>
        public bool ContainsPosition(int x, int y)
        {
            int n = 0;
            while (n < body.Count && body[n].X != x && body[n].Y != y)
                n++;

            if (n < body.Count || (snakeTail.X == x  && snakeTail.Y == y || snakeHead.X==x && snakeHead.Y==y))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Makes the snake move one position forward.
        /// </summary>
        public void Move()
        {
            if (!growing)
            {
                behindTheTail.X = snakeTail.X;
                behindTheTail.Y = snakeTail.Y;
                behindTheTail.Direction = snakeTail.Direction;

                snakeTail.X = body[body.Count - 1].X;
                snakeTail.Y = body[body.Count - 1].Y;
                snakeTail.Direction = body[body.Count - 1].Direction;

                if (body.Count > 1)
                {
                    for (int i = body.Count - 1; i > 0; i--)
                    {
                        body[i].X = body[i - 1].X;
                        body[i].Y = body[i - 1].Y;
                        body[i].Direction = body[i - 1].Direction;
                    }
                }

                body[0].X = snakeHead.X;
                body[0].Y = snakeHead.Y;
            }
            else
            {
                body.Insert(0, new SnakeElement(SnakeHead.X, snakeHead.Y, middles[0], body[0].Direction));
            }


            switch (snakeHead.Direction)
            {
                case 1:         //heading east
                    snakeHead.Y++;
                    break;
                case 2:         //heading south
                    snakeHead.X++;
                    break;
                case 3:         //heading west
                    snakeHead.Y--;
                    break;
                case 4:         //heading north
                    snakeHead.X--;
                    break;
            }

            Turning();

            body[0].Direction = snakeHead.Direction;
        }



    }
}
