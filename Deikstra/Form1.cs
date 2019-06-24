using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deikstra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "RPNotation";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = RPNotation(richTextBox1.Text).ToString();
        }

        public string RPNotation(string input_string)
        {
            string[] output_string = new string[0];//output line
            string[] stack = new string[0];//stack

            int k = 0;
            for (int i = 0; i < input_string.Length; i++)
            {
                string temp = "";// number storage variable
                if (Char.IsDigit(input_string[i]))
                {
                    //all digits of a number are written to the temp variable,
                    //since the number may have more than one digit
                    while (i < input_string.Length && Char.IsDigit(input_string[i]))
                        temp += input_string[i++].ToString();
                    i--;
                    Array.Resize(ref output_string, output_string.Length + 1);
                    //output string array is incremented by one

                    output_string[output_string.Length - 1] = temp;
                    //adding a number to the current output line
                }
                if (input_string[i] == '+' || input_string[i] == '-')
                {
                    m:// + and - have the lowest priority. When we write these operands to the stack
                      //all other operations from the stack should move to the output line.
                      //Exception is bracket

                    if (stack.Length != 0) //if the stack is not yet empty
                    {
                        if (stack[stack.Length - 1] == "(")
                            //if the last item in the stack is an opening bracket
                        {
                            Array.Resize(ref stack, stack.Length + 1);
                            stack[stack.Length - 1] = input_string[i].ToString();
                            //then we put in the stack + or - operation
                        }
                        else
                        {
                            Array.Resize(ref output_string, output_string.Length + 1);
                            output_string[output_string.Length - 1] = stack[stack.Length - 1];
                            //the last operation from the stack is added to the output line
                            Array.Resize(ref stack, stack.Length - 1);
                            //the last element is removed from the stack
                            goto m;
                            //return to check whether there is another operation on top of the stack
                        }
                        stack[stack.Length - 1] = input_string[i].ToString();
                        //at the top of the stack is placed the operation + or -
                    }
                    else
                    {
                        Array.Resize(ref stack, stack.Length + 1);
                        stack[stack.Length - 1] = input_string[i].ToString();
                        //if the stack is not empty, + or - operation is added
                    }
                }
                if (input_string[i] == '*' || input_string[i] == '/')
                {
                    if (stack.Length != 0)//if the stack is not yet empty
                    {
                        if (stack[stack.Length - 1] != "*" && stack[stack.Length - 1] != "/")
                        //if at the top of the stack is not found * or /
                        {
                            Array.Resize(ref stack, stack.Length + 1);
                            stack[stack.Length - 1] = input_string[i].ToString();
                        }
                        else  //if at the top of the stack is * or /
                              //then because operations priorities are the same
                              //an element from the top of the stack is passed to the output string (array)
                        {
                            Array.Resize(ref output_string, output_string.Length + 1);
                            output_string[output_string.Length - 1] = stack[stack.Length - 1];
                            stack[stack.Length - 1] = input_string[i].ToString();
                            //the current multiply or divide operation is placed at the top of the stack
                        }
                    }
                    else
                    {
                        Array.Resize(ref stack, stack.Length + 1);
                        stack[stack.Length - 1] = input_string[i].ToString();
                        //if the stack is not empty, then * or / is added to the stack
                    }
                }
                if (input_string[i] == '(')
                //an opening bracket that is automatically added to the stack
                {
                    Array.Resize(ref stack, stack.Length + 1);
                    stack[stack.Length - 1] = input_string[i].ToString();
                }
                if (input_string[i] == ')') //closing bracket
                {
                    int k_t = stack.Length - 1;
                    while (stack[k_t] != "(")//moving left, searching for opening brackets
                        k_t--;//the index of the opening bracket
                    int j;
                    for (j = k_t + 1; j < stack.Length; j++)
                    {
                        Array.Resize(ref output_string, output_string.Length + 1);
                        output_string[output_string.Length - 1] = stack[j];
                    }
                    Array.Resize(ref stack, stack.Length - j);
                    //the stack is reduced by the number of transferred operations
                }
                if (input_string[i] == '^')
                //it has the highest priority, it is automatically added to the output line
                {
                    Array.Resize(ref stack, stack.Length + 1);
                    stack[stack.Length - 1] = input_string[i].ToString();
                }
            }
            //combine the output string with the stack
            Array.Resize(ref output_string, output_string.Length + stack.Length);
            Array.Reverse(stack);
            for (int i = output_string.Length - stack.Length; i < output_string.Length; i++)
                output_string[i] = stack[k++];
            string t = "";
            //formed from the output a string
            for (int i = 0; i < output_string.Length; i++)
                if (i != output_string.Length - 1)
                    t += output_string[i] + " ";
                else
                    t += output_string[i];
            return t;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
