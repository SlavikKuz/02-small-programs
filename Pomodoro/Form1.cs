using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkTrin1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonTrinn1_Click(object sender, EventArgs e)
        {
            buttonTrinn1.Text = DateTime.Now.ToString("HH:MM");

            Timer t = new Timer();
            t.Interval = 15000;
            t.Start();
            
            MessageBox.Show(DateTime.Now.ToString("HH:MM"));

            // Wait for the user to hit <Enter>


        }
        private static void TimerCallback(Object o)
            {
                // Display the date/time when this method got called.
                Console.WriteLine("In TimerCallback: " + DateTime.Now);
                // Force a garbage collection to occur for this demo.
                GC.Collect();
            }
    }
}
