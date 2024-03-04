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
    public partial class colorMap : Form
    {
        public colorMap(Bitmap bitm)
        {
            InitializeComponent();
            btm.bitmap = bitm;

        }
        BitovaMapa btm = new BitovaMapa();
        private void colorMap_Load(object sender, EventArgs e)
        {

        }
    }
}
