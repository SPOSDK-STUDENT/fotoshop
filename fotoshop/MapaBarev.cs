using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fotoshop
{
    public partial class MapaBarev : Form
    {
        public MapaBarev()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap sourceBitmap = (Bitmap)pictureBox2.Image;
            Bitmap destBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            ColorMap[] map = new ColorMap[2];
            map[0] = new ColorMap();
            map[1] = new ColorMap();
            map[0].OldColor = sourceBitmap.GetPixel(e.X, e.Y);
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            map[0].NewColor = cd.Color;
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetRemapTable(map);
            Graphics g = Graphics.FromImage(destBitmap);
            g.DrawImage(sourceBitmap, new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), 0,0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            pictureBox1.Image = destBitmap;
            pictureBox2.Image = destBitmap;
        }
    }
}
