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
    /// This is the Previous Games window, here the user can review all their past games.
    /// </summary>
    public partial class PreviousGames : Form
    {
        private DatabaseHandler db;
        
        /// <summary>
        /// Initializes a new instance of the PreviousGames class(the Previous Games window). 
        /// </summary>
        /// <remarks>sets the base values and window settings, 
        /// Attempts to aquire the reference to the DatabaseHandler object and loads the information of all past games belonging to the current user to 
        /// the window.
        /// </remarks>
        /// <exception cref="MySqlException">Thrown when the database is unreachable.</exception>
        public PreviousGames()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            db = DatabaseHandler.Instance;
            gamesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesDGV.AllowUserToAddRows = false;
            
            dataLoad();
        }


        private void dataLoad() {
            try {
                List<GameObject> games = db.LoadGames();

                if (games != null) {
                    for (int i = 0; i < games.Count; i++) {
                        gamesDGV.Rows.Add();
                        gamesDGV.Rows[i].Cells["time"].Value = games[i].Time;
                        gamesDGV.Rows[i].Cells["points"].Value = games[i].Points;
                        string diffi = "";
                        switch (games[i].Difficulty) {
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

                        gamesDGV.Rows[i].Cells["difficulty"].Value = diffi;
                    }
                }
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.\nA program most kilép.");
                Application.Exit();
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void PreviousGames_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }

    }
}
