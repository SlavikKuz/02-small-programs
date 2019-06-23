using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pomodoro
{
    class Timer45
    {
        bool trinn;
        Stopwatch timer45;

        public Timer45()
        {
            trinn = false;
            timer45 = new Stopwatch();
        }

        Timer t = new Timer(TimerCallback, null, 0, 2000);
        // Wait for the user to hit <Enter>

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

    }
}
