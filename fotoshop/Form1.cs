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
using System.IO.Ports;

namespace fotoshop
{
    public partial class Form1 : Form
    {
        private BitovaMapa btm;
        List <BitovaMapa> oldBtms = new List<BitovaMapa>();
        private int positionInOld = 0;
        public Form1()
        {
            btm = new BitovaMapa();
            InitializeComponent();
        }
        private void soubor_zobrazit_foto_Click(object sender, EventArgs e)
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
        private void soubor_zobrazit_4_Click(object sender, EventArgs e)
        {
            btm.drawFour();
        }
        private void upravy_cernobili_cernobila_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());//vysvětlim naživo xd moc komplikovaný
            this.Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            Color c;
            int rgb;
            for (int y = 0; y < editedBmp.Height; y++)
            {
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    c = editedBmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    editedBmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
        private void upravy_cernobili_bilacerna_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());
            this.Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            for (int y = 0; y < editedBmp.Height; y++)
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    if (btm.svetelnost(editedBmp.GetPixel(x, y)) > 160)
                    {
                        editedBmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        editedBmp.SetPixel(x, y, Color.Black);
                    }
                }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
        private void upravy_cernobili_petodstinu_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());
            this.Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            for (int y = 0; y < editedBmp.Height; y++)
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    if (btm.svetelnost(editedBmp.GetPixel(x, y)) < 51)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                    else if (btm.svetelnost(editedBmp.GetPixel(x, y)) < 102)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, 51, 51, 51));
                    }
                    else if (btm.svetelnost(editedBmp.GetPixel(x, y)) < 153)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, 102, 102, 102));
                    }
                    else if (btm.svetelnost(editedBmp.GetPixel(x, y)) < 204)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, 153, 153, 153));
                    }
                    else
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, 204, 204, 204));
                    }
                }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0,0), this);
            this.Text = "Fotošop";
        }
        private void soubor_zpet_Click(object sender, EventArgs e)
        {
            this.Text = "Fotošop - navrácení úpravy";
            btm = oldBtms[positionInOld];
            positionInOld++;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
        private void upravy_odstinybarvy_5odstinu1barvy_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            oldBtms.Insert(positionInOld, btm.copy());
            this.Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            for (int y = 0; y < editedBmp.Height; y++)
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    Color pixel = editedBmp.GetPixel(x, y);
                    Color clr = cd.Color;
                    if (btm.svetelnost(pixel) < 51)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(clr.R * 0.4), Convert.ToInt32(clr.G * 0.4), Convert.ToInt32(clr.B * 0.4)));
                    }
                    else if (btm.svetelnost(pixel) < 102)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(clr.R * 0.5), Convert.ToInt32(clr.G * 0.5), Convert.ToInt32(clr.B * 0.5)));
                    }
                    else if (btm.svetelnost(pixel) < 153)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(clr.R * 0.7), Convert.ToInt32(clr.G * 0.7), Convert.ToInt32(clr.B * 0.7)));
                    }
                    else if (btm.svetelnost(pixel) < 204)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(clr.R * 0.9), Convert.ToInt32(clr.G * 0.9), Convert.ToInt32(clr.B * 0.9)));
                    }
                    else
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, clr.R, clr.G, clr.B));
                    }
                }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }

        private void upravy_odstinybarvy_5barev_Click(object sender, EventArgs e)
        {
            ColorDialog cd1 = new ColorDialog();
            if (cd1.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            ColorDialog cd2 = new ColorDialog();
            if (cd2.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            ColorDialog cd3 = new ColorDialog();
            if (cd3.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            ColorDialog cd4 = new ColorDialog();
            if (cd4.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            ColorDialog cd5 = new ColorDialog();
            if (cd5.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            oldBtms.Insert(positionInOld, btm.copy());
            this.Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            for (int y = 0; y < editedBmp.Height; y++)
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    Color pixel = editedBmp.GetPixel(x, y);
                    Color clr = cd1.Color;
                    if (btm.svetelnost(pixel) < 51)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd1.Color.R * 0.4), Convert.ToInt32(cd1.Color.G * 0.4), Convert.ToInt32(cd1.Color.B * 0.4)));
                    }
                    else if (btm.svetelnost(pixel) < 102)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd2.Color.R * 0.5), Convert.ToInt32(cd2.Color.G * 0.5), Convert.ToInt32(cd2.Color.B * 0.5)));
                    }
                    else if (btm.svetelnost(pixel) < 153)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd3.Color.R * 0.7), Convert.ToInt32(cd3.Color.G * 0.7), Convert.ToInt32(cd3.Color.B * 0.7)));
                    }
                    else if (btm.svetelnost(pixel) < 204)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd4.Color.R * 0.9), Convert.ToInt32(cd4.Color.G * 0.9), Convert.ToInt32(cd4.Color.B * 0.9)));
                    }
                    else
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, cd5.Color.R, cd5.Color.G, cd5.Color.B));
                    }
                }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0, 0), this);
            this.Text = "Fotošop";
        }
    }
}
