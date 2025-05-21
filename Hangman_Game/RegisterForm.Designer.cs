namespace Hangman_Game
{
    partial class RegisterForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_name = new TextBox();
            txt_password = new TextBox();
            btn_register = new Button();
            txt_confirmpassword = new TextBox();
            link_login = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(137, 9);
            label1.Name = "label1";
            label1.Size = new Size(77, 28);
            label1.TabIndex = 0;
            label1.Text = "SignUp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(172, 28);
            label4.TabIndex = 2;
            label4.Text = "Confirm Password:";
            // 
            // txt_name
            // 
            txt_name.Location = new Point(181, 51);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(151, 23);
            txt_name.TabIndex = 0;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(181, 100);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(151, 23);
            txt_password.TabIndex = 1;
            txt_password.UseSystemPasswordChar = true;
            // 
            // btn_register
            // 
            btn_register.Location = new Point(113, 176);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(101, 35);
            btn_register.TabIndex = 3;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = true;
            btn_register.Click += btn_register_Click;
            // 
            // txt_confirmpassword
            // 
            txt_confirmpassword.Location = new Point(181, 146);
            txt_confirmpassword.Name = "txt_confirmpassword";
            txt_confirmpassword.Size = new Size(151, 23);
            txt_confirmpassword.TabIndex = 2;
            txt_confirmpassword.UseSystemPasswordChar = true;
            // 
            // link_login
            // 
            link_login.AutoSize = true;
            link_login.Location = new Point(281, 186);
            link_login.Name = "link_login";
            link_login.Size = new Size(37, 15);
            link_login.TabIndex = 14;
            link_login.TabStop = true;
            link_login.Text = "Login";
            link_login.LinkClicked += link_login_LinkClicked;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 221);
            Controls.Add(link_login);
            Controls.Add(btn_register);
            Controls.Add(txt_confirmpassword);
            Controls.Add(txt_password);
            Controls.Add(txt_name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "RegisterForm";
            Text = "Hangman Game";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_name;
        private TextBox txt_password;
        private Button btn_register;
        private TextBox txt_confirmpassword;
        private LinkLabel link_login;
    }
}