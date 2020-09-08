namespace Snake_with_AWS_MySQL
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbFullname = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.dpBirth = new System.Windows.Forms.DateTimePicker();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbFullname = new System.Windows.Forms.Label();
            this.lbPwd = new System.Windows.Forms.Label();
            this.lbBirth = new System.Windows.Forms.Label();
            this.lbPwd2 = new System.Windows.Forms.Label();
            this.tbPasswordSecond = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(268, 75);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(254, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(268, 117);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(254, 20);
            this.tbEmail.TabIndex = 1;
            // 
            // tbFullname
            // 
            this.tbFullname.Location = new System.Drawing.Point(268, 156);
            this.tbFullname.Name = "tbFullname";
            this.tbFullname.Size = new System.Drawing.Size(254, 20);
            this.tbFullname.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(268, 195);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '@';
            this.tbPassword.Size = new System.Drawing.Size(254, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // dpBirth
            // 
            this.dpBirth.Location = new System.Drawing.Point(268, 273);
            this.dpBirth.Name = "dpBirth";
            this.dpBirth.Size = new System.Drawing.Size(254, 20);
            this.dpBirth.TabIndex = 4;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbUsername.Location = new System.Drawing.Point(265, 59);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(81, 13);
            this.lbUsername.TabIndex = 5;
            this.lbUsername.Text = "Felhasználónév";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbEmail.Location = new System.Drawing.Point(265, 101);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(55, 13);
            this.lbEmail.TabIndex = 6;
            this.lbEmail.Text = "e-mail cím";
            // 
            // lbFullname
            // 
            this.lbFullname.AutoSize = true;
            this.lbFullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbFullname.Location = new System.Drawing.Point(265, 140);
            this.lbFullname.Name = "lbFullname";
            this.lbFullname.Size = new System.Drawing.Size(56, 13);
            this.lbFullname.TabIndex = 7;
            this.lbFullname.Text = "Teljes név";
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbPwd.Location = new System.Drawing.Point(265, 179);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(36, 13);
            this.lbPwd.TabIndex = 8;
            this.lbPwd.Text = "Jelszó";
            // 
            // lbBirth
            // 
            this.lbBirth.AutoSize = true;
            this.lbBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbBirth.Location = new System.Drawing.Point(265, 257);
            this.lbBirth.Name = "lbBirth";
            this.lbBirth.Size = new System.Drawing.Size(81, 13);
            this.lbBirth.TabIndex = 9;
            this.lbBirth.Text = "Születési dátum";
            // 
            // lbPwd2
            // 
            this.lbPwd2.AutoSize = true;
            this.lbPwd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbPwd2.Location = new System.Drawing.Point(265, 218);
            this.lbPwd2.Name = "lbPwd2";
            this.lbPwd2.Size = new System.Drawing.Size(95, 13);
            this.lbPwd2.TabIndex = 10;
            this.lbPwd2.Text = "Jelszó mégegyszer";
            // 
            // tbPasswordSecond
            // 
            this.tbPasswordSecond.Location = new System.Drawing.Point(268, 234);
            this.tbPasswordSecond.Name = "tbPasswordSecond";
            this.tbPasswordSecond.PasswordChar = '@';
            this.tbPasswordSecond.Size = new System.Drawing.Size(254, 20);
            this.tbPasswordSecond.TabIndex = 11;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(268, 312);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Vissza";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(388, 312);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(134, 23);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Regisztráció";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.Location = new System.Drawing.Point(266, 20);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(0, 13);
            this.lbWarning.TabIndex = 14;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Snake_with_AWS_MySQL.Properties.Resources.snake;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tbPasswordSecond);
            this.Controls.Add(this.lbPwd2);
            this.Controls.Add(this.lbBirth);
            this.Controls.Add(this.lbPwd);
            this.Controls.Add(this.lbFullname);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.dpBirth);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbFullname);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registration";
            this.Text = "Snake - Regisztráció";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Regisztration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbFullname;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.DateTimePicker dpBirth;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbFullname;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.Label lbBirth;
        private System.Windows.Forms.Label lbPwd2;
        private System.Windows.Forms.TextBox tbPasswordSecond;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lbWarning;
    }
}