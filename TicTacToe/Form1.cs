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
        bool useComp = false;

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
                {
                    GameOver();
                    return;
                }

                if(useComp)
                    CompMakeTurn();
            }
        }

        private void CompMakeTurn()
        {
            int turn = logic.turn;
            int x, y;
            logic.Comp(out x, out y);
            Picture(x, y).Image = (turn == 1) ?
                Properties.Resources.x :
                Properties.Resources.o;

            if (logic.finish != "play")
            {
                GameOver();
                return;
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
            useComp = true;
            StartGame();
        }

        private void menuComputerX_Click(object sender, EventArgs e)
        {
            useComp = true;
            StartGame();
            CompMakeTurn();
        }

        private PictureBox Picture(int x, int y)
        {
            if (x == 0 && y == 0) return pictureBox1;
            if (x == 0 && y == 1) return pictureBox2;
            if (x == 0 && y == 2) return pictureBox3;
            if (x == 1 && y == 0) return pictureBox4;
            if (x == 1 && y == 1) return pictureBox5;
            if (x == 1 && y == 2) return pictureBox6;
            if (x == 2 && y == 0) return pictureBox7;
            if (x == 2 && y == 1) return pictureBox8;
            if (x == 2 && y == 2) return pictureBox9;
            return null;
        }
    }
}
