using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_with_AWS_MySQL
{
    /// <summary>
    /// This is the Menu window, the user can navigate from here to the various parts of the program.
    /// </summary>
    public partial class Menu : Form
    {
        private bool logout;

        /// <summary>
        /// Initializes a new Instance of the Menu calss(the Menu window). 
        /// Sets the base values and window settings.
        /// </summary>
        /// <remarks>
        /// Checks if the user logged in is an administrator, if not, the administrator point becomes unavailable. 
        /// </remarks>
        public Menu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lbWelcome.ForeColor = Color.Teal;
            lbWelcome.Text = "Szia " + LoggedInUser.loggedinuser.Username;

            logout = false;

            if (LoggedInUser.loggedinuser.Rank==1)
            {
                btnManageUser.Enabled = false;
                btnManageUser.Hide();
            }
        }

        private void btnNewGamge_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game g = new Game();
            g.Tag = this;
            g.Show();
        }


        private void btnPreviousGames_Click(object sender, EventArgs e)
        {
            PreviousGames pg = new PreviousGames();
            pg.Tag = this;
            this.Hide();
            pg.Show();
        }


        private void btnOptions_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Tag = this;
            this.Hide();
            s.Show();
            lbWelcome.Text ="Szia "+ LoggedInUser.loggedinuser.Username+"!";
        }



        private void btnRankedList_Click(object sender, EventArgs e)
        {
            RankedList r = new RankedList();
            r.Tag = this;
            this.Hide();
            r.Show();
        }



        private void btnManageUser_Click(object sender, EventArgs e)
        {
            ManageUser mu = new ManageUser();
            mu.Tag = this;
            this.Hide();
            mu.Show();
        }



        private void btnLogout_Click(object sender, EventArgs e) {
            logout = true;
            LoggedInUser.loggedinuser = null;
            this.Close();
        }



        private void Menu_FormClosing(object sender, FormClosingEventArgs e) {
            if (logout) {
                (Tag as Form).Show();
            } else
                Application.Exit();
        }

    }
}
