namespace Snake_with_AWS_MySQL
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.lbGameState = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labenInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbGameState
            // 
            this.lbGameState.AutoSize = true;
            this.lbGameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbGameState.Location = new System.Drawing.Point(12, 601);
            this.lbGameState.Name = "lbGameState";
            this.lbGameState.Size = new System.Drawing.Size(51, 20);
            this.lbGameState.TabIndex = 0;
            this.lbGameState.Text = "label1";
            // 
            // labenInfo
            // 
            this.labenInfo.AutoSize = true;
            this.labenInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labenInfo.Location = new System.Drawing.Point(639, 601);
            this.labenInfo.Name = "labenInfo";
            this.labenInfo.Size = new System.Drawing.Size(265, 16);
            this.labenInfo.TabIndex = 1;
            this.labenInfo.Text = "A kilépéshez nyomd meg az \'esc\' billentyűt.";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 621);
            this.Controls.Add(this.labenInfo);
            this.Controls.Add(this.lbGameState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "Snake - Játék";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGameState;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labenInfo;
    }
}