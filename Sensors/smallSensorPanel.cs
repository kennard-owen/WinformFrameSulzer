using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensor
{
    public partial class smallSensorPanel : UserControl
    {

        public Image Img
        {
            get { return Ct_pictureBox.Image;}
            set { Ct_pictureBox.Image = value; }
        }

        public smallSensorPanel()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
