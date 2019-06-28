using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {

            logic.Init();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player who succeeds in placing " +
                "three of their marks in a horizontal, vertical, " +
                "or diagonal row wins the game.","Game rules");
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Slavik Kuz, 2017", "Credits");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MakeMove((PictureBox)sender);
        }

        private void MakeMove (PictureBox box)
        {
            int x, y;
            string tag = box.Tag.ToString();
            x = int.Parse(tag.Substring(0, 1));
            y = int.Parse(tag.Substring(1, 1));

            int turn = logic.turn;

            if (logic.PlaceTurn(x, y))
            {
                box.Image = (turn == 1) ? 
                    Properties.Resources.x : 
                    Properties.Resources.o;

                if (logic.finish != "play")
                    GameOver();
            }
        }

        private void GameOver()
        {
            switch(logic.finish)
            {
                case "winx": MessageBox.Show("X wins!", "Game over"); break;
                case "wino": MessageBox.Show("O wins!", "Game over"); break;
                case "draw": MessageBox.Show("Draw!", "Game over"); break;
                default: return;
            }
        }

        private void menuStartHuman_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void menuStartComp_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
