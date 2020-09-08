namespace Snake_with_AWS_MySQL
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnNewGamge = new System.Windows.Forms.Button();
            this.btnPreviousGames = new System.Windows.Forms.Button();
            this.btnRankedList = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnManageUser = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewGamge
            // 
            this.btnNewGamge.Location = new System.Drawing.Point(198, 62);
            this.btnNewGamge.Name = "btnNewGamge";
            this.btnNewGamge.Size = new System.Drawing.Size(401, 54);
            this.btnNewGamge.TabIndex = 0;
            this.btnNewGamge.Text = "Új játék";
            this.btnNewGamge.UseVisualStyleBackColor = true;
            this.btnNewGamge.Click += new System.EventHandler(this.btnNewGamge_Click);
            // 
            // btnPreviousGames
            // 
            this.btnPreviousGames.Location = new System.Drawing.Point(198, 122);
            this.btnPreviousGames.Name = "btnPreviousGames";
            this.btnPreviousGames.Size = new System.Drawing.Size(401, 54);
            this.btnPreviousGames.TabIndex = 1;
            this.btnPreviousGames.Text = "Játszmáim";
            this.btnPreviousGames.UseVisualStyleBackColor = true;
            this.btnPreviousGames.Click += new System.EventHandler(this.btnPreviousGames_Click);
            // 
            // btnRankedList
            // 
            this.btnRankedList.Location = new System.Drawing.Point(198, 182);
            this.btnRankedList.Name = "btnRankedList";
            this.btnRankedList.Size = new System.Drawing.Size(401, 54);
            this.btnRankedList.TabIndex = 2;
            this.btnRankedList.Text = "Ranglista";
            this.btnRankedList.UseVisualStyleBackColor = true;
            this.btnRankedList.Click += new System.EventHandler(this.btnRankedList_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(198, 242);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(401, 54);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "Beállítások";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnManageUser
            // 
            this.btnManageUser.Location = new System.Drawing.Point(198, 302);
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.Size = new System.Drawing.Size(401, 54);
            this.btnManageUser.TabIndex = 4;
            this.btnManageUser.Text = "Felhasználók Kezelése";
            this.btnManageUser.UseVisualStyleBackColor = true;
            this.btnManageUser.Click += new System.EventHandler(this.btnManageUser_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(12, 9);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(35, 13);
            this.lbWelcome.TabIndex = 5;
            this.lbWelcome.Text = "label1";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(705, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(83, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Kijelentkezés";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.btnManageUser);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnRankedList);
            this.Controls.Add(this.btnPreviousGames);
            this.Controls.Add(this.btnNewGamge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Snake - Menü";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGamge;
        private System.Windows.Forms.Button btnPreviousGames;
        private System.Windows.Forms.Button btnRankedList;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnManageUser;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnLogout;
    }
}