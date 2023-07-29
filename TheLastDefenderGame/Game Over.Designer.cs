
namespace TheLastDefenderGame
{
    partial class Game_Over
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGameOver = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelGameOver
            // 
            this.labelGameOver.BackColor = System.Drawing.Color.Transparent;
            this.labelGameOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGameOver.Font = new System.Drawing.Font("Chiller", 144F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelGameOver.Location = new System.Drawing.Point(0, 0);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(698, 662);
            this.labelGameOver.TabIndex = 1;
            this.labelGameOver.Text = "GAME OVER";
            this.labelGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScore
            // 
            this.labelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelScore.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelScore.Location = new System.Drawing.Point(-9, 427);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(704, 24);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "Score: ";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 208);
            this.panel1.TabIndex = 3;
            // 
            // Game_Over
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelGameOver);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Game_Over";
            this.Size = new System.Drawing.Size(698, 662);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Panel panel1;
    }
}
