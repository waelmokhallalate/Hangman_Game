using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman_Game
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        SqlConnection conn;

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-6BQL6US\\SQLEXPRESS; Initial Catalog=hangman; Integrated Security=True; TrustServerCertificate=True";
            conn = new SqlConnection(connString);
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            String name = txt_name.Text;
            String password = txt_password.Text;
            String confirmPassword = txt_confirmpassword.Text;
            if (name.Trim() == "" || password.Trim() == "" || confirmPassword.Trim() == "")
            {
                MessageBox.Show("Please fill all the fields", "Register Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
             }   
            else if (password != confirmPassword)
            {
                MessageBox.Show("Password Mismatch", "Register Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [user] (name, password) VALUES (@name, @password)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");
                    SqlCommand cmdfindid = new SqlCommand("SELECT id FROM [user] WHERE name = @name AND password = @password", conn);
                    cmdfindid.Parameters.AddWithValue("@name", name);
                    cmdfindid.Parameters.AddWithValue("@password", password);

                    object result = cmdfindid.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        this.Hide();

                        GameForm gameForm = new GameForm();
                        gameForm.CurrentUser = name;
                        gameForm.CurrentUserId = userId;
                        gameForm.StartPosition = FormStartPosition.CenterScreen;



                        gameForm.FormClosed += (s, args) => this.Close();
                        gameForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void link_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = new Form1();
            this.Close();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.ShowDialog();
        }
    }
}
