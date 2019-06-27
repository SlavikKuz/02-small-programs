using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            bool? res = sfd.ShowDialog(); //bool can be null

            if (res != false)
            {

                using (Stream s = File.Open(sfd.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(TextBox.Text);
                    }
                }
            }
        }

private void OpenNewFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? res = ofd.ShowDialog();
            
            if (res != false)
            {
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string fileName = ofd.FileName;
                    string fileText = File.ReadAllText(fileName);
                    TextBox.Text = fileText;
                }
            }
        }

        private void CreateNewFile_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.Text != "")
                SaveFile();
            TextBox.Text = "";
        }

        private void TimesNewRomanFont_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontFamily = new FontFamily("Times New Roman");
            verdanaFont.IsChecked = false;
        }

        private void VerdanaFont_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontFamily = new FontFamily("Verdana");
            timesNewRomanFont.IsChecked = false;
        }

        private void SelectFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = selectFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);

            switch (fontSize)
            {
                case  "8": TextBox.FontSize = 8; break;
                case "10": TextBox.FontSize = 10; break;
                case "12": TextBox.FontSize = 12; break;
                case "14": TextBox.FontSize = 14; break;
                case "16": TextBox.FontSize = 16; break;
                case "20": TextBox.FontSize = 20; break;
                case "24": TextBox.FontSize = 24; break;
                case "28": TextBox.FontSize = 28; break;
                case "36": TextBox.FontSize = 36; break;
            }
        }
    }
}
