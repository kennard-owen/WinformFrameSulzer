using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensors
{

 

    public partial class SensorListItem : UserControl
    {
        public static event Func<string, IO_Link_DiagnosisInfo> UpdateDiagnosisUI;

        public SensorListItem()
        {
            InitializeComponent();
        }
        public Image Img
        {
            get { return ct_pictureBox.Image; }
            set { ct_pictureBox.Image = value; }
        }
        public void UpdateData(Image img, string port ,string name ,string status,string value) {
            ct_pictureBox.Image = img;
            textBox1.Text = port;
            textBox2.Text = name;
            textBox3.Text = status;
            textBox4.Text = value;
        }
        public void UpdateData( string port, string name, string status, string value)
        {
            textBox1.Text = port;
            textBox2.Text = name;
            textBox3.Text = status;
            textBox4.Text = value;
        }
        public void UpdateData( string status, string value)
        {
            textBox3.Text = status;
            textBox4.Text = value;
        }

        public void UpdateData( string value)
        {
            textBox4.Text = value;
        }

        private void Btn_Diagnosis_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(PopUpDiagnosisInfo); 

        }
        private void PopUpDiagnosisInfo()
        {
            DiagnosisInfo diagnosisInfo = new DiagnosisInfo();
            if (UpdateDiagnosisUI != null)
            {
                diagnosisInfo.info = UpdateDiagnosisUI(textBox1.Text);
            }
            if (diagnosisInfo.info.VendorName == "NG")
            {
                MessageBox.Show(diagnosisInfo.info.VendorText);
                diagnosisInfo.Dispose();
            }
            else
            {
                diagnosisInfo.ShowDialog();
            }
        }
    }
}
