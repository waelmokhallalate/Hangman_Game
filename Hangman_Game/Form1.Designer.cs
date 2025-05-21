namespace Hangman_Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txt_password = new TextBox();
            txt_name = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            btn_login = new Button();
            link_register = new LinkLabel();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(405, 37);
            label1.TabIndex = 0;
            label1.Text = "Welcome To Hangman Game!!";
            // 
            // txt_password
            // 
            txt_password.Location = new Point(231, 202);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(151, 23);
            txt_password.TabIndex = 1;
            txt_password.UseSystemPasswordChar = true;
            // 
            // txt_name
            // 
            txt_name.Location = new Point(231, 153);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(151, 23);
            txt_name.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(62, 197);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 7;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(62, 154);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 5;
            label2.Text = "Username:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(187, 96);
            label5.Name = "label5";
            label5.Size = new Size(61, 28);
            label5.TabIndex = 4;
            label5.Text = "Login";
            // 
            // btn_login
            // 
            btn_login.Location = new Point(187, 248);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(83, 36);
            btn_login.TabIndex = 2;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // link_register
            // 
            link_register.AutoSize = true;
            link_register.Location = new Point(371, 259);
            link_register.Name = "link_register";
            link_register.Size = new Size(46, 15);
            link_register.TabIndex = 12;
            link_register.TabStop = true;
            link_register.Text = "register";
            link_register.LinkClicked += link_register_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F);
            label4.Location = new Point(294, 261);
            label4.Name = "label4";
            label4.Size = new Size(71, 13);
            label4.TabIndex = 7;
            label4.Text = "No account?";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 296);
            Controls.Add(link_register);
            Controls.Add(btn_login);
            Controls.Add(txt_password);
            Controls.Add(txt_name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Hangman Game";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_password;
        private TextBox txt_name;
        private Label label3;
        private Label label2;
        private Label label5;
        private Button btn_login;
        private LinkLabel link_register;
        private Label label4;
    }
}
