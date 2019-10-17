using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel3.Show();
                panel1.Hide();
                panel2.Hide();

            }
            else
            {
                panel1.Show();
                panel3.Hide();
                panel2.Hide();
            }

        }
    }
}
