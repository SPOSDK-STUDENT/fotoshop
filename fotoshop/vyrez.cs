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
    public partial class vyrez : Form
    {
        public vyrez(Bitmap bitm)
        {
            InitializeComponent();
            btm.bitmap = new Bitmap(bitm);
            oldBitm = new Bitmap(bitm);
            this.Size = btm.bitmap.Size;
        }
        Bitmap oldBitm = null;
        public BitovaMapa btm = new BitovaMapa();
        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (vyrezingClickDown)
            {
                btm.drawBitmap(new Point(0,0), this);
                lastVyrezPos = new Size(e.X - vyrezPos.X, e.Y - vyrezPos.Y);
                btm.drawRectangle(vyrezPos, lastVyrezPos, this);
            }
        }
        Point vyrezPos;
        Size lastVyrezPos;
        bool vyrezingClickDown = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            btm.bitmap = oldBitm;
            vyrezingClickDown = true;
            vyrezPos = e.Location;
            
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (vyrezingClickDown)
            {
                Pen pero = new Pen(Color.Red);
                pero.Width = 1;
                //Bitmap image = btm.bitmap;
                Graphics kresba = this.CreateGraphics();//aby se to vykreslovalo přímo na bitmapu stačí tohle nahradit Graphics.FromImage(image), ale to se pak blbě unduje když vykresluješ znova

                kresba.DrawRectangle(pero, new Rectangle(vyrezPos, lastVyrezPos));
                //btm.bitmap = image;

                //Bitmap ee = new Bitmap(btm.bitmap);//nefunguje
                //BitovaMapa bb = new BitovaMapa(btm.bitmap);
                vyrezingClickDown = false;
            }
        }

        private void načístBitovouMapuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btm.drawBitmap(new Point(0,0), this);
        }

        private void vyříznoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(vyrezPos, lastVyrezPos);
                Bitmap vyrezBtm = btm.bitmap.Clone(rect, btm.bitmap.PixelFormat);
                btm.bitmap = vyrezBtm;
                btm.drawBitmap(new Point(0, 0), this);
            }
            catch { MessageBox.Show("Nastala chyba ve výřezu obrázku!"); }
        }

        private void navrátitVyříznutéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
