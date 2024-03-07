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
using static System.Net.Mime.MediaTypeNames;

namespace fotoshop
{
    public partial class colormatrix : Form
    {
        public colormatrix(Bitmap btm)
        {
            InitializeComponent();
            image = btm;
            main();
        }
        public float[][] colorMatrixElements = {
   new float[] {1,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {0f, 0f, 0f, 0, 1}};    // three translations of 0.2

        Bitmap image;
        void main()
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;
            
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            using (Graphics grf = this.CreateGraphics())
            {
                grf.DrawImage(
                   image,
                   new Rectangle(250, 10, width, height),  // destination rectangle 
                   0, 0,        // upper-left corner of source rectangle 
                   width,       // width of source rectangle
                   height,      // height of source rectangle
                   GraphicsUnit.Pixel,
                   imageAttributes);
            }
                
        }

        private void trackBar1_Scroll(object sender, EventArgs e) //red
        {
            colorMatrixElements[0][0] = (float)trackBar1.Value/100;
            main();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)//green
        {
            colorMatrixElements[0][1] = (float)trackBar2.Value / 100;
            main();
        }

        private void trackBar3_Scroll(object sender, EventArgs e) //blue
        {
            colorMatrixElements[0][2] = (float)trackBar3.Value / 100;
            main();
        }
        private void trackBar13_Scroll(object sender, EventArgs e) //alpha
        {
            colorMatrixElements[0][3] = (float)trackBar13.Value / 100;
            main();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][0] = (float)trackBar7.Value / 100;
            main();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][1] = (float)trackBar6.Value / 100;
            main();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][2] = (float)trackBar5.Value / 100;
            main();
        }


        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][0] = (float)trackBar16.Value / 100;
            main();
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][1] = (float)trackBar15.Value / 100;
            main();
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][2] = (float)trackBar14.Value / 100;
            main();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][0] = (float)trackBar11.Value / 100;
            main();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][1] = (float)trackBar10.Value / 100;
            main();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][2] = (float)trackBar9.Value / 100;
            main();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][3] = (float)trackBar4.Value / 100;
            main();
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][3] = (float)trackBar12.Value / 100;
            main();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][3] = (float)trackBar8.Value / 100;
            main();
        }
    }
}
