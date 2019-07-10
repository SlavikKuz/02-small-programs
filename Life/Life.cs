using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Life
    {
        int[,] field; // 0 - empty, 1 - lifeform, -1 - newborn, 2 - dead
        int[,] sum; // number og lifeforms to the right and down from the cell 
        int width, height;
        Random random;

        public Life(int w, int h) //creates array of empty cells
        {
            this.width = w;
            this.height = h;
            field = new int [width, height];
            sum = new int[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    field[i, j] = 0; //every cell is unpopulated
        }  

        public int SwitchField (int x, int y)//empty cell becomes 1 and vice versa
        {
            field[x, y] = field[x, y] == 0 ? 1 : 0;
            return field[x, y];
        }

        public int ReadField (int x, int y)//cell value becomes 0, if dead or out of borders
        {
            if (x < 0 || x >= width)
                return 0;
            if (y < 0 || y >= height)
                return 0;
            return field[x, y]; 
        }

        public int ReadSum(int x, int y)//sum of lifeforms
        {
            if (x >= width)
                return 0;
            if (y >= height)
                return 0;
            if (x < 0) x=0;
            if (y < 0) y=0;// borders of field reached
            return sum[x, y];
        }

        public void Contamine()
        {
            random = new Random();
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = random.Next(100) % 2;//generate 1 and 0
                    if (i * j % 3 == 1 || i * j % 5 == 1) //remove some cells
                        field[i, j] = 0;
                }
        }

        //ordinary logic for surrounding cells
        //public int Surround(int x, int y)
        //{
        //    int sum = 0;
        //    for (int ax = -1; ax <= 1; ax++)
        //        for (int ay = -1; ay <= 1; ay++)
        //            if (ReadField(x + ax, y + ay) > 0)
        //                sum++;
        //    return sum;
        //}

        public int Surround2(int x, int y)//select middle cell in 3x3 and summs of fields
        {
            return ReadSum(x-1, y-1) -
                ReadSum(x + 2, y-1) -
                ReadSum(x-1, y + 2) +
                ReadSum(x + 2, y + 2);
        }

        private void Prepare()//summs
        {
            for (int x = width - 1; x >= 0; x--)
                for (int y = height - 1; y >= 0; y--)
                {
                    sum[x, y] = ReadField(x,y)+
                        ReadSum(x + 1, y) + 
                        ReadSum(x, y + 1) - 
                        ReadSum(x + 1, y + 1);
                }
        }
       
        public void FaseOne() //mark newborn and dead
        {
            Prepare();
            for (int i=0; i<width;i++)
                for (int j=0; j<height; j++)
                {
                    int a = Surround2(i, j);
                    if (field[i,j]==1)
                    {
                        if (a <= 2)
                            field[i, j] = 2; //alone
                        if (a >= 5)
                            field[i, j] = 2; //overcrowded
                    }
                    else
                    {
                        if (a == 3)
                            field[i, j] = -1; //newborn
                    }
                }
        }

        public void FaseTwo() //remove dead and place newborn
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j] == -1)
                        field[i, j] = 1;
                    else if (field[i,j]== 2)
                        field[i, j] = 0;
                }
                   
        }

    }
}
