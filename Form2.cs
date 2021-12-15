using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA5_Draft
{
    public partial class Form2 : Form
    {
        public int numapples = 1;
        public Form2()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0) { numapples = (int)numericUpDown1.Value; }
        }

        
    }
}
