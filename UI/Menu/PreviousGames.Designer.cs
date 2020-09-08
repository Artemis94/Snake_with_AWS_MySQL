namespace Snake_with_AWS_MySQL
{
    partial class PreviousGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviousGames));
            this.gamesDGV = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gamesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesDGV
            // 
            this.gamesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gamesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.points,
            this.difficulty});
            this.gamesDGV.Location = new System.Drawing.Point(12, 12);
            this.gamesDGV.Name = "gamesDGV";
            this.gamesDGV.Size = new System.Drawing.Size(365, 469);
            this.gamesDGV.TabIndex = 0;
            // 
            // time
            // 
            this.time.HeaderText = "Idő";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 130;
            // 
            // points
            // 
            this.points.HeaderText = "Pontok";
            this.points.Name = "points";
            this.points.ReadOnly = true;
            this.points.Width = 50;
            // 
            // difficulty
            // 
            this.difficulty.HeaderText = "Nehézség";
            this.difficulty.Name = "difficulty";
            this.difficulty.ReadOnly = true;
            this.difficulty.Width = 130;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(293, 487);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Vissza";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PreviousGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 516);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gamesDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreviousGames";
            this.Text = "Snake - Korábbi Játszmák";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviousGames_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gamesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gamesDGV;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficulty;
    }
}