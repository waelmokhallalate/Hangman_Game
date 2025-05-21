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
    public partial class ScoreboardForm : Form
    {
        public int CurrentUserId { get; set; }
        public ScoreboardForm()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void ScoreboardForm_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-6BQL6US\\SQLEXPRESS; Initial Catalog=hangman; Integrated Security=True; TrustServerCertificate=True";
            conn = new SqlConnection(connString);
            LoadScoreboard();
        }
        private void LoadScoreboard()
        {
            try
            {
                conn.Open();

                string query = @"
            SELECT 
                ROW_NUMBER() OVER (
                    ORDER BY 
                        CASE 
                            WHEN s.loses = 0 THEN s.wins 
                            ELSE CAST(s.wins AS float) / s.loses 
                        END DESC
                ) AS Placement,
                u.name AS Player, 
                s.wins AS Wins, 
                s.loses AS Losses,
                (s.wins + s.loses) AS TotalGames
            FROM scoreboard s
            INNER JOIN [user] u ON s.user_id = u.id
            ORDER BY Placement";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable scoreTable = new DataTable();
                adapter.Fill(scoreTable);
                string currentUserQuery = "SELECT name FROM [user] WHERE id = @userId";
                SqlCommand cmd = new SqlCommand(currentUserQuery, conn);
                cmd.Parameters.AddWithValue("@userId", CurrentUserId);
                string currentUsername = cmd.ExecuteScalar() as string;

                dgv_Scoreboard.DataSource = scoreTable;
                dgv_Scoreboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Scoreboard.ReadOnly = true;
                dgv_Scoreboard.AllowUserToAddRows = false;
                dgv_Scoreboard.AllowUserToDeleteRows = false;
                dgv_Scoreboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_Scoreboard.RowHeadersVisible = false;

                foreach (DataGridViewRow row in dgv_Scoreboard.Rows)
                {
                    if (row.Cells["Player"].Value.ToString() == currentUsername)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scoreboard: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
