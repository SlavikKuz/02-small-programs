using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Logic
    {
        int[,] map = new int[3, 3]; //0 mepty, 1 is X, 2 is 0;
        public int turn { get; private set; } //which turn is it;
        bool play;
        int step; //counts turns
        public string finish { get; private set; } //status of game

        public Logic()
        {
            Init();
        }

        public void Init()
        {
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    map[x, y] = 0;
            turn = 1;
            play = true;
            step = 0;
        }

        public bool PlaceTurn(int x, int y) //checks if the cell is empty, borders of the field;
        {
            if (!play) return false;

            if (x < 0 || x > 2) return false;
            if (y < 0 || y > 2) return false;
            if (map[x, y] > 0) return false;

            map[x, y] = turn;
            step++;

            finish = Finish(x, y);

            turn = 3 - turn;
            return true;
        }

        private string Finish(int x, int y)
        {
            bool win = false;

            if (map[x, 0] == turn && map[x, 1] == turn && map[x, 2] == turn) //horisontals
                win = true;

            if (map[0, y] == turn && map[1, y] == turn && map[2, y] == turn) //verticals
                win = true;

            if (map[0, 0] == turn && map[1, 1] == turn && map[2, 2] == turn) //diagonally
                win = true;

            if (map[2, 0] == turn && map[1, 1] == turn && map[0, 2] == turn)
                win = true;

            if (win)
            {
                if (turn == 1)
                {
                    play = false;
                    return "winx";
                }
                else
                {
                    play = false;
                    return "wino";
                }
            }
            else
            {
                if (step == 9)
                {
                    play = true;
                    return "draw";
                }
                else
                {
                    play = true;
                    return "play";
                } 

            }
        }
    }
}
