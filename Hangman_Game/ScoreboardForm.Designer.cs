namespace Hangman_Game
{
    partial class ScoreboardForm
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
            dgv_Scoreboard = new DataGridView();
            lable1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_Scoreboard).BeginInit();
            SuspendLayout();
            // 
            // dgv_Scoreboard
            // 
            dgv_Scoreboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Scoreboard.Location = new Point(32, 139);
            dgv_Scoreboard.Name = "dgv_Scoreboard";
            dgv_Scoreboard.Size = new Size(736, 299);
            dgv_Scoreboard.TabIndex = 0;
            // 
            // lable1
            // 
            lable1.AutoSize = true;
            lable1.Font = new Font("Segoe UI", 25F);
            lable1.Location = new Point(298, 52);
            lable1.Name = "lable1";
            lable1.Size = new Size(193, 46);
            lable1.TabIndex = 1;
            lable1.Text = "Scoreboard";
            // 
            // ScoreboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lable1);
            Controls.Add(dgv_Scoreboard);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ScoreboardForm";
            Text = "ScoreboardForm";
            Load += ScoreboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Scoreboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Scoreboard;
        private Label lable1;
    }
}