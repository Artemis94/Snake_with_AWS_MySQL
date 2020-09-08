namespace Snake_with_AWS_MySQL
{
    partial class Password_Reset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password_Reset));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPWD1 = new System.Windows.Forms.TextBox();
            this.tbPWD2 = new System.Windows.Forms.TextBox();
            this.lbWarning = new System.Windows.Forms.Label();
            this.password_send_button = new System.Windows.Forms.Button();
            this.code_send_button = new System.Windows.Forms.Button();
            this.email_send_button = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPWD1);
            this.panel1.Controls.Add(this.tbPWD2);
            this.panel1.Controls.Add(this.lbWarning);
            this.panel1.Controls.Add(this.password_send_button);
            this.panel1.Controls.Add(this.code_send_button);
            this.panel1.Controls.Add(this.email_send_button);
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(186, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 197);
            this.panel1.TabIndex = 0;
            // 
            // tbPWD1
            // 
            this.tbPWD1.Location = new System.Drawing.Point(92, 99);
            this.tbPWD1.Name = "tbPWD1";
            this.tbPWD1.PasswordChar = '@';
            this.tbPWD1.Size = new System.Drawing.Size(252, 20);
            this.tbPWD1.TabIndex = 2;
            // 
            // tbPWD2
            // 
            this.tbPWD2.Location = new System.Drawing.Point(92, 125);
            this.tbPWD2.Name = "tbPWD2";
            this.tbPWD2.PasswordChar = '@';
            this.tbPWD2.Size = new System.Drawing.Size(252, 20);
            this.tbPWD2.TabIndex = 6;
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.Location = new System.Drawing.Point(89, 61);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(35, 13);
            this.lbWarning.TabIndex = 5;
            this.lbWarning.Text = "label2";
            // 
            // password_send_button
            // 
            this.password_send_button.Location = new System.Drawing.Point(346, 159);
            this.password_send_button.Name = "password_send_button";
            this.password_send_button.Size = new System.Drawing.Size(75, 23);
            this.password_send_button.TabIndex = 4;
            this.password_send_button.Text = "Küldés";
            this.password_send_button.UseVisualStyleBackColor = true;
            this.password_send_button.Click += new System.EventHandler(this.password_send_button_Click);
            // 
            // code_send_button
            // 
            this.code_send_button.Location = new System.Drawing.Point(346, 159);
            this.code_send_button.Name = "code_send_button";
            this.code_send_button.Size = new System.Drawing.Size(75, 23);
            this.code_send_button.TabIndex = 3;
            this.code_send_button.Text = "Küldés";
            this.code_send_button.UseVisualStyleBackColor = true;
            this.code_send_button.Click += new System.EventHandler(this.code_send_button_Click);
            // 
            // email_send_button
            // 
            this.email_send_button.Location = new System.Drawing.Point(346, 159);
            this.email_send_button.Name = "email_send_button";
            this.email_send_button.Size = new System.Drawing.Size(75, 23);
            this.email_send_button.TabIndex = 2;
            this.email_send_button.Text = "Küldés";
            this.email_send_button.UseVisualStyleBackColor = true;
            this.email_send_button.Click += new System.EventHandler(this.email_send_button_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(92, 99);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(252, 20);
            this.textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(89, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 416);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Vissza";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Password_Reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Snake_with_AWS_MySQL.Properties.Resources.snake;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Password_Reset";
            this.Text = "Password_Reset";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Password_Reset_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button email_send_button;
        private System.Windows.Forms.Button password_send_button;
        private System.Windows.Forms.Button code_send_button;
        private System.Windows.Forms.Label lbWarning;
        private System.Windows.Forms.TextBox tbPWD2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbPWD1;
    }
}