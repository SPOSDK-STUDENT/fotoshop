using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fotoshop
{
    internal class BitovaMapa
    {
        public string CestaKBitmape { get; set; }
        public Bitmap bitmap { get; set; }
        public Size size { get; set; }
        private const double svetlostR = 0.3;
        private const double svetlostG = 0.6;
        private const double svetlostB = 0.1;

        public BitovaMapa()
        {
            this.CestaKBitmape = Environment.CurrentDirectory + @"\hasagi.jpg";
            this.bitmap = new Bitmap(this.CestaKBitmape);
            this.size = bitmap.Size;
        }
        public BitovaMapa(string bitmapPath)
        {
            this.CestaKBitmape = bitmapPath;
            this.bitmap = new Bitmap(this.CestaKBitmape);
            this.size = bitmap.Size;
        }
        public BitovaMapa(Bitmap bitmap, Size size)
        {
            this.CestaKBitmape = "nieje :D";
            this.bitmap = new Bitmap(bitmap);
            this.size = size;
        }

        //vy to máte pojmenované NacistBitovouMapu
        public void drawBitmap(Point pos, Form1 form)
        {
            Graphics grf = form.CreateGraphics();
            grf.DrawImage(this.bitmap, pos.X,pos.Y, this.size.Width, this.size.Height);
            grf.Dispose();
        }
        public void drawFour()
        {
            Form form = Form.ActiveForm;
            Graphics grf = form.CreateGraphics();
            grf.DrawImage(this.bitmap, 0, 0, form.Width / 2, form.Height / 2);
            grf.DrawImage(this.bitmap, 0, form.Height / 2, form.Width / 2, form.Height / 2);
            grf.DrawImage(this.bitmap, form.Width / 2, 0, form.Width / 2, form.Height / 2);
            grf.DrawImage(this.bitmap, form.Width / 2, form.Height / 2, form.Width / 2, form.Height / 2);
            grf.Dispose();
        }
        public int svetelnost(Color pixel)
        {
            return Convert.ToInt32(svetlostR * pixel.R + svetlostG * pixel.G + svetlostB * pixel.B);
        }

        //https://stackoverflow.com/questions/35395500/when-i-change-the-value-of-a-variable-which-is-a-copy-of-another-it-changes-the
        public BitovaMapa copy()
        {
            BitovaMapa tC = new BitovaMapa(this.bitmap, this.size);
            return tC;
        }
    }
}
