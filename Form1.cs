using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6_Draft
{
    public partial class Form1 : Form
    {
        public int promo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            promo = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            promo = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            promo = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            promo = 3;
        }
    }
}
