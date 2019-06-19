using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Matrix_Screen
{
    class Matrix
    {
        static readonly object locker = new object();

        Random rand;

        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public int Column { get; set; }

        public bool AddSecondLine { get; set; } //if we need more chains in a column

        public Matrix(int col, bool addSecond)
        {
        Column = col;
        rand = new Random((int) DateTime.Now.Ticks);
        AddSecondLine = addSecond;
        }

        private char GetLetter()
        {
            return letters.ToCharArray()[rand.Next(0, 35)];
        }

        public void Move()
        {
            int length; //of each line
            int count;
            while(true)
            {
                count = rand.Next(3, 12); //number of lines
                length = 0;
                Thread.Sleep(rand.Next(20, 1000)); // sleep for every line

                for (int i=0; i<40; i++) // 40 is hight of screen in symbols 
                {
                    lock(locker) // only one thread can perform it
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;

                        for (int j=0; j<i; j++)//fill with column on scree with black color symbol
                        {
                            Console.CursorLeft = Column;
                            Console.WriteLine("█");
                        }

                        if (length < count) //adds +1 to the actual length of chain, until random generated length
                            length++;
                        else
                            if (length == count)
                            count = 0;

                        if(AddSecondLine && i<20 && i>length + 2 && (rand.Next(1,5)==3))
                            //if we need it, enough room, and chance of creatinn
                        {
                            new Thread((new Matrix(Column, false)).Move).Start();
                            AddSecondLine = false; //no more chains. stops recursion
                        }


                        if (39 - i < length) //if chain hits the top border of screen, it cuts off
                            length--;

                        Console.CursorTop = i - length + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j=0; j<length -2; j++) //add all chars but last two in color DG
                        {
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetLetter());
                        }
                        if (length>=2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; //add 2 last chars in green
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetLetter());
                        }
                        if (length >=1)
                        {
                            Console.ForegroundColor = ConsoleColor.White; //last symbol is white
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetLetter());
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 32);

            Matrix instance;

            for (int i=0; i<26; i++)
            {
                instance = new Matrix(i * 3, true);
                new Thread(instance.Move).Start();
            }

            Console.ReadKey();
        }
    }
}
