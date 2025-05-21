using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hangman_Game
{
    public partial class GameForm : Form
    {
        public string CurrentUser { get; set; }
        public int CurrentUserId { get; set; }

        private string wordToGuess;
        private bool win;
        private string displayedWord;
        private List<string> usedLetters;
        private int wrongGuesses;
        private int currentScore;
        private int maxWrongGuesses = 10;
        private Random random = new Random();
        private List<string> wordList;

        private SqlConnection conn;

        public GameForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            string connString = "Data Source=DESKTOP-6BQL6US\\SQLEXPRESS; Initial Catalog=hangman; Integrated Security=True; TrustServerCertificate=True";
            conn = new SqlConnection(connString);

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            LoadWordsFromFile();
            InitializeGame();
            lbl_Welcome.Text = "Welcome " + CurrentUser + "!";
        }

        private void InitializeGame()
        {
            wrongGuesses = 0;
            usedLetters = new List<string>();


            SelectRandomWord();

            UpdateGameDisplay();

            foreach (Control ctrl in pbl_Letters.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = true;
                    btn.TabStop = false;
                }
            }

            UpdateHangmanImage();

        }
        private void LoadWordsFromFile()
        {
            string filePath = Path.Combine(Application.StartupPath, "words.txt");
            if (File.Exists(filePath))
            {
                wordList = File.ReadAllLines(filePath)
                               .Select(word => word.Trim())
                               .Where(word => !string.IsNullOrWhiteSpace(word))
                               .ToList();
            }
            else
            {
                MessageBox.Show("Word list file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wordList = new List<string>();
            }
        }
        private void SelectRandomWord()
        {
            wordToGuess = wordList[random.Next(wordList.Count)];

            displayedWord = new string('_', wordToGuess.Length);

            lbl_Word.Text = string.Join(" ", displayedWord.ToCharArray());
        }

        private void UpdateGameDisplay()
        {
            lbl_Word.Text = string.Join(" ", displayedWord.ToCharArray());



        }

        private void UpdateHangmanImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Images", $"hangman{wrongGuesses}.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pb_Hangman.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb_Hangman.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pb_Hangman.Image = null;
                }
            }
            catch (Exception)
            {
                pb_Hangman.Image = null;
            }
        }
        private void ProcessLetterGuess(string letter)
        {


            usedLetters.Add(letter);

            if (wordToGuess.Contains(letter))
            {
                char[] displayArray = displayedWord.ToCharArray();
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i].ToString() == letter)
                    {
                        displayArray[i] = wordToGuess[i];
                    }
                }
                displayedWord = new string(displayArray);



                if (!displayedWord.Contains("_"))
                {
                    win = true;
                    SaveScore(win);
                    UpdateGameDisplay();
                    MessageBox.Show($"Congratulations! You've guessed the word: {wordToGuess}\n",
                        "You Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do you want to play again?", "Play Again",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InitializeGame();
                    }
                    else
                    {
                        foreach (Control ctrl in pbl_Letters.Controls)
                        {
                            if (ctrl is Button btn)
                            {
                                btn.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                wrongGuesses++;

                UpdateHangmanImage();

                if (wrongGuesses >= maxWrongGuesses)
                {
                    win = false;
                    SaveScore(win);
                    UpdateGameDisplay();
                    MessageBox.Show($"Game Over! The word was: {wordToGuess}\n",
                        "You Lose!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do you want to play again?", "Play Again",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InitializeGame();
                    }
                    else
                    {
                        foreach (Control ctrl in pbl_Letters.Controls)
                        {
                            if (ctrl is Button btn)
                            {
                                btn.Enabled = false;
                            }
                        }
                    }
                }
            }

            UpdateGameDisplay();
        }

        private void btn_letter_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            string letter = clickedButton.Text;

            clickedButton.Enabled = false;

            ProcessLetterGuess(letter);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (wrongGuesses > 0 || displayedWord.Contains(wordToGuess[0]))
            {
                if (MessageBox.Show("Are you sure you want to start a new game?", "New Game",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InitializeGame();
                }
            }
            else
            {
                InitializeGame();
            }
        }

        private void SaveScore(bool win)
        {
            try
            {
                conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM scoreboard WHERE user_id = @userId", conn);
                checkCmd.Parameters.AddWithValue("@userId", CurrentUserId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    string columnToUpdate = win ? "wins" : "loses";
                    SqlCommand updateCmd = new SqlCommand(
                        $"UPDATE scoreboard SET {columnToUpdate} = {columnToUpdate} + 1 WHERE user_id = @userId", conn);
                    updateCmd.Parameters.AddWithValue("@userId", CurrentUserId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    int wins = win ? 1 : 0;
                    int loses = win ? 0 : 1;

                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO scoreboard (user_id, wins, loses) VALUES (@userId, @wins, @loses)", conn);
                    insertCmd.Parameters.AddWithValue("@userId", CurrentUserId);
                    insertCmd.Parameters.AddWithValue("@wins", wins);
                    insertCmd.Parameters.AddWithValue("@loses", loses);
                    insertCmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving score: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = char.ToLower(e.KeyChar);

            if (keyChar >= 'a' && keyChar <= 'z')
            {
                string letter = keyChar.ToString();

                foreach (Control ctrl in pbl_Letters.Controls)
                {
                    if (ctrl is Button btn && btn.Text == letter)
                    {
                        if (btn.Enabled)
                        {
                            ProcessLetterGuess(letter);

                            btn.Enabled = false;
                        }

                        e.Handled = true;
                        break;
                    }
                }
            }
        }

        private void btn_ViewScoreboard_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreboardForm scoreboardForm = new ScoreboardForm();
                scoreboardForm.CurrentUserId = this.CurrentUserId;
                scoreboardForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening scoreboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //private void LoadScoreboard()
        //{
        //    try
        //    {
        //        conn.Open();

        //        // Create a command to get top scores
        //        SqlCommand cmd = new SqlCommand(
        //            "SELECT TOP 10 u.name, s.score " +
        //            "FROM scores s " +
        //            "JOIN [user] u ON s.user_id = u.id " +
        //            "ORDER BY s.score DESC", conn);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);

        //        // Clear existing items
        //        lstScoreboard.Items.Clear();

        //        // Add column headers
        //        lstScoreboard.Columns.Add("Rank", 40);
        //        lstScoreboard.Columns.Add("Player", 100);
        //        lstScoreboard.Columns.Add("Score", 60);

        //        // Add scores to the list view
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DataRow row = dt.Rows[i];
        //            ListViewItem item = new ListViewItem((i + 1).ToString());
        //            item.SubItems.Add(row["name"].ToString());
        //            item.SubItems.Add(row["score"].ToString());

        //            // Highlight current user
        //            if (row["name"].ToString() == CurrentUser)
        //            {
        //                item.BackColor = Color.LightYellow;
        //            }

        //            lstScoreboard.Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading scoreboard: " + ex.Message, "Database Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}



    }
}
