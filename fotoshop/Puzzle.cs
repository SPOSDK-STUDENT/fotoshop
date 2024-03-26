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
        public Panel[,] panelArray = null;
        private void Puzzle_Load(object sender, EventArgs e)
        {
            panelArray = new Panel[size, size];
            Size btmSize = new Size(btm.bitmap.Width / size, btm.bitmap.Height / size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    panelArray[i, j] = new Panel(); panelArray[i, j].Location = new Point(i * btmSize.Width, j * btmSize.Height);
                    panelArray[i, j].Size = btmSize;
                    panelArray[i, j].BackgroundImage = btm.bitmap.Clone(new Rectangle(new Point(i * btmSize.Width, j * btmSize.Height), btmSize), btm.bitmap.PixelFormat);
                    panelArray[i, j].MouseDown += this.panel1_MouseDown;
                    this.Controls.Add(panelArray[i, j]);
                }
            }
            panelArray = Shuffle(panelArray);
        }

        Panel[,] Shuffle(Panel[,] panelArray)
        {
            //panelArray = Switch(panelArray, new Point(0, 0), new Point(2, 2));
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    panelArray = Switch(panelArray, new Point(i, j), new Point(random.Next(0, size), random.Next(0, size)));
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
        Point panelSelected = new Point(-1,-1);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            for (int i = 0; i < size; i++)
            {
                if (Array.IndexOf(GetColumn(panelArray, i), (Panel)sender) != -1)
                {
                    if (panelSelected == new Point(-1, -1))
                    {
                        panelSelected = new Point(Array.IndexOf(GetColumn(panelArray, i), (Panel)sender), i);
                    }
                    else
                    {
                        panelArray = Switch(panelArray, panelSelected, new Point(Array.IndexOf(GetColumn(panelArray, i), (Panel)sender), i));
                        panelSelected = new Point(-1, -1);
                    }
                }
            }
        }
        public Panel[] GetColumn(Panel[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }
    }
}