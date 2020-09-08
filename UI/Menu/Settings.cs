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
    /// The Settings window. Here the User can alter their settings.
    /// </summary>
    public partial class Settings : Form
    {
        private DatabaseHandler db;

        /// <summary>
        /// Initialises a new instance of the Settings class(the Settings window).
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            db = DatabaseHandler.Instance;
            difficultyPNL.BackColor = Color.FromArgb(90, Color.Black);
            passwordPNL.BackColor = Color.FromArgb(90, Color.Black);
            dataPNL.BackColor = Color.FromArgb(90, Color.Black);
            this.ForeColor = Color.White;
            btnBack.ForeColor = Color.Black;
            btnPWsend.ForeColor = Color.Black;
            btnModify.ForeColor = Color.Black;
            btnNewPasswordSend.ForeColor = Color.Black;
            btnChangePasswordSend.ForeColor = Color.Black;
            diff_1.Checked = false;
            diff_2.Checked = false;
            diff_3.Checked = false;
            diff_4.Checked = false;
            lbWarning.Text = "";
            lbWarning.ForeColor = Color.Red;
            lbWarningUserPWD.Text = "";
            lbWarningUserPWD.ForeColor = Color.Red;
            lbNotMachingPasswords.Text = "";
            lbNotMachingPasswords.ForeColor = Color.Red;
            tbDifficulty.ReadOnly = true;

            onLoad();
        }

        
        private void onLoad()
        { 
            switch (LoggedInUser.loggedinuser.Game_difficulty)
            {
                case 1:
                    diff_1.Checked = true;
                    tbDifficulty.Text = "A kígyó sebessége nagyobb ütemben, arányosan növekszik a hosszával.";
                    break;
                case 2:
                    diff_2.Checked = true;
                    tbDifficulty.Text = "A kígyó sebessége arányosan növekszik a hosszával.";
                    break;
                case 3:
                    diff_3.Checked = true;
                    tbDifficulty.Text = "A kígyó sebessége állandó.";
                    break;
                case 4:
                    diff_4.Checked = true; 
                    tbDifficulty.Text = "A kígyó sebessége aránosan növekszik a hosszával. A játéktéren mérges gombák jelennek meg melyeket, ha megeszünk mínusz pontot kapunk.";
                    break;
            }

            tbUsername.Enabled = false;
            tbEmail.Enabled = false;
            tbFullname.Enabled = false;
            dpBirthdate.Enabled = false;
            btnModify.Enabled = false;

            tbNewPWD1.Enabled = false;
            tbNewPWD2.Enabled = false;
            btnNewPasswordSend.Enabled = false;
        }


        
        private void diff_1_CheckedChanged(object sender, EventArgs e) {
            LoggedInUser.loggedinuser.Game_difficulty = 1;
            tbDifficulty.Text = "A kígyó sebessége nagyobb ütemben, aránosan növekszik a hosszával.";
        }

        
        private void diff_2_CheckedChanged(object sender, EventArgs e) {
            LoggedInUser.loggedinuser.Game_difficulty = 2;
            tbDifficulty.Text = "A kígyó sebessége arányosan növekszik a hosszával.";
        }

        private void diff_3_CheckedChanged(object sender, EventArgs e) {
            LoggedInUser.loggedinuser.Game_difficulty = 3;
            tbDifficulty.Text = "A kígyó sebessége állandó.";
        }

        private void diff_4_CheckedChanged(object sender, EventArgs e) {
            LoggedInUser.loggedinuser.Game_difficulty = 4;
            tbDifficulty.Text = "A kígyó sebessége arányosan növekszik a hosszával. A játéktéren mérges gombák jelennek meg melyeket, ha megeszünk mínusz pontot kapunk.";
        }

        
        private void btnChangePasswordSend_Click(object sender, EventArgs e) {
            try {
                if (db.CorrectPassword(tbCurrentPWD.Text))
                {
                    tbNewPWD1.Enabled = true;
                    tbNewPWD2.Enabled = true;
                    btnNewPasswordSend.Enabled = true;
                    lbWarningUserPWD.Text = "";
                }
                else
                    lbWarningUserPWD.Text = "Helytelen jelszó!";
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }

        private void btnNewPasswordSend_Click(object sender, EventArgs e) {
            try {
                if (tbNewPWD1.Text.Length > 3) {
                    if (tbNewPWD1.Text.Equals(tbNewPWD2.Text)) {
                        lbNotMachingPasswords.Text = "";
                        string pwd = tbNewPWD1.Text;
                        if (db.UpdatePassword(PasswordHash.Hash(pwd))) {
                            MessageBox.Show("Sikeres Módositás.", "message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        } else {
                            MessageBox.Show("Sikertelen Módositás.", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                        lbNotMachingPasswords.Text = "A megadott jelszavak nem egyeznek.";
                } else
                    lbNotMachingPasswords.Text = "A jelszó legyen minimum 4 karakter hosszúságú.";
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }

        
        private void btnPWsend_Click(object sender, EventArgs e) {
            try {
                if (db.CorrectPassword(tbPWD.Text)) {
                    tbUsername.Enabled = true;
                    tbEmail.Enabled = true;
                    tbFullname.Enabled = true;
                    dpBirthdate.Enabled = true;
                    btnModify.Enabled = true;

                    tbUsername.Text = LoggedInUser.loggedinuser.Username;
                    tbEmail.Text = LoggedInUser.loggedinuser.Email;
                    tbFullname.Text = LoggedInUser.loggedinuser.Full_name;
                    dpBirthdate.Value = LoggedInUser.loggedinuser.Birthdate;

                } else
                    lbWarning.Text = "Helytelen jelszó!";
            } catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }


        
        private void btnModify_Click(object sender, EventArgs e) {
            try {
                string s = "";
                if (tbUsername.Text != "" && tbEmail.Text != "" && tbFullname.Text != "") {
                    if (tbEmail.Text.Contains("@") && tbEmail.Text.Contains('.')) {
                        if (tbFullname.Text.Split(' ').Length > 1) {
                            switch (db.UpdateUser(tbUsername.Text, tbEmail.Text, tbFullname.Text, dpBirthdate.Value, LoggedInUser.loggedinuser.Rank)) {
                                case 1:
                                    s = "Siekres Módositás.";
                                    LoggedInUser.loggedinuser.Username = tbUsername.Text;
                                    LoggedInUser.loggedinuser.Email = tbEmail.Text;
                                    LoggedInUser.loggedinuser.Full_name = tbFullname.Text;
                                    LoggedInUser.loggedinuser.Birthdate = dpBirthdate.Value;
                                    break;
                                case 0:
                                    s = "Ez a felhasználónév már foglalt.";
                                    break;
                                case -1:
                                    s = "Sikertelen módositás.";
                                    break;
                                case 2:
                                    s = "Ez az e-mail cím már egy másik felhasználói fiókhoz tartozik.";
                                    break;
                            }
                        } else {
                            s = "Kérem adja meg a teljes nevét!";
                        }
                    } else
                        s = "Helytelen e-mail cím.";
                } else {
                    s = "Minden mezőt kötelező kitölteni.";
                }
                MessageBox.Show(s);
            } catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }



        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }
            
    }
}
