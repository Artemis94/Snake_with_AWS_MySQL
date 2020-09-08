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
    /// The Registration window, the class that handles registering to the progrmam.
    /// </summary>
    public partial class Registration : Form {


        private DatabaseHandler db;

        /// <summary>
        /// Initializes a new instance of the Registration class(the Registration window).
        /// </summary>
        /// <remarks>
        /// Sets the base values and window settings, and attempts to aquire the reference to the DatabaseHandler object.
        /// </remarks>
        public Registration() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            lbWarning.ForeColor = Color.Red;
            db = DatabaseHandler.Instance;
        }



        private void btnRegister_Click(object sender, EventArgs e) {
            try {
                if (tbUsername.Text != "" && tbEmail.Text != "" && tbFullname.Text != "" && tbPassword.Text != "" && tbPasswordSecond.Text != "") {
                    if (tbPassword.Text.Length > 3) {
                        if (tbPassword.Text == tbPasswordSecond.Text) {
                            if (tbFullname.Text.Split(' ').Length > 1) {
                                if (tbEmail.Text.Contains("@") && tbEmail.Text.Contains(".")) {
                                    bool successful = db.InsertUser(tbUsername.Text, tbEmail.Text, PasswordHash.Hash(tbPassword.Text), tbFullname.Text, dpBirth.Value);
                                    if (successful)
                                    {
                                        MessageBox.Show("Sikeres regisztráció! :) ");
                                        this.Close();
                                        (Tag as Form).Show();
                                    }
                                    else
                                    {
                                        lbWarning.Text = "Már létezik ilyen felhasználónév vagy az email cím már használatban van.";
                                    }                                    
                                } else
                                    lbWarning.Text = "Helytelen e-mail cím.";
                            } else {
                                lbWarning.Text = "Kérem adja meg a teljes nevét.";
                            }
                        } else {
                            lbWarning.Text = "A két jelszó nem egyezik.";
                        }
                    } else {
                        lbWarning.Text = "A jelszó legyen minimum 4 karakter hosszúságú.";
                    }
                } else {
                    lbWarning.Text = "Minden mezőt kötelező kitölteni.";
                }

            } 
            catch (MySqlException) {
                MessageBox.Show("Kapcsolódási hiba. Kérem ellenőrizze az adatbáziskiszolgálót és próbálja újra.");
            }

        }


        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }


        private void Regisztration_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }
    }
}
