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
        public Input_Relief(int a)
        {
            InitializeComponent();
            this.SmerX = 0;
            this.SmerY = 0;
            switch (a)
            {
                case 0:
                    label1.Text = "Směr X"; label3.Text = "Určuje směr ze strany na stranu";
                        label4.Text = "Základní: -4 pro zleva, 4 pro zprava";

                    label2.Text = "Směr Y"; label5.Text = "Určuje směr ze shora-zdola";
                        label6.Text = "Základní: -2 pro shora, 2 pro zdola";

                    label8.Text = "Moc velká čísla způsobí nefunkčnost filtru";
                    label7.Text = "Hodnoty, které nejsou číslo budou 0";
                    break;
                case 1:
                    label1.Text = "Velikost X"; label3.Text = "Určuje šířku";
                    label4.Text = "";

                    label2.Text = "Velikost Y"; label5.Text = "Určuje výšku";
                    label6.Text = "";

                    label8.Text = "";
                    label7.Text = "Hodnoty, které nejsou číslo budou 0";
                    break;
            }
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
