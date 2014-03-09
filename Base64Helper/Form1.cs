using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fromfileToToScreen();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) Console.WriteLine(file);

        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
            this.textBox1.Copy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFiledialog1.ShowDialog();
            if(result == DialogResult.OK) {
                System.IO.File.WriteAllBytes(saveFiledialog1.FileName, System.Text.UnicodeEncoding.UTF8.GetBytes(textBox1.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fromfileToToScreen();
            this.textBox1.SelectAll();
            this.textBox1.Copy();
        }

        private void fromfileToToScreen()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK) {
                this.textBox1.Text= Convert.ToBase64String(System.IO.File.ReadAllBytes(openFileDialog1.FileName));
           
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFiledialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                System.IO.File.WriteAllBytes(saveFiledialog1.FileName, Convert.FromBase64String(textBox1.Text));
            }
        }
    }
}
