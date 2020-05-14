using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensors
{
    public partial class HandheldRFIDForm : Form
    {
        public HandheldRFIDForm()
        {
            InitializeComponent();
        }


        private void HandheldRFIDForm_Load(object sender, EventArgs e)
        {
            //smallSensorPanel1.Img= Sensors.Properties.Resources.UC400-Sensors-EP-IO-V31.jpg;
            smallSensorPanel1.Img = Sensors.Properties.Resources.UC400_F77_EP_IO_V31;
        }
    }
}
