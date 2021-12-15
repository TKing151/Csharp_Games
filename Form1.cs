using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        int gcount = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Play(object sender, EventArgs e)
        {
            int row = 0, col = 0, mines = 0;//row*col >=18, mines <= row*col/2
            String text = "";
            Form2 f = null;
            if (easy.Checked)
            {
                row = col = 9;
                mines = 10;
                text = "Easy";
            }
            else if (medium.Checked)
            {
                row = col = 16;
                mines = 40;
                text = "Medium";
            }
            else if (expert.Checked)
            {
                row = 30;
                col = 16;
                mines = 99;
                text = "Expert";
            }
            else
                return;
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           for (int i = 0; i < 6; i++)
            {
                try
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Form2)
                        {

                            f.Close();
                        }
                    }
                }
                catch (InvalidOperationException ne)
                {

                }
            }
            gcount = 0;
            label1.Text = "Number of open games: " + gcount.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            if (radioButton1.Checked)
            {

                f.Show();
            }
            else f.Close();
        }

        private void hIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = 0, col = 0, mines = 0;//row*col >=18, mines <= row*col/2
            String text = "";
            Form2 f = null;
            if (easy.Checked)
            {
                row = col = 9;
                mines = 10;
                text = "Easy";
            }
            else if (medium.Checked)
            {
                row = col = 16;
                mines = 40;
                text = "Medium";
            }
            else if (expert.Checked)
            {
                row = 30;
                col = 16;
                mines = 99;
                text = "Expert";
            }
            else
                return;
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();

        }

        private void byToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // lock (Application.OpenForms)
           for(int i = 0; i < 6; i++) { 
                try
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Form2)
                        {

                            f.Close();
                        }
                    }
                }
                catch (InvalidOperationException ne)
                {
                    
                }
            }
            gcount = 0;
            label1.Text = "Number of open games: " + gcount.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = 0, col = 0, mines = 0;//row*col >=18, mines <= row*col/2
            String text = "";
            Form2 f = null;
            row = col = 9;
            mines = 10;
            text = "Easy";
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = 0, col = 0, mines = 0;
            String text = "";
            Form2 f = null;
            row = col = 16;
            mines = 40;
            text = "Medium";
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = 0, col = 0, mines = 0;
            String text = "";
            Form2 f = null;
            row = 30;
            col = 16;
            mines = 99;
            text = "Expert";
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();
        }
        String name = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int row = 0, col = 0, mines = 0;//row*col >=18, mines <= row*col/2
            String text = "";
            Form2 f = null;
            if (easy.Checked)
            {
                row = col = 9;
                mines = 10;
                text = "Easy";
            }
            else if (medium.Checked)
            {
                row = col = 16;
                mines = 40;
                text = "Medium";
            }
            else if (expert.Checked)
            {
                row = 30;
                col = 16;
                mines = 99;
                text = "Expert";
            }
            else
                return;
            int size = Math.Min(30, 1000 / Math.Max(row, col));
            f = new Form2(text, row, col, size, mines, name);
            f.Show();
            gcount++;
            label1.Text = "Number of open games: " + gcount.ToString();

        
    }

        
    }
}
