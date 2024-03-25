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
    public partial class Puzzle : Form
    {
        public Puzzle(BitovaMapa bitm, int sz)
        {
            InitializeComponent();
            btm = bitm;
            size = sz;
        }
        BitovaMapa btm;
        int size;
        private void Puzzle_Load(object sender, EventArgs e)
        {
            Panel[,] panelArray = new Panel[size, size];
            Size btmSize = new Size(btm.bitmap.Width / size, btm.bitmap.Height / size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    panelArray[i, j] = new Panel(); panelArray[i, j].Location = new Point(i * btmSize.Width, j * btmSize.Height);
                    panelArray[i, j].Size = btmSize;
                    panelArray[i, j].BackgroundImage = btm.bitmap.Clone(new Rectangle(new Point(i * btmSize.Width, j * btmSize.Height), btmSize), btm.bitmap.PixelFormat);
                    this.Controls.Add(panelArray[i, j]);
                }
            }
            panelArray = Shuffle(panelArray);
        }
        Panel[,] Shuffle(Panel[,] panelArray)
        {
            panelArray = Switch(panelArray, new Point(0, 0), new Point(2, 2));
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    
                }
            }
            return panelArray;
        }
        Panel[,] Switch(Panel[,] panelArray, Point panelToSwitch, Point panelSwitching)
        {
            Point panel1pos = panelToSwitch;
            Point panel2pos = panelSwitching;
            Image f = panelArray[panel1pos.X, panel1pos.Y].BackgroundImage;
            panelArray[panel1pos.X, panel1pos.Y].BackgroundImage = panelArray[panel2pos.X, panel2pos.Y].BackgroundImage;
            panelArray[panel2pos.X, panel2pos.Y].BackgroundImage = f;
            return panelArray;
        }
        Random random = new Random();
    }
}
