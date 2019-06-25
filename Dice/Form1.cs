using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Dice
{
    public delegate void DelegateShow(int a, int b);


    public partial class Form1 : Form
    {
        OneDie dice1;
        OneDie dice2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init() //create new dices
        {
            dice1 = new OneDie(ShowBox);
            dice2 = new OneDie(ShowSum);

            //timer.Enabled = true; //timer is called after an object is created, everything is ready;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            dice1.Go();
            dice2.Go();
        }      

        private void ShowSum(int a, int b)
        {
            if(InvokeRequired)//acessing element from secondary thread, we organize the queue
            {
                DelegateShow show = ShowSum;
                Invoke(show, new object [] {a, b});//call delegate and pass parameters as an array;
                return;
            }

            int sum = a + b;
            labelSum.Text = "   "
                + a.ToString()
                + " : " 
                + b.ToString() 
                + "     "
                + "Sum: "
                + sum.ToString();
        }

        private void ShowBox(int a, int b)
        {
            if (InvokeRequired)//acessing element from secondary thread, we organize the queue
            {
                DelegateShow show = ShowBox;
                Invoke(show, new object[] { a, b });//call delegate and pass parameters as an array;
                return;
            }

            box1.Image = Box(a);
            box2.Image = Box(b);
        }

        private Image Box (int nr) //return picture
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1;
                case 2: return Properties.Resources._2;
                case 3: return Properties.Resources._3;
                case 4: return Properties.Resources._4;
                case 5: return Properties.Resources._5;
                case 6: return Properties.Resources._6;
            }
            return null;
        }
        
    }
}
