using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fotoshop
{
    public partial class Input_Relief : Form
    {
        public Input_Relief()
        {
            InitializeComponent();
            this.SmerX = 0;
            this.SmerY = 0;
        }
        public int SmerX { get; set; }
        public int SmerY { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            SmerX = ToInt(textBox1.Text);
            SmerY = ToInt(textBox2.Text);
        }
        private static int ToInt(string s)
        {
            int n;
            if (!int.TryParse(s, out n))
            {
                MessageBox.Show("Nebylo vložené číslo!");
            }

            return n;
        }
    }
}
