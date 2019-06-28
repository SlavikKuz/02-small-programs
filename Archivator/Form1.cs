using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivator
{
    public delegate void DelegateSetError(string message);

    public partial class Arch : Form
    {
        Archiver archiver;

        public Arch()
        {
            InitializeComponent();
            archiver = new Archiver(SetError); //passing method via delegate
        }

        public void SetError (string message)//show error on label
        {
            label1.Text = message;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //opens new file dialog. Press OK
            {
                archiver.Create(save.FileName);
                labelFileName.Text = save.FileName;
                ReloadNames();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK) //opens new file dialog. Press OK
            {
                archiver.Open(open.FileName);
                ReloadNames();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                archiver.AddFile(open.FileName); //file without path
                ReloadNames();
            }
        }

        private void ReloadNames()
        {
            List<string> list = archiver.GetNames();
            listFiles.Clear();
            foreach (string name in list)
            {
                listFiles.Items.Add(name);
            }
        }

        private void buttonExctract_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Application.StartupPath;
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                archiver.ExtractFiles(folder.SelectedPath);
            }
        }
    }
}
