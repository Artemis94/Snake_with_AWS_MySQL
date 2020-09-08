namespace Snake_with_AWS_MySQL
{
    partial class ManageUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUser));
            this.dgwUser = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.cbRank = new System.Windows.Forms.ComboBox();
            this.lbRank = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.lbActive = new System.Windows.Forms.Label();
            this.lbWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwUser
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.email,
            this.full_name,
            this.birthDate,
            this.rank,
            this.active});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwUser.Location = new System.Drawing.Point(12, 12);
            this.dgwUser.Name = "dgwUser";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgwUser.Size = new System.Drawing.Size(718, 426);
            this.dgwUser.TabIndex = 0;
            this.dgwUser.SelectionChanged += new System.EventHandler(this.dgwUser_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // username
            // 
            this.username.HeaderText = "Felhasználónév";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 130;
            // 
            // email
            // 
            this.email.HeaderText = "e-mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 150;
            // 
            // full_name
            // 
            this.full_name.HeaderText = "Teljes név";
            this.full_name.Name = "full_name";
            this.full_name.ReadOnly = true;
            this.full_name.Width = 130;
            // 
            // birthDate
            // 
            this.birthDate.HeaderText = "Születés";
            this.birthDate.Name = "birthDate";
            this.birthDate.ReadOnly = true;
            this.birthDate.Width = 130;
            // 
            // rank
            // 
            this.rank.HeaderText = "Rang";
            this.rank.Name = "rank";
            this.rank.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rank.Width = 40;
            // 
            // active
            // 
            this.active.HeaderText = "Aktív";
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Width = 65;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(933, 187);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Módisitás";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(933, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Vissza";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(745, 34);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(263, 20);
            this.tbUsername.TabIndex = 4;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(745, 73);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(263, 20);
            this.tbEmail.TabIndex = 6;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(742, 12);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(81, 13);
            this.lbUsername.TabIndex = 7;
            this.lbUsername.Text = "Felhasználónév";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(741, 57);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(34, 13);
            this.lbEmail.TabIndex = 8;
            this.lbEmail.Text = "e-mail";
            // 
            // cbRank
            // 
            this.cbRank.FormattingEnabled = true;
            this.cbRank.Location = new System.Drawing.Point(745, 113);
            this.cbRank.Name = "cbRank";
            this.cbRank.Size = new System.Drawing.Size(138, 21);
            this.cbRank.TabIndex = 9;
            // 
            // lbRank
            // 
            this.lbRank.AutoSize = true;
            this.lbRank.Location = new System.Drawing.Point(742, 97);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(33, 13);
            this.lbRank.TabIndex = 10;
            this.lbRank.Text = "Rang";
            // 
            // cbActive
            // 
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Location = new System.Drawing.Point(745, 153);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(138, 21);
            this.cbActive.TabIndex = 11;
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Location = new System.Drawing.Point(742, 137);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(47, 13);
            this.lbActive.TabIndex = 12;
            this.lbActive.Text = "Aktivitás";
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.Location = new System.Drawing.Point(742, 372);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(55, 13);
            this.lbWarning.TabIndex = 13;
            this.lbWarning.Text = "lbWarning";
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 450);
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.lbActive);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.lbRank);
            this.Controls.Add(this.cbRank);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgwUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageUser";
            this.Text = "Snake - Felhasználók Kezelése";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageUser_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgwUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwUser;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.ComboBox cbRank;
        private System.Windows.Forms.Label lbRank;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.Label lbWarning;
    }
}