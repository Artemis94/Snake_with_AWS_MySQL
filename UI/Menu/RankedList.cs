using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Snake_with_AWS_MySQL
{
    /// <summary>
    /// This is the Ranked List window, the user can compare their best games to other players best games in each game mode.
    /// </summary>
    public partial class RankedList : Form
    {
        private DatabaseHandler db;

        /// <summary>
        /// Initializes a new instance of the RankedList class(the Ranked List window). 
        /// </summary>
        /// <remarks>
        /// Sets the base values and window settings and attempts to aquire the reference to the DatabaseHandler object.
        /// </remarks>
        public RankedList()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            db = DatabaseHandler.Instance;
            gamesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesDGV.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Using the appropriate method of the DatabaseHandler class, the data of the highest point game for each player who has played at the
        /// selected difficulty are loaded into the DataGridView, with the current user's game selected if they have one. 
        /// </summary>
        /// <param name="difficulty">An Integer number.</param>
        /// <exception cref="MySqlException">Thrown when the database is unreachable.</exception>
        private void LoadGames(int difficulty) {
            try {
                List<string> games = db.LoadGamesRanked(difficulty);
                if (games == null)
                    MessageBox.Show("Nincs megjeleníthető adat, a megadott nehézségi kategóriában.");
                else {
                    for (int i = 0; i < games.Count; i++) {
                        string[] s = games[i].Split('#');

                        gamesDGV.Rows.Add();
                        gamesDGV.Rows[i].Cells["rank"].Value = i + 1;
                        gamesDGV.Rows[i].Cells["user"].Value = s[1];
                        gamesDGV.Rows[i].Cells["points"].Value = s[3];
                        gamesDGV.Rows[i].Cells["time"].Value = s[2];

                        if (int.Parse(s[0]) == LoggedInUser.loggedinuser.Id) {
                            gamesDGV.Rows[i].Selected = true;
                        } else
                            gamesDGV.Rows[i].Selected = false;

                    }
                }
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }

        private void diff1_CheckedChanged(object sender, EventArgs e)
        {
            gamesDGV.Rows.Clear();
            gamesDGV.ClearSelection();
            LoadGames(1);

        }


 
        private void diff2_CheckedChanged(object sender, EventArgs e)
        {
            gamesDGV.Rows.Clear();
            gamesDGV.ClearSelection();
            LoadGames(2);
        }


 
        private void diff3_CheckedChanged(object sender, EventArgs e)
        {
            gamesDGV.Rows.Clear();
            gamesDGV.ClearSelection();
            LoadGames(3);
        }



        private void diff4_CheckedChanged(object sender, EventArgs e) {
            gamesDGV.Rows.Clear();
            gamesDGV.ClearSelection();
            LoadGames(4);
        }

 
        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }


        private void RankedList_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }
    
    }
}
