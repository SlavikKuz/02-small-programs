using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Logic
    {
        Random rand = new Random();

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

        public void Comp(out int x, out int y)
        {
            x = 0;
            y = 0;

            if (step == 0) //first turn
            {
                int d = rand.Next(0, 5); //corners and center
                if (d == 0) { x = 1; y = 1; }
                if (d == 1) { x = 0; y = 0; }
                if (d == 2) { x = 0; y = 2; }
                if (d == 3) { x = 2; y = 0; }
                if (d == 4) { x = 2; y = 2; }
                    PlaceTurn(x, y);
                return;
            }

            if (step == 1) //second
            {
                if (map[1, 1] == 0) //if center is empty, take center
                {
                    x = 1;
                    y = 1;
                    PlaceTurn(x, y);
                } 

                else //any empty corner
                {
                    int d = rand.Next(1, 5);
                    if (d == 1) { x = 0; y = 0; }
                    if (d == 2) { x = 0; y = 2; }
                    if (d == 3) { x = 2; y = 0; }
                    if (d == 4) { x = 2; y = 2; }
                }
                return;
            }

            if (FindThree(turn, out x, out y))
                return;

            if (FindThree(3-turn, out x, out y))
                return;

            CompRandom(out x, out y);
        }

        private bool FindThree(int turn, out int x, out int y)
        {
            int nr;
            x = 0; y = 0;
            for (int n = 0; n < 3; n++)
            {
                if (ThreeInLine(turn, map[n, 0], map[n, 1], map[n, 2], out nr))
                {
                    x = n;
                    y = nr;
                    PlaceTurn(x, y);
                    return true;
                }
                if (ThreeInLine(turn, map[0, n], map[1, n], map[2, n], out nr))
                {
                    x = nr;
                    y = n;
                    PlaceTurn(x, y);
                    return true;
                }
            }

            if (ThreeInLine(turn, map[0, 0], map[1, 1], map[2, 2], out nr))
            {
                x = nr;
                y = nr;
                PlaceTurn(x, y);
                return true;
            }

            if (ThreeInLine(turn, map[2, 0], map[1, 1], map[0, 2], out nr))
            {
                x = 2 - nr;
                y = nr;
                PlaceTurn(x, y);
                return true;
            }
            return false;
        }


        private bool ThreeInLine(int s, int a, int b, int c, out int nr)
        {
            nr = 0;
            if (a == 0 && b == s && c == s)
            {
                nr = 0;
                return true;
            }

            if (a == s && b == 0 && c == s)
            {
                nr = 1;
                return true;
            }

            if (a == s && b == s && c == 0)
            {
                nr = 2;
                return true;
            }
            return false;
        }


        public void CompRandom (out int x, out int y)
        {
            int loop = 100;
            do
            {
                x = rand.Next(0, 3);
                y = rand.Next(0, 3);
            }
            while (map[x, y] > 0 && --loop > 0);

            PlaceTurn(x, y);
        }
    }
}
