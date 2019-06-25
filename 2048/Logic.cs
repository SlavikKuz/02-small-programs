using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Logic
    {
        int size = 4;
        int[,] map;
        DelegateShow show;
        bool moved = false;
        static Random rand = new Random();

        public Logic (int size, DelegateShow show)
        {
            this.size = size;
            map = new int[size, size];
            this.show = show;
        }

        public void InitGame()
        {
            for (int x=0; x<size; x++)
                for(int y=0; y<size; y++)
                {
                    map[x, y] = 0;
                    show(x, y, 0);
                }
            AddNumbers();
            AddNumbers();
        }

        public void ShiftLeft()
        {
            moved = false;
            for (int y = 0; y < size; y++)
            {
                Shift(size - 1, y, -1, 0);
                Combine(size - 1, y, -1, 0);
                Shift(size - 1, y, -1, 0);
            }
            if(moved)
            AddNumbers();
        }

        public void ShiftRight()
        {
            moved = false;
            for (int y = 0; y < size; y++)
            {
                Shift(0, y, 1, 0);
                Combine(0, y, 1, 0);
                Shift(0, y, 1, 0);
            }
            if (moved)
                AddNumbers();
        }

        public void ShiftUp()
        {
            moved = false;
            for (int x = 0; x < size; x++)
            {
                Shift(x, size - 1, 0, -1);
                Combine(x, size - 1, 0, -1);
                Shift(x, size - 1, 0, -1);
            }
            if (moved)
                AddNumbers();
        }

        public void ShiftDown()
        {
            moved = false;
            for (int x = 0; x < size; x++)
            {
                Shift(x, 0, 0, 1);
                Combine(x, 0, 0, 1);
                Shift(x, 0, 0, 1);
            }
            if (moved)
                AddNumbers();
        }

        public bool GameOver()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (map[x, y] == 0)
                        return false;

            for (int x = 0; x < size - 1; x++) //no similar number close to each other
                for (int y = 0; y < size - 1; y++)
                    if (map[x, y] == map[x + 1, y])
                        return false;
                    return true;
        }

        public void AddNumbers()
        {
            if (GameOver()) return;
            int x, y;
            do
            {
                x = rand.Next(0, size);
                y = rand.Next(0, size);
            }
            while (map[x, y] > 0);
            map[x, y] = rand.Next(1, 3) * 2;
            show(x, y, map[x, y]);

        }

        private void Shift(int x, int y, int sx, int sy)
        {
            if (x + sx < 0 || x + sx >= size || //borders of field
                y + sy < 0 || y + sy >= size)
                return;
          
                Shift(x + sx, y + sy, sx, sy);

            if (map[x + sx, y + sy] == 0 && map[x, y] > 0)
            {
                map[x + sx, y + sy] = map[x, y];
                map[x, y] = 0;
                show(x + sx, y + sy, map[x+sx, y+sy]);
                show(x, y, map[x,y]);

                Shift(x + sx, y + sy, sx, sy); //reccursion
                moved = true; //new numbers added only after a move
            }
        }

        public void Combine(int x, int y, int sx, int sy)
        {
            if (x + sx < 0 || x + sx >= size || //borders of field
                y + sy < 0 || y + sy >= size)
                return;

            Combine(x + sx, y + sy, sx, sy);

            if (map[x + sx, y + sy] > 0 &&
                map[x + sx, y + sy] == map[x,y])
            {
                map[x + sx, y + sy] *= 2;
                map[x, y] = 0;
                show(x + sx, y + sy, map[x + sx, y + sy]);
                show(x, y, map[x, y]);

                Shift(x + sx, y + sy, sx, sy); //reccursion
                moved = true;
            }
        }

    }
}
