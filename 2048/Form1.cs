using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{

    public delegate void DelegateShow(int x, int y, int number);

    public partial class Form1 : Form
    {
        static int size = 4; //max field size
        Label[,] box;
        Dictionary<int, Color> back_colors;
        Logic logic;

        public Form1()
        {
            InitializeComponent();
            InitBackColors();
            InitLabels();
            logic = new Logic(size, Show);
            logic.InitGame();
        }

        private void InitBackColors()//color generator;
        {
            back_colors = new Dictionary<int, Color>();
            back_colors.Add(0, this.BackColor);
            byte r = 95;
            byte g = 255;
            byte b = 155;

            for (int i=1; i<=65536*2;i*=2)
            {
                back_colors.Add(i, Color.FromArgb(r, g, b));
                r -= 4;
                g -= 10;
                b -= 4;
            }
        }

        private void InitLabels()
        {
            int w = panel1.Width / size;
            int h = panel1.Height / size;

            box = new Label[size, size];
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    box[x, y] = CreateLabel();
                    box[x, y].Size = new System.Drawing.Size(w - 4, h - 4);
                    box[x, y].Location = new Point(x * w + 4, y * h + 4);
                    panel1.Controls.Add(box[x, y]);
                    //tableLayoutPanel1.Controls.Add(box[x,y],x,y);
                }
        }

        private Label CreateLabel()
        {
            Label label = new Label();
            label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            //label.Dock = System.Windows.Forms.DockStyle.Fill;
            //label.Margin = new System.Windows.Forms.Padding(4);
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Text = "-";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }

        public void Show(int x, int y, int number)//draw label number
        {
            box[x, y].Text = number > 0 ? number.ToString() : "";
            box[x, y].BackColor = back_colors[number];
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left: logic.ShiftLeft();  break;
                case Keys.Right: logic.ShiftRight();  break;
                case Keys.Up: logic.ShiftUp();  break;
                case Keys.Down: logic.ShiftDown(); break;
                case Keys.Escape: logic.InitGame(); break;
                default: break;
            }
            if(logic.GameOver())
            {
                MessageBox.Show("Game over! :(");
                logic.InitGame();
            }
        }
    }
}
