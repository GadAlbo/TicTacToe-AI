namespace TicTacToe_MiniMax
{
    partial class Form1
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
            this.TurnText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TurnText
            // 
            this.TurnText.AutoSize = true;
            this.TurnText.Font = new System.Drawing.Font("Comic Sans MS", 20.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TurnText.Location = new System.Drawing.Point(103, 76);
            this.TurnText.Name = "TurnText";
            this.TurnText.Size = new System.Drawing.Size(444, 95);
            this.TurnText.TabIndex = 9;
            this.TurnText.Text = "YOUR TURN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(656, 702);
            this.Controls.Add(this.TurnText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TurnText;
    }
}

