using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sensors.SensorListItem;

namespace Sensors
{
    public partial class DiagnosisInfo : Form
    {
        public DiagnosisInfo()
        {
            InitializeComponent();
        }

        public IO_Link_DiagnosisInfo info;
        private void DiagnosisInfo_Load(object sender, EventArgs e)
        {
            txt1.Text = info.Port;
            txt2.Text= info.VendorName;
            txt3.Text = info.VendorText;
            txt4.Text = info.ProductName;
            txt5.Text = info.ProductID;
            txt6.Text = info.ProductText;
            txt7.Text = info.SerialNumber;
            txt8.Text = info.HardwareRevision;
            txt9.Text = info.FirmwareRevision;
            txt10.Text = info.PDILength;
            txt11.Text = info.PDOLength;
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
