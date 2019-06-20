using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PythonsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //removing static property 
            Program program = new Program();
            program.Start();
        }

        public void Start()
        {
            Python.InitScreen();

            for (int i = 0; i < 50; i++)
                Python.AddHare();

            int max = 10; //max number pythons
            Python[] p = new Python[max];
            Thread[] t = new Thread[max];

            for (int j = 0; j < max; j++)
            {
                p[j] = Python.Create();
                t[j] = new Thread(p[j].Run);
                t[j].IsBackground = true; //kill threads on keypress
                t[j].Start();
            }

            while (true) //stop a thread, freeze selected python
                //key value to kill thread
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar >= '0' && key.KeyChar <= '9')
                    t[Convert.ToInt16(key.KeyChar.ToString())].Abort();
            }
        }
    }
}
