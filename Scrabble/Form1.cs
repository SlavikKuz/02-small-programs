using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        string[] words; // array for words from the library

        public Form1()
        {
            InitializeComponent();
            InitWords();
        }

        private void InitWords() //read from the library
        {
            words = File.ReadAllLines("Nouns.txt");
        }

        private void buttonPalindromes_Click(object sender, EventArgs e)
        {
            textWords.Text = ""; // empty textbox
            int count = 0;
            foreach(string word in words)
            {
                if (isPalindrome(word))
                {
                    textWords.Text += word + Environment.NewLine;
                    count++;
                }
            }
            labelNumberWords.Text = "Found: " + count.ToString(); //or text.Words.Lines.Count
        }

        private bool isPalindrome(string word)
        {
            int len = word.Length;
            for (int i = 0; i < len / 2; i++)
                if (word[i] != word[len - 1 - i])
                    return false;
            return true;
        }

        private void buttonSimple_Click(object sender, EventArgs e)
        {
            int count = 0;
            textWords.Text = ""; // empty textbox
            StringBuilder builtString = new StringBuilder(); //faster working then adding new string to textBox
            foreach (string word in words)
            {
                if (isGoFind(word, textLetters.Text))
                {
                    builtString.Append(word + Environment.NewLine);
                    count++;
                }
            }
            textWords.Text = builtString.ToString();
            labelNumberWords.Text = "Found: " + count.ToString();
        }

        private bool isGoFind(string word, string letters)
        {
            for (int i = 0; i < word.Length; i++)
                if (!letters.Contains(word.Substring(i, 1)))
                    return false;
            return true;

        }
    }
}
