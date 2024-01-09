using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace fotoshop
{
    public partial class Form1 : Form
    {
        private BitovaMapa btm;
        private BitovaMapa oldBtm;
        public Form1()
        {
            btm = new BitovaMapa();
            oldBtm = new BitovaMapa();
            InitializeComponent();
        }
        private void soubor_zobrazitfoto_Click(object sender, EventArgs e)
        {
            btm.drawBitmap(new Point(0, 0), this);
        }
        private void soubor_otevrit_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Otevřít";
            ofd.Filter = "jpg obrázky (*.jpg)|*.jpg|Jpeg obrázky (*jpeg)|*.jpeg|png obrázky (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BitovaMapa Import = new BitovaMapa(ofd.FileName);
                Import.drawBitmap(new Point(0, 0), this);
                btm.bitmap = Import.bitmap;
            }
        }
        private void zobrazit4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btm.drawFour();
        }
        private void upravy_cernobili_cernobila_Click(object sender, EventArgs e)
        {
            this.Text = "Fotošop - načítání filtru";
            oldBtm.bitmap = btm.bitmap;
            Bitmap Bmp = btm.bitmap;
            Color c;
            int rgb;
            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            oldBtm.drawBitmap(new Point(200, 200), this);
            btm.bitmap = Bmp;
            //btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
        private void upravy_cernobili_bilacerna_Click(object sender, EventArgs e)
        {
            this.Text = "Fotošop - načítání filtru";
            oldBtm.bitmap = btm.bitmap;
            Bitmap Bmp = btm.bitmap;
            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    if (btm.svetelnost(Bmp.GetPixel(x, y)) > 160)
                    {
                        Bmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        Bmp.SetPixel(x, y, Color.Black);
                    }
                }
            btm.bitmap = Bmp;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
        private void upravy_cernobili_petodstinu_Click(object sender, EventArgs e)
        {
            this.Text = "Fotošop - načítání filtru";
            oldBtm.bitmap = btm.bitmap;
            Bitmap Bmp = btm.bitmap;
            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    if (btm.svetelnost(Bmp.GetPixel(x, y)) < 51)
                    {
                        Bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                    else if (btm.svetelnost(Bmp.GetPixel(x, y)) < 102)
                    {
                        Bmp.SetPixel(x, y, Color.FromArgb(255, 51, 51, 51));
                    }
                    else if (btm.svetelnost(Bmp.GetPixel(x, y)) < 153)
                    {
                        Bmp.SetPixel(x, y, Color.FromArgb(255, 102, 102, 102));
                    }
                    else if (btm.svetelnost(Bmp.GetPixel(x, y)) < 204)
                    {
                        Bmp.SetPixel(x, y, Color.FromArgb(255, 153, 153, 153));
                    }
                }
            btm.bitmap = Bmp;
            btm.drawBitmap(new Point(0,0), this);
            this.Text = "Fotošop";
        }
        private void soubor_zpet_Click(object sender, EventArgs e)
        {
            this.Text = "Fotošop - navrácení úpravy";
            btm.bitmap = oldBtm.bitmap;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
    }
}
