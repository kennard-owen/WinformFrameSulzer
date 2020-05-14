using Common;
using Sensor;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensors
{
    public partial class IO_LinkForm : Form
    {
        public IO_LinkForm()
        {
            InitializeComponent();
        }
        CancellationTokenSource tokenSource;
        CancellationToken Token;
        IO_LinkMaster myIomaster;

        private void IO_LinkForm_Load(object sender, EventArgs e)
        {
            SensorListItem.UpdateDiagnosisUI += GetDiagnosisData;
            pictureBox1.Image = Properties.Resources.IO_Link;
            InitializitionConnection();
        }

        private IO_Link_DiagnosisInfo GetDiagnosisData(string port)
        {
            var command = IO_LinkMasterModbusCommand.GetPortCommand(port);
            IO_Link_DiagnosisInfo res = new IO_Link_DiagnosisInfo();
            if (myIomaster.NetStatus != NetStatus.Good)
            {
                res.VendorName = "NG";
                res.VendorText = "Connect to device first";
                return res;
            }
            Task.Factory.StartNew(() =>
              {
                  string info = "";
                  myIomaster.BatchRead(DeviceType.Ultrasonic, command, out info);
                  res = info.FromJSON<IO_Link_DiagnosisInfo>();
              }).GetAwaiter().GetResult();

            return res;

        }

        private void InitializitionConnection()
        {
            tokenSource = new CancellationTokenSource();
            Token = tokenSource.Token;
           
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    myIomaster = new IO_LinkMaster("192.168.1.250", 502);
                    string err = "";
                    if (!myIomaster.Connect(out err))
                    {
                        tokenSource.Cancel();
                        MessageBox.Show(err);
                    }
                    while (true)
                    {
                        if (Token.IsCancellationRequested)
                        {
                            Token.ThrowIfCancellationRequested();
                        }
                        await update();
                        Token.WaitHandle.WaitOne(1000);
                    }
                }
                catch (AggregateException ex)
                {
                    MessageBox.Show(ex.InnerExceptions.ToString());
                }
            }, Token);

            Token.Register(() =>
            {
                Console.WriteLine(">>>>>> Delegate Invoked\n");
            });
        }

        async Task update()
        {
            await Task.Run(() =>
            {
                string port1Data = "";
                myIomaster.BatchRead(DeviceType.R100,CommandIO_Link.PDIPort1, out port1Data);
               
                Action<Image,string ,string, string, string> actionDelegate = (img,port,name,status,value) => {
                    this.sensorListItem1.UpdateData(img, port, name, status, value);
                };
                sensorListItem1.Invoke(actionDelegate, Properties.Resources.IUT_F190_R4_V1_FR2_03, "Port1", "IUT_F190_R4_V1_FR2_03", myIomaster.NetStatus.ToString(), port1Data);


                string port2Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort2, out port2Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem2.UpdateData(img, port, name, status, value);
                };
                sensorListItem2.Invoke(actionDelegate,Properties.Resources.UC400_F77_EP_IO_V31, "Port2", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port2Data);



                string port3Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort3, out port3Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem3.UpdateData(img, port, name, status, value);
                };
                sensorListItem3.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port3", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port3Data);


                string port4Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort4, out port4Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem4.UpdateData(img, port, name, status, value);
                };
                sensorListItem4.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port4", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port4Data);

                string port5Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort5, out port5Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem5.UpdateData(img, port, name, status, value);
                };
                sensorListItem5.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port5", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port5Data);


                string port6Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort6, out port6Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem6.UpdateData(img, port, name, status, value);
                };
                sensorListItem6.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port6", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port6Data);


                string port7Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort7, out port7Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem7.UpdateData(img, port, name, status, value);
                };
                sensorListItem7.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port7", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port7Data);


                string port8Data = "";
                myIomaster.BatchRead(DeviceType.R100, CommandIO_Link.PDIPort8, out port8Data);
                actionDelegate = (img, port, name, status, value) => {
                    this.sensorListItem8.UpdateData(img, port, name, status, value);
                };
                sensorListItem8.Invoke(actionDelegate, Properties.Resources.UC400_F77_EP_IO_V31, "Port8", "UC400_F77_EP_IO_V31", myIomaster.NetStatus.ToString(), port8Data);
            });
        }


        private void IO_LinkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
        }


        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("确认连接IO-Link", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (result == DialogResult.OK)
            //{
            //    InitializitionConnection();
            //}
            //else
            //{
            //}


        }

        private void 断开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认断开IO-Link", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                tokenSource.Cancel();
            }
            else
            {
            }
         
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e) {
            DeviceManagement diagnosisInfo = new DeviceManagement();
            //diagnosisInfo.MdiParent = this.ParentForm;
            //diagnosisInfo.Show();
            diagnosisInfo.ShowDialog();

        }
    }
}
