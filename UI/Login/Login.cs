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
    /// The first window to appear on the program's startup and the class that handles logging in to the progrmam.
    /// </summary>
    public partial class 
        Login : Form
    {
        private DatabaseHandler db;
        private int attempts;

        /// <summary>
        /// Initializes a new instance of the Login class(the Login window). 
        /// </summary>
        /// <remarks>
        /// Sets the base values and window settings, and attempts to aquire the reference to the DatabaseHandler object.
        /// </remarks>
        /// <exception cref="MySqlException">Thrown when the database is unreachable.</exception>
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.lbWarning.ForeColor = Color.Red;
            this.MaximizeBox = false;
            try {
                db = DatabaseHandler.Instance;
            } catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolódni az adatbázishoz.\nEllenőrizze az adatbázis kapcsolatot és próbálja újra.");
            }
            attempts = 0;
        }



        private void Logging_In() 
        {
            try {
                User un = db.Login(tbUsername.Text, tbPassword.Text);
                if (un != null) {
                    LoggedInUser.loggedinuser = un;
                    attempts = 0;
                    Menu mainMenu = new Menu();
                    mainMenu.Tag = this;
                    this.Hide();
                    mainMenu.Show();
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                } else {
                    attempts++;
                    lbWarning.Text = "Helytelen felhasználónév vagy jelszó.";
                    if (attempts % 5 == 0)
                        lbWarning.Text = "Lehetséges, hogy a fiókodat deaktiválták. Lépj kapcsolatba az adminisztrátorral";
                }
            }
            catch (MySqlException e) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
                MessageBox.Show(e.Message);
            }

        }

        

        private void btnLogin_Click(object sender, EventArgs e) {
            lbWarning.Text = "";
            Logging_In();
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration Formregister = new Registration();
            Formregister.Tag = this;
            this.Hide();
            Formregister.Show();
        }


        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbWarning.Text = "";
                Logging_In();
            }
        }

        private void ForgottenPWD_Click(object sender, EventArgs e)
        {
            Password_Reset pwr = new Password_Reset();
            pwr.Tag = this;
            this.Hide();
            pwr.Show();
        }
    }
}
