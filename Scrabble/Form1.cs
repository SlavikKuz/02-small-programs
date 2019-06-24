using System;
using System.IO;
using System.Linq;
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

        string abc = "qwertyuiopasdfghjklzxcvbnm";
        int[] usedLetters;

        private int[] CheckGivenLetters(string letters)
        {
            int[] used = new int[abc.Length];
            for (int i = 0; i < letters.Length; i++)
                used[abc.IndexOf(letters[i])]++;
            return used;
        }

        //find words with exact letters

        //private void buttonGoFind_Click(object sender, EventArgs e)
        //{
        //    int count = 0;
        //    textWords.Text = ""; // empty textbox
        //    StringBuilder builtString = new StringBuilder(); //faster working then adding new string to textBox

        //    usedLetters = CheckGivenLetters(textLetters.Text);

        //    foreach (string word in words)
        //    {
        //        //if(word.Length == textLetters.Text.Length) //only words with all given letters
        //            if (isGoFind2(word))
        //            {
        //                builtString.Append(word + Environment.NewLine);
        //                count++;
        //            }
        //    }
        //    textWords.Text = builtString.ToString();
        //    labelNumberWords.Text = "Found: " + count.ToString();
        //}

        //private bool isGoFind2(string word)// word consits only of given letters 
        //{
        //    int[] letters = CheckGivenLetters(word);
        //    for (int i = 0; i < letters.Length; i++)
        //        if (usedLetters[i] != letters[i])
        //            return false;
        //        return true;

        //}

        private void buttonAnagram_Click(object sender, EventArgs e) //words with the same letters
        {
            textWords.Text = "";
            int count = 0;
            for (int w1 = 0; w1 < words.Length; w1++)
            {
                int[] w1Letters = CheckGivenLetters(words[w1]);
                for (int w2 = w1 + 1; w2 < words.Length; w2++)
                    if (words[w1].Length == words[w2].Length)
                    {
                        int[] w2Letters = CheckGivenLetters(words[w2]);
                        if (Enumerable.SequenceEqual(w1Letters, w2Letters))
                        {
                            textWords.Text += words[w1] + " - " + words[w2] + Environment.NewLine;
                            count++;
                        }
                    }
            }
            labelNumberWords.Text = "Found: " + count.ToString();
        }
    }
}
