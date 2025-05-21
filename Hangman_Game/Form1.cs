using System.Data.SqlClient;

namespace Hangman_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-6BQL6US\\SQLEXPRESS; Initial Catalog=hangman; Integrated Security=True; TrustServerCertificate=True";
            conn = new SqlConnection(connString);

        }

        private void link_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.StartPosition = FormStartPosition.CenterScreen;
            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.ShowDialog();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string password = txt_password.Text;

            if (name.Trim() == "" || password.Trim() == "")
            {
                MessageBox.Show("Please enter both username and password", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id FROM [user] WHERE name = @name AND password = @password", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();

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
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
