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
using System.Threading;
using System.Drawing.Imaging;

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
            btm.drawBitmap(new Point(0, 0), this);
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

        #region Úpravy
        private void upravy_cernobili_cernobila_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());//vysvětlim naživo xd moc komplikovaný
            Text = "Fotošop - načítání filtru";
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
            oldBtms.Insert(positionInOld + 1, btm.copy());
            btm.drawBitmap(new Point(0, 0), this);
            Text = "Fotošop";
        }
        private void upravy_cernobili_bilacerna_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());
            Text = "Fotošop - načítání filtru";
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
            Text = "Fotošop";
        }
        private void upravy_cernobili_petodstinu_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());
            Text = "Fotošop - načítání filtru";
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
            Text = "Fotošop";
        }
        private void upravy_odstinybarvy_5odstinu1barvy_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            oldBtms.Insert(positionInOld, btm.copy());
            Text = "Fotošop - načítání filtru";
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
            Text = "Fotošop";
        }

        private void upravy_odstinybarvy_5barev_Click(object sender, EventArgs e)
        {
            ColorDialog[] cd = new ColorDialog[5];
            cd[0] = new ColorDialog();
            if (cd[0].ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            cd[1] = new ColorDialog();
            if (cd[1].ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            cd[2] = new ColorDialog();
            if (cd[2].ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            cd[3] = new ColorDialog();
            if (cd[3].ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            cd[4] = new ColorDialog();
            if (cd[4].ShowDialog() != DialogResult.OK) { MessageBox.Show("Nastala chyba v načítání barvy"); return; }

            oldBtms.Insert(positionInOld, btm.copy());
            Text = "Fotošop - načítání filtru";
            Bitmap editedBmp = btm.bitmap;
            for (int y = 0; y < editedBmp.Height; y++)
                for (int x = 0; x < editedBmp.Width; x++)
                {
                    Color pixel = editedBmp.GetPixel(x, y);
                    Color clr = cd[0].Color;
                    if (btm.svetelnost(pixel) < 51)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd[0].Color.R), Convert.ToInt32(cd[0].Color.G), Convert.ToInt32(cd[0].Color.B)));
                    }
                    else if (btm.svetelnost(pixel) < 102)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd[1].Color.R), Convert.ToInt32(cd[1].Color.G), Convert.ToInt32(cd[1].Color.B)));
                    }
                    else if (btm.svetelnost(pixel) < 153)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd[2].Color.R), Convert.ToInt32(cd[2].Color.G), Convert.ToInt32(cd[2].Color.B)));
                    }
                    else if (btm.svetelnost(pixel) < 204)
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, Convert.ToInt32(cd[3].Color.R), Convert.ToInt32(cd[3].Color.G), Convert.ToInt32(cd[3].Color.B)));
                    }
                    else
                    {
                        editedBmp.SetPixel(x, y, Color.FromArgb(255, cd[4].Color.R, cd[4].Color.G, cd[4].Color.B));
                    }
                }
            btm.bitmap = editedBmp;
            btm.drawBitmap(new Point(0, 0), this);
            Text = "Fotošop";
        }
        #endregion
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        //reliéf
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            oldBtms.Insert(positionInOld, btm.copy());
            Text = "Fotošop - načítání filtru";
            Bitmap bit1 = new Bitmap(btm.copy().bitmap);
            Bitmap bit2 = new Bitmap(btm.copy().bitmap);
            Color pixel1;
            Color pixel2;
            int svetlost1;
            int svetlost2;
            int svetlost;
            for (int i = 0; i < bit1.Width; i++)
            {
                for (int j = 0; j < bit1.Height; j++)
                {
                    pixel1 = bit1.GetPixel(i, j);
                    svetlost1 = btm.svetelnost(pixel1);
                    if ((i > 4) & (j > 2))
                    {
                        pixel2 = bit2.GetPixel(i - 4, j - 2);
                    }
                    else
                    {
                        pixel2 = bit1.GetPixel(i, j);
                    }
                    svetlost2 = btm.svetelnost(pixel2);
                    svetlost = (150 + svetlost2 - svetlost1);
                    if (svetlost < 0)
                    {
                        svetlost = 0;
                    }
                    if (svetlost > 255)
                    {
                        svetlost = 255;
                    }
                    bit2.SetPixel(i, j, Color.FromArgb(svetlost, svetlost, svetlost));
                }
            }
            btm.bitmap = bit2;
            oldBtms.Insert(positionInOld+1, btm.copy());
            btm.drawBitmap(new Point(0, 0), this);
            Text = "Fotošop";
        }
        private void zpet_Click(object sender, EventArgs e)
        {
            if (oldBtms.Count == 0) { return; }
            Text = "Fotošop - navrácení úpravy";
            positionInOld++;
            btm = oldBtms[positionInOld];
            btm.drawBitmap(new Point(0, 0), this);
            Text = "Fotošop";
        }
        private void redo_Click(object sender, EventArgs e)
        {
            if (oldBtms.Count == 0) { return; }
            Text = "Fotošop - navrácení úpravy";
            positionInOld--;
            btm = oldBtms[positionInOld];
            btm.drawBitmap(new Point(0, 0), this);
            Text = "Fotošop";
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            btm.drawBitmap(new Point(0, 0), this);
        }

        Form form2 = new Form();
        BitovaMapa Import = new BitovaMapa();
        BitovaMapa Import2 = new BitovaMapa();
        private void soubor_zobrazit_2overlay_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Otevřít";
            ofd.Filter = "jpg obrázky (*.jpg)|*.jpg|Jpeg obrázky (*jpeg)|*.jpeg|png obrázky (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Import = new BitovaMapa(ofd.FileName);
                //btm.bitmap = Import.bitmap;

                OpenFileDialog ofd2 = new OpenFileDialog();
                ofd2.Title = "Otevřít";
                ofd2.Filter = "jpg obrázky (*.jpg)|*.jpg|Jpeg obrázky (*jpeg)|*.jpeg|png obrázky (*.png)|*.png";
                if (ofd2.ShowDialog() == DialogResult.OK)
                {
                    Import2 = new BitovaMapa(ofd2.FileName);
                    form2 = new Form();
                    form2.Show();
                    Import.bitmap = SetImageOpacity(Import.bitmap, 0.5F);
                    Import2.bitmap = SetImageOpacity(Import2.bitmap, 0.5F);
                    Import.drawBitmap(new Point(0, 0), form2, true);
                    Import2.drawBitmap(new Point(0, 0), form2, true);
                    form2.SizeChanged += new System.EventHandler(Form2_SizeChanged);
                }
            }
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            Import.drawBitmap(new Point(0, 0), form2, true);
            Import2.drawBitmap(new Point(0, 0), form2, true);
        }
        //nefunguje a není potřeba
        private void upravy_transparence_Click(object sender, EventArgs e)
        {
            Text = "Fotošop - načítání filtru";
            oldBtms.Insert(positionInOld, btm.copy());
            btm.bitmap.MakeTransparent();
            oldBtms.Insert(positionInOld + 1, btm.copy());
            Text = "Fotošop";
        }
        public Bitmap SetImageOpacity(Bitmap image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
