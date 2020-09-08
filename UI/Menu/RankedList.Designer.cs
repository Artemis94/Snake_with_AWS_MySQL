namespace Snake_with_AWS_MySQL
{
    partial class RankedList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankedList));
            this.gamesDGV = new System.Windows.Forms.DataGridView();
            this.diff1 = new System.Windows.Forms.RadioButton();
            this.diff2 = new System.Windows.Forms.RadioButton();
            this.diff3 = new System.Windows.Forms.RadioButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbChooseDiff = new System.Windows.Forms.Label();
            this.diff4 = new System.Windows.Forms.RadioButton();
            this.rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gamesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesDGV
            // 
            this.gamesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gamesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rank,
            this.user,
            this.points,
            this.time});
            this.gamesDGV.Location = new System.Drawing.Point(24, 56);
            this.gamesDGV.Name = "gamesDGV";
            this.gamesDGV.Size = new System.Drawing.Size(461, 493);
            this.gamesDGV.TabIndex = 0;
            // 
            // diff1
            // 
            this.diff1.AutoSize = true;
            this.diff1.Location = new System.Drawing.Point(202, 24);
            this.diff1.Name = "diff1";
            this.diff1.Size = new System.Drawing.Size(111, 17);
            this.diff1.TabIndex = 1;
            this.diff1.TabStop = true;
            this.diff1.Text = "SzáguldóSziszegő";
            this.diff1.UseVisualStyleBackColor = true;
            this.diff1.CheckedChanged += new System.EventHandler(this.diff1_CheckedChanged);
            // 
            // diff2
            // 
            this.diff2.AutoSize = true;
            this.diff2.Location = new System.Drawing.Point(319, 22);
            this.diff2.Name = "diff2";
            this.diff2.Size = new System.Drawing.Size(66, 17);
            this.diff2.TabIndex = 2;
            this.diff2.TabStop = true;
            this.diff2.Text = "Gyorsuló";
            this.diff2.UseVisualStyleBackColor = true;
            this.diff2.CheckedChanged += new System.EventHandler(this.diff2_CheckedChanged);
            // 
            // diff3
            // 
            this.diff3.AutoSize = true;
            this.diff3.Location = new System.Drawing.Point(398, 22);
            this.diff3.Name = "diff3";
            this.diff3.Size = new System.Drawing.Size(60, 17);
            this.diff3.TabIndex = 3;
            this.diff3.TabStop = true;
            this.diff3.Text = "Állandó";
            this.diff3.UseVisualStyleBackColor = true;
            this.diff3.CheckedChanged += new System.EventHandler(this.diff3_CheckedChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(410, 570);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Vissza";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbChooseDiff
            // 
            this.lbChooseDiff.AutoSize = true;
            this.lbChooseDiff.Location = new System.Drawing.Point(27, 24);
            this.lbChooseDiff.Name = "lbChooseDiff";
            this.lbChooseDiff.Size = new System.Drawing.Size(98, 13);
            this.lbChooseDiff.TabIndex = 5;
            this.lbChooseDiff.Text = "Nehézségi fokozat:";
            // 
            // diff4
            // 
            this.diff4.AutoSize = true;
            this.diff4.Location = new System.Drawing.Point(131, 24);
            this.diff4.Name = "diff4";
            this.diff4.Size = new System.Drawing.Size(65, 17);
            this.diff4.TabIndex = 6;
            this.diff4.TabStop = true;
            this.diff4.Text = "Gombák";
            this.diff4.UseVisualStyleBackColor = true;
            this.diff4.CheckedChanged += new System.EventHandler(this.diff4_CheckedChanged);
            // 
            // rank
            // 
            this.rank.HeaderText = "Helyezés";
            this.rank.Name = "rank";
            this.rank.ReadOnly = true;
            this.rank.Width = 55;
            // 
            // user
            // 
            this.user.HeaderText = "Felhasználó";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 130;
            // 
            // points
            // 
            this.points.HeaderText = "Pontok";
            this.points.Name = "points";
            this.points.ReadOnly = true;
            // 
            // time
            // 
            this.time.HeaderText = "Idő";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 130;
            // 
            // RankedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 605);
            this.Controls.Add(this.diff4);
            this.Controls.Add(this.lbChooseDiff);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.diff3);
            this.Controls.Add(this.diff2);
            this.Controls.Add(this.diff1);
            this.Controls.Add(this.gamesDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RankedList";
            this.Text = "Snake - Ranglista";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RankedList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gamesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gamesDGV;
        private System.Windows.Forms.RadioButton diff1;
        private System.Windows.Forms.RadioButton diff2;
        private System.Windows.Forms.RadioButton diff3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbChooseDiff;
        private System.Windows.Forms.RadioButton diff4;
        private System.Windows.Forms.DataGridViewTextBoxColumn rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
    }
}