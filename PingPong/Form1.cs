using System;
using System.Drawing;
using System.Windows.Forms;

namespace PingPong
{
    public partial class PingPong : Form
    {
        private int speed_v = 3;
        private int speed_h = 3;
        private int score = 0;


        public PingPong()
        {
            InitializeComponent();

            timer1.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamePanel.Top = field.Bottom - (field.Bottom / 10);
        }

        private void PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            ball.Left += speed_h;
            ball.Top += speed_v;

            if (ball.Left <= field.Left)
                speed_h *= -1;

            if (ball.Right >= field.Right)
                speed_h *= -1;

            if (ball.Top <= field.Top)
                speed_v *= -1;

            if (ball.Bottom >= field.Bottom)
            { timer1.Enabled = false;
                MessageBox.Show("Game Over! :(");
                this.Close();
            }

            if (ball.Bottom >= gamePanel.Top && 
                ball.Bottom <= gamePanel.Bottom &&
                ball.Left >= gamePanel.Left &&
                ball.Right <= gamePanel.Right)
            {
                speed_h += 1;
                speed_v += 1;
                speed_v *= -1;
                score += 1;

                Result.Text = "Score: " + score.ToString();

                Random rand = new Random();
                field.BackColor = Color.FromArgb(rand.Next(0,255), rand.Next(0, 255), rand.Next(0, 255));
            }
                
        }
    }
}
