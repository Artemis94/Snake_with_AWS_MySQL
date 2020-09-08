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
    /// The User management window, accessible only to the administrator.
    /// </summary>
    public partial class ManageUser : Form
    {
        private DatabaseHandler db;

        /// <summary>
        /// Initializes a new instance of the ManageUser class(the user management window).
        /// </summary>
        /// <remarks>
        /// Sets the base values and window settings, attempts to aquire the reference to the DatabaseHandler object and loads the user data from the 
        /// database to the window.
        /// </remarks>
        public ManageUser()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            lbWarning.Text = "";
            lbWarning.ForeColor = Color.Red;
            this.MaximizeBox = false;
            db = DatabaseHandler.Instance;
            cbRank.Items.Add(1);
            cbRank.Items.Add(2);
            cbActive.Items.Add(true);
            cbActive.Items.Add(false);
            dgwUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwUser.AllowUserToAddRows = false;

            LoadUser();

            dgwUser.ClearSelection();
        }

    
        private void LoadUser()
        {
            try {
                List<User> User = db.SelecAllUsers();

                if (User.Count > 0) {
                    for (int i = 0; i < User.Count; i++) {
                        dgwUser.Rows.Add();
                        dgwUser.Rows[i].Cells["id"].Value = User[i].Id;
                        dgwUser.Rows[i].Cells["username"].Value = User[i].Username;
                        dgwUser.Rows[i].Cells["email"].Value = User[i].Email;
                        dgwUser.Rows[i].Cells["full_name"].Value = User[i].Full_name;
                        dgwUser.Rows[i].Cells["birthdate"].Value = User[i].Birthdate;
                        dgwUser.Rows[i].Cells["rank"].Value = User[i].Rank;
                        dgwUser.Rows[i].Cells["active"].Value = User[i].Active;

                    }
                }
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }


        private void dgwUser_SelectionChanged(object sender, EventArgs e) {
            try {
                cbRank.Enabled = true;
                tbUsername.Text = dgwUser.CurrentRow.Cells[1].Value.ToString();
                tbEmail.Text = dgwUser.CurrentRow.Cells[2].Value.ToString();
                cbRank.SelectedItem = dgwUser.CurrentRow.Cells[5].Value;
                cbActive.SelectedItem = dgwUser.CurrentRow.Cells[6].Value;
                if (Convert.ToInt32(dgwUser.CurrentRow.Cells[5].Value) != 3) {
                    cbRank.Enabled = true;
                    cbActive.Enabled = true;
                    tbUsername.Enabled = true;
                    tbEmail.Enabled = true;
                }
                if (Convert.ToInt32(dgwUser.CurrentRow.Cells[5].Value) == 3) {
                    cbRank.Enabled = false;
                    cbActive.Enabled = false;
                    tbUsername.Enabled = false;
                    tbEmail.Enabled = false;
                }
            } catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");          
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                int d = db.AdminUpdateUser(Convert.ToInt32(dgwUser.CurrentRow.Cells[0].Value), tbUsername.Text, tbEmail.Text, Convert.ToInt32(cbRank.SelectedItem), Convert.ToBoolean(cbActive.SelectedItem));

                if (d == 1) {
                    dgwUser.CurrentRow.Cells[1].Value = tbUsername.Text;
                    dgwUser.CurrentRow.Cells[2].Value = tbEmail.Text;
                    dgwUser.CurrentRow.Cells[5].Value = cbRank.SelectedItem;
                    dgwUser.CurrentRow.Cells[6].Value = cbActive.SelectedItem;
                    MessageBox.Show("Sikeres módositás.");
                } else if (d == 0)
                    MessageBox.Show("Már van ilyen nevű felhasználó");
                else if (d == 2)
                    MessageBox.Show("Ez az e-mail cím már egy másik felhasználói fiókhoz tartozik.");
                else
                    MessageBox.Show("Sikertelen módositás.");
            } 
            catch (MySqlException) {
                MessageBox.Show("Nem sikerült kapcsolatot létesíteni az adatbázissal.\nEllenőrizze az adatbázis kiszolgálót és próbálja újra.");
            }
        }

   
        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ManageUser_FormClosing(object sender, FormClosingEventArgs e) {
            (Tag as Form).Show();
        }


    }
}
