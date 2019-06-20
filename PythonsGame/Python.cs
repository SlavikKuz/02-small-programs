using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PythonsGame
{
    public struct Coord
        //coodinates for moving python
    {
        public int x;
        public int y;

        public Coord (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //NB! new syntax
        public static Coord operator + (Coord c1, Coord c2)
        {
            return new Coord(c1.x + c2.x, c1.y + c2.y);
        }
    }

    class Python
    {
        public static readonly Coord size = new Coord(60, 24); //const field
        public static readonly char aNone = ' '; //empty space
        public static readonly char aWall = '#'; // wall as an obastacle
        public static readonly char aBody = 'O'; // body of a python
        public static readonly char aHare = '"'; // game as a hare
        public static readonly char poisn = '+'; // kills a python
        public static readonly char [] aHead = new char[] {'<','>','^','v', }; // python head directions

        private static char[,] screen = new char[size.x, size.y];
        private static Random random = new Random();
        private static object block = new object();

        private static int number = 0;

        public static void InitScreen() //static is done only once
        {
            for (int x = 0; x < size.x; x++) //frame of the field
                for (int y = 0; y < size.y; y++)
                    if (x * y == 0 || x == size.x - 1 || y == size.y - 1)
                        PutScreen(new Coord(x, y), ConsoleColor.DarkGray, aWall); //walls
                    else
                        PutScreen(new Coord(x, y), ConsoleColor.DarkGray, aNone); //free space
        }

        private static void PutScreen(Coord coord, ConsoleColor color, char a)//build screed
        {
            //Monitor.Enter(block);
            lock (block)
            {
                if (!OnScreen(coord))
                    return;
                screen[coord.x, coord.y] = a;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(coord.x, coord.y);
                Console.Write(a);
            }
            //Monitor.Exit(block);
        }

        public static void AddHare()
        {
            if (random.Next(10) != 1)//less rabbits
                return;

            Coord hare;

            int loop = 50; //50 efforts to try cell, if can't find empty cell, loop aborts

            do
                hare = RandomCoord();
            while (!IsEmpty(hare) && --loop>0);
            if (loop > 0)
                if (random.Next(100) == 0)
                    PutScreen(hare, ConsoleColor.Red, poisn);
                else
                    PutScreen(hare, ConsoleColor.Gray, aHare);
        }

        public static Coord RandomCoord() //random coodinates
        {
            return new Coord(random.Next(0, size.x), random.Next(0, size.y));
        }

        public static bool IsEmpty(Coord coord) //checking if the cell is empty
        {
            char c = Screen(coord);
            return (c == aNone || c == aHare || c== poisn);
        }

        public static char Screen(Coord coord) //returns coordinates or wall
        {
            if (!OnScreen(coord))
                return aWall;
            return screen[coord.x, coord.y];
        }

        public static bool OnScreen(Coord coord)//if coordinate of the field
        {
            return (coord.x >= 0 && coord.x < size.x &&
                coord.y >= 0 && coord.y < size.y);
        }

        public enum Arrow //dirrection that python moves
        {
            L = 0,
            R = 1,
            U = 2,
            D = 3
        };

        Coord head;
        Arrow arrow;
        Coord step; //where it goes
        ConsoleColor color; //python color
        Queue<Coord> body; //body does not change, only head and tail changes
        bool dead;
        int grow;//body grows
        int nr;

        public static Python Create()
        {
            Coord start;
            int loop = 50;
            do
                start = RandomCoord();
            while (!IsEmpty(start) && --loop > 0);
            if (loop <= 0)
                return null;
            Python python = new Python(start);
            python.nr = number;
            number++;
            return python;
        }

        private Python(Coord start)
        {
            this.head = start;
            this.body = new Queue<Coord>();
            body.Enqueue(head);
            this.color = (ConsoleColor)random.Next(1, 15); //various collor
            TurnTo(Arrow.R); //initial head position
            grow = 0;//born only head
            dead = false; //it's ALIVE! ALIVE!
        }

        private void TurnTo(Arrow arrow)
        {
            if (this.arrow == arrow)
                return;
            this.arrow = arrow;
            step.x = 0;
            step.y = 0;
            switch(arrow)
            {
                case Arrow.L: step.x = -1; break;
                case Arrow.R: step.x = +1; break;
                case Arrow.U: step.y = -1; break;
                case Arrow.D:
                default: step.y = +1; break;
            }
        }

        private void Turn() //can only turn if empty, and sometimes randomly. In 90% turns
        {
            if (random.Next(10) > 0)
                if(IsEmpty(head + step))
                return;
            for (int j = 0; j < 10; j++)
            {
                TurnTo((Arrow)random.Next(0, 4));
                if (IsEmpty(head + step))
                    return;
            }
        }

        private void ShowMe(Coord cHead, Coord cBody, Coord cNone)
        {
            PutScreen(cBody, color, aBody); //draw body
            PutScreen(cHead, color, aHead[(int)arrow]); //draw head
            PutScreen(cNone, color, aNone); //put empty when python has gone
        }

        public void Step() //if we cant turn, return head coords
            {
                Turn();
                Coord nextHead = head + step;

            if (IsEmpty(nextHead) && !dead)//if still alive. dies after exception
                body.Enqueue(nextHead);
            else
                nextHead = head;

            if (Screen(nextHead) == aHare) //if head hits a game then pyhon grows
                grow++;
            if (Screen(nextHead) == poisn) //if head hits a poison
                dead = true;

            Coord none = new Coord(-1, -1); //fake coord to cut the tail

            if(body.Count >1)
            {
                if (grow > 0)
                    grow--;
                else
                    none = body.Dequeue();//when head can't move
            }

            ShowMe(nextHead, head, none); //replace head
            head = nextHead;
         
            }

        private void Info()
        {
            lock (block)
            {
                Console.SetCursorPosition(size.x + 2, nr);
                Console.ForegroundColor = color;
                Console.Write("#" + Thread.CurrentThread.ManagedThreadId+" " + body.Count);// thread id
            }
        }

        public void Run()//endless process
        {
            while (true)
            {
                try
                {
                    while (true)
                    {                        
                        Step();
                        AddHare();
                        Info();
                        Thread.Sleep(50);
                        PutScreen(head, color, aNone);
                        if (dead && body.Count <= 1)
                            return;
                    }
                }
                catch (ThreadAbortException ex)//kills python
                {
                    dead = true;
                    Thread.ResetAbort();
                    //Thread.Sleep(5000); //freeze 5 sec
                }
            }
        }
    }
}
