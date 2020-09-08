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
using System.Net.Mail;

namespace Snake_with_AWS_MySQL
{
    public partial class Password_Reset : Form
    {

        private DatabaseHandler db;
        private string code;
        private string email;
        private static Random r;


        /// <summary>
        /// Initializes a new Instance of the Password_Reset calss(the Password reset window). 
        /// Sets the base values and window settings.
        /// </summary>
        /// <remarks>
        /// Checks if the user logged in is an administrator, if not, the administrator point becomes unavailable. 
        /// </remarks>
        public Password_Reset()
        {
            InitializeComponent();
            code_send_button.Hide();
            password_send_button.Hide();
            tbPWD1.Hide();
            tbPWD2.Hide();

            panel1.BackColor= Color.FromArgb(150, Color.Black);
            label1.ForeColor = Color.White;
            label1.Text = "Kérlek add meg a regisztrált e-mail címed.";
            lbWarning.Text = ""; 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            lbWarning.ForeColor = Color.Red;
            MaximizeBox = false;

            db = DatabaseHandler.Instance;
        }

 
        private void GenerateCode()
        {
            r = new Random();
            string c = "";

            for (int i = 0; i < 20; i++)
            {
                switch (r.Next(1,4))
                {
                    case 1:
                        c += r.Next(0, 9);
                        break;
                    case 2:
                        c += (char)r.Next('a', 'z');
                        break;
                    case 3:
                        c += (char)r.Next('A', 'Z');
                        break;
                }
            }
            code = c;
        }

        /// <summary>
        /// Sends an e-mail with the reset code to the recieved e-mail address.
        /// </summary>
        /// <param name="emailAddress"></param>
        private void SendEmail(string emailAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                
                mail.From = new MailAddress("email@gmail.com");
                mail.To.Add(emailAddress);
                mail.Subject = "Snake Új Jelszó";
                GenerateCode();
                mail.Body = "Szia\n\nKérlek, használd az alábbi kódot az új jelszó beállításához: \n\n"+code+"\n\nHa bármi probléma adódna kérjük jelezd!\n\nJó játékot!\nHenry the Snake" ;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                MessageBox.Show("E-mail elküldve.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
  
        /// <summary>
        /// If the given e-mail exists in the database, moves the window to the state where it is expecting the code. Otherwise warnns the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void email_send_button_Click(object sender, EventArgs e)
        {
            if (db.SelectEmail(textBox.Text))
            {
                email = textBox.Text;
                SendEmail(textBox.Text);
                textBox.Text = "";
                lbWarning.Text = "";
                email_send_button.Hide();
                code_send_button.Show();
                label1.Text = "Kérlek, add meg az e-mailben kapott kódot.";
            }
            else
            {
                lbWarning.Text = "Nincs ilyen e-mailcím regisztrálva.";
            }
        }

        /// <summary>
        /// If the code given by the user is correct, moves the window to the state where it is expecting the new password. Otherwise warns the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void code_send_button_Click(object sender, EventArgs e)
        {
            if (textBox.Text == code)
            {
                textBox.Text = "";
                tbPWD2.Show();
                code_send_button.Hide();
                password_send_button.Show();
                tbPWD1.Show();
                textBox.Hide();
                lbWarning.Text = "";
                label1.Text = "Kérlek, add meg az új jelszavadat.";
            }
            else
                lbWarning.Text = "Helytelen kód!";
        }

        /// <summary>
        /// Attempts to write to the database the new password for the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void password_send_button_Click(object sender, EventArgs e)
        {
            if (tbPWD1.Text == tbPWD2.Text)
            {
                try
                {
                    if (db.UpdatePassword(PasswordHash.Hash(tbPWD1.Text), email))
                    {
                        MessageBox.Show("Sikeres módosítás.");
                    }
                    else
                    {
                        MessageBox.Show("Sikeretelen módosítás.");
                    }
                }
                catch (MySqlException)
                {

                }

                this.Close();
            }
            else
                lbWarning.Text = "A megadott jelszavak nem egyeznek.";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as Form).Show();
            this.Close();
        }

        private void Password_Reset_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Tag as Form).Show();
        }
    }
}
