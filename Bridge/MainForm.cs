using Common;
using Sensors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sulzer;

namespace Bridge
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
    
        private static MeasureForm _UCC400 = null;

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.Activate();
            }
        }

        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //e.Cancel = true;
        //    //this.Hide();
        //}
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.BackgroundImage = Bridge.Properties.Resources.bg1;

        }


        private void 关于本平台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bridge.About about = new Bridge.About();
            //about.MdiParent = this;
            //childForm.Text = "窗口 " + childFormNumber++;
            about.ShowDialog();
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0         //隐藏子窗体图标
            || e.Item.Text == "最小化(&N)"  //隐藏最小化按钮
            || e.Item.Text == "还原(&R)"  //隐藏还原按钮
            || e.Item.Text == "关闭(&C)")//隐藏最关闭按钮
            {
                e.Item.Visible = false;
            }
        }
        private static MeasureForm _measure = null;
        private void uCCToolStripMenuItem_Click(object sender, EventArgs e) {
            //_HandheldRFIDForm=(HandheldRFIDForm)InitializeForm(_HandheldRFIDForm, "HandheldRFIDForm");
            if ((_measure == null) || (_measure.IsDisposed)) {
                _measure = new MeasureForm();
                _measure.MdiParent = this;
                _measure.WindowState = FormWindowState.Maximized;
                _measure.Show();
            }
            else {
                _measure.Activate();
            }
        }
        private static DatatableForm _Datatable = null;
        private void dataTableToolStripMenuItem_Click(object sender, EventArgs e) {
            //_HandheldRFIDForm=(HandheldRFIDForm)InitializeForm(_HandheldRFIDForm, "HandheldRFIDForm");
            if ((_Datatable == null) || (_Datatable.IsDisposed)) {
                _Datatable = new DatatableForm();
                _Datatable.MdiParent = this;
                _Datatable.WindowState = FormWindowState.Maximized;
                _Datatable.Show();
            }
            else {
                _Datatable.Activate();
            }
        }
        private static Chart _Chart = null;
        private void lineChartToolStripMenuItem_Click(object sender, EventArgs e) {
            //_HandheldRFIDForm=(HandheldRFIDForm)InitializeForm(_HandheldRFIDForm, "HandheldRFIDForm");
            if ((_Chart == null) || (_Chart.IsDisposed)) {
                _Chart = new Chart();
                _Chart.MdiParent = this;
                _Chart.WindowState = FormWindowState.Maximized;
                _Chart.Show();
            }
            else {
                _Chart.Activate();
            }
        }



        private static Configuration _Configuration = null;
        private void configToolStripMenuItem_Click(object sender, EventArgs e) {
            //_HandheldRFIDForm=(HandheldRFIDForm)InitializeForm(_HandheldRFIDForm, "HandheldRFIDForm");
            if ((_Configuration == null) || (_Configuration.IsDisposed)) {
                _Configuration = new Configuration();
                _Configuration.MdiParent = this;
                _Configuration.WindowState = FormWindowState.Maximized;
                _Configuration.Show();
            }
            else {
                _Configuration.Activate();
            }
        }
    }
}
