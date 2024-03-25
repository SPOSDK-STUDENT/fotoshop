using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fotoshop
{
    public partial class Text : Form
    {
        public Text(BitovaMapa bitm)
        {
            InitializeComponent();
            btm = bitm;
        }

        BitovaMapa btm = new BitovaMapa();
        private void Text_Load(object sender, EventArgs e)
        {
            string textOutput = "";
            for (int j = 0; j < btm.bitmap.Height; j++)
            {
                for (int i = 0; i < btm.bitmap.Width; i++)
                {

                    Color pixel = btm.bitmap.GetPixel(i, j);
                    int light = btm.svetelnost(pixel);
                    if (light < 20)
                    {
                        textOutput += "  ";
                    }
                    else if (light < 60)
                    {
                        textOutput += "..";
                    }
                    else if (light < 100)
                    {
                        textOutput += ";;";
                    }
                    else if (light < 150)
                    {
                        textOutput += "II";
                    }
                    else if (light < 200)
                    {
                        textOutput += "OO";
                    }
                    else
                    {
                        textOutput += "WW";
                    }
                }
                textOutput += "\r\n";
            }
            richTextBox1.Text = textOutput;
            string nega = btm.CestaKBitmape;
            int g = nega.IndexOf('.');
            if (g <= 0) nega = nega.Substring(g + 1);
            File.WriteAllText((nega) + ".txt", textOutput);
        }

        private void Text_Resize(object sender, EventArgs e)
        {
            richTextBox1.Size = new Size(this.Width - 20, this.Height - 20);
        }
    }
}
