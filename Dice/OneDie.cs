using System;
using System.Threading;

namespace Dice
{
    class OneDie
    {
        int a; //dice 1;
        int b; //dice 2;

        static Random rand = new Random(); //otherwise the same numbers;
        DelegateShow Show; //we change class behaviour only passing different function, not changing class;
        Thread thread;

        public OneDie(DelegateShow show)
        {
            this.Show = show;
            thread = new Thread(Run); //method Run
            thread.Start();
            thread.IsBackground = true; //to stop
        }

        public void Go()
        {
            a = rand.Next(1, 7); //Max value is 7-1;
            b = rand.Next(1, 7);
            Show(a, b);
        }

        public void Run()//endless
        {
            while(true)
            {
                Go();
                Thread.Sleep(1000);
            }
        }
    }
}
