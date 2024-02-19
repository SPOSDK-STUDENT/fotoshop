using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace fotoshop
{
    public class BitovaMapa
    {
        public string CestaKBitmape { get; set; }
        public Bitmap bitmap { get; set; }
        public ImageAttributes imageAttributes  { get; set; }
        public Size size { get; set; }
        private const double svetlostR = 0.3;
        private const double svetlostG = 0.6;
        private const double svetlostB = 0.1;

        public BitovaMapa()
        {
            this.CestaKBitmape = Environment.CurrentDirectory + @"\obr4.jpg";
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
        public void drawBitmap(Point pos, Form form)
        {
            using (Graphics grf = form.CreateGraphics())
            {
                grf.DrawImage(this.bitmap, new Rectangle(pos.X, pos.Y, this.size.Width, this.size.Height), 0, 0, this.bitmap.Width, this.bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
                //gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
        }
        public void drawPixel(Point pos, Form form)
        {
            using (Graphics grf = form.CreateGraphics())
            {
                Brush brush = new SolidBrush(bitmap.GetPixel(pos.X, pos.Y));
                grf.FillRectangle(brush, pos.X, pos.Y, 1, 1);
            }
        }
        public void drawRectangle(Point pos, Size size, Form form)
        {
            using (Graphics grf = form.CreateGraphics())
            {
                Pen brush = new Pen(Color.Red);
                if (size.Width < 0)
                {
                    pos.X += size.Width;
                    size.Width = Math.Abs(size.Width);
                }
                if (size.Height < 0)
                {
                    pos.Y += size.Height;
                    size.Height = Math.Abs(size.Height);
                }
                grf.DrawRectangle(brush, pos.X, pos.Y, size.Width, size.Height);
            }
        }
        public void drawBitmap(Point pos, Form form, Size size)
        {
            using (Graphics grf = form.CreateGraphics())
            {
                grf.Clear(Color.FromArgb(64, 64, 64));
                grf.DrawImage(this.bitmap, new Rectangle(pos.X, pos.Y, size.Width, size.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }
        public void drawBitmap(Point pos, Form form, bool noClear)
        {
            using (Graphics grf = form.CreateGraphics())
            {
                grf.DrawImage(this.bitmap, new Rectangle(pos.X, pos.Y, this.bitmap.Width, this.bitmap.Height), 0, 0, this.bitmap.Width, this.bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }
        public void drawFour()
        {
            Form form = Form.ActiveForm;
            using (Graphics grf = form.CreateGraphics())
            {
                grf.DrawImage(this.bitmap, 0, 0, form.Width / 2, form.Height / 2);
                grf.DrawImage(this.bitmap, 0, form.Height / 2, form.Width / 2, form.Height / 2);
                grf.DrawImage(this.bitmap, form.Width / 2, 0, form.Width / 2, form.Height / 2);
                grf.DrawImage(this.bitmap, form.Width / 2, form.Height / 2, form.Width / 2, form.Height / 2);
            }
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
