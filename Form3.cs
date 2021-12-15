using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form3 : Form
    {
        int row = 8, column = 8, mines = 10;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                column = Int32.Parse(textBox2.Text);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{textBox2.Text}'");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                mines = Int32.Parse(textBox3.Text);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{textBox3.Text}'");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (row < 1 || column < 1 || row * column < 18 || mines > (column *row) / 2) {
                MessageBox.Show("Please enter proper values for rows, columns, and mines");
            }
            else
            {
                int size = Math.Min(30, 1000 / Math.Max(row, column));
                String text = "custom";
                Form2 f = new Form2(text, row, column, size, mines, "");
                f.Show();
               
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              
            try
            {
                row = Int32.Parse(textBox1.Text);
                
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{textBox1.Text}'");
            }
        }
    }
}
