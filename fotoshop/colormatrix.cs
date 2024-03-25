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
        }
        public float[][] colorMatrixElements = {
   new float[] {1,  0,  0,  0, 0},        // red scaling
   new float[] {0,  1,  0,  0, 0},        // green scaling
   new float[] {0,  0,  1,  0, 0},        // blue scaling
   new float[] {0,  0,  0,  1, 0},        // alpha scaling
   new float[] {0, 0, 0, 0, 1}};
        public float[][] filterMatrixDefault = {
   new float[] {1,  0,  0,  0, 0},        // red scaling
   new float[] {0,  1,  0,  0, 0},        // green scaling
   new float[] {0,  0,  1,  0, 0},        // blue scaling
   new float[] {0,  0,  0,  1, 0},        // alpha scaling
   new float[] {0, 0, 0, 0, 1}};
        public float[][] filterMatrixGrayscale = {
   new float[] {.3f,  .3f,  .3f,  0, 0},        // red scaling
   new float[] {.59f, .59f, .59f,  0, 0},        // green scaling
   new float[] { .11f, .11f,  .11f,  0, 0},        // blue scaling
   new float[] {0,  0,  0,  1, 0},        // alpha scaling
   new float[] {0, 0, 0, 0, 1}};
        public float[][] filterMatrixSepiatone = {
   new float[] {.393f,  .349f,  .272f,  0, 0},        // red scaling
   new float[] {.769f,  .686f,  .534f,  0, 0},        // green scaling
   new float[] {.189f,  .168f,  .131f,  0, 0},        // blue scaling
   new float[] {0,  0,  0,  1, 0},        // alpha scaling
   new float[] {0, 0, 0, 0, 1}};
        public float[][] filterMatrixNegative = {
   new float[] {-1,  0,  0,  0, 0},        // red scaling
   new float[] {0,  -1,  0,  0, 0},        // green scaling
   new float[] {0,  0,  -1,  0, 0},        // blue scaling
   new float[] {0,  0,  0,  1, 0},        // alpha scaling
   new float[] {0, 0, 0, 0, 1}};
        public float[][] filterMatrixPolaroid =
        {
            new float[] { 1.438f, -0.062f, -0.062f, 0, 0 },
                new float[] { -0.122f, 1.378f, -0.122f, 0, 0 },
                new float[] { -0.016f, -0.016f, 1.483f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { -0.03f, 0.05f, -0.02f, 0, 1 }
        };
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
            label1.Text = trackBar1.Value + "%";
            main();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)//green
        {
            colorMatrixElements[0][1] = (float)trackBar2.Value / 100;
            label2.Text = trackBar2.Value + "%";
            main();
        }

        private void trackBar3_Scroll(object sender, EventArgs e) //blue
        {
            colorMatrixElements[0][2] = (float)trackBar3.Value / 100;
            label3.Text = trackBar3.Value + "%";
            main();
        }
        private void trackBar13_Scroll(object sender, EventArgs e) //alpha
        {
            /*colorMatrixElements[0][3] = (float)trackBar13.Value / 100;
            label4.Text = trackBar13.Value + "%";
            main();*/
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][0] = (float)trackBar7.Value / 100;
            label8.Text = trackBar7.Value + "%";
            main();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][1] = (float)trackBar6.Value / 100;
            label7.Text = trackBar6.Value + "%";
            main();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[1][2] = (float)trackBar5.Value / 100;
            label6.Text = trackBar5.Value + "%";
            main();
        }


        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][0] = (float)trackBar16.Value / 100;
            label16.Text = trackBar16.Value + "%";
            main();
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][1] = (float)trackBar15.Value / 100;
            label15.Text = trackBar15.Value + "%";
            main();
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][2] = (float)trackBar14.Value / 100;
            label14.Text = trackBar14.Value + "%";
            main();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][0] = (float)trackBar11.Value / 100;
            label12.Text = trackBar11.Value + "%";
            main();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[3][1] = (float)trackBar10.Value / 100;
            label11.Text = trackBar10.Value + "%";
            main();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[2][2] = (float)trackBar9.Value / 100;
            label10.Text = trackBar9.Value + "%";
            main();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            /*colorMatrixElements[1][3] = (float)trackBar4.Value / 100;
            label5.Text = trackBar4.Value + "%";
            main();*/
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            /*colorMatrixElements[2][3] = (float)trackBar12.Value / 100;
            label13.Text = trackBar12.Value + "%";
            main();*/
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            /*colorMatrixElements[3][3] = (float)trackBar8.Value / 100;
            label9.Text = trackBar8.Value + "%";
            main();*/
        }

        private void colormatrix_Load(object sender, EventArgs e)
        {
            main();
        }

        private void trackBar20_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[4][0] = (float)trackBar20.Value / 100;
            label20.Text = trackBar20.Value + "%";
            main();
        }

        private void trackBar19_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[4][1] = (float)trackBar19.Value / 100;
            label19.Text = trackBar19.Value + "%";
            main();
        }

        private void trackBar18_Scroll(object sender, EventArgs e)
        {
            colorMatrixElements[4][2] = (float)trackBar18.Value / 100;
            label18.Text = trackBar18.Value + "%";
            main();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            colorMatrixElements = filterMatrixGrayscale; main();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            colorMatrixElements = filterMatrixSepiatone; main();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            colorMatrixElements = filterMatrixNegative; main();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            colorMatrixElements = filterMatrixPolaroid;
            main();
        }
        //nedodělaný (reset)
        //https://stackoverflow.com/questions/36200888/looping-through-labels-in-c-sharp
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            colorMatrixElements = filterMatrixDefault; main();
            var trackBars = this.Controls.OfType<TrackBar>().ToList();
            trackBar1.Value = 100; trackBar6.Value = 100; trackBar9.Value = 100; trackBar12.Value = 100;
        }
    }
}
