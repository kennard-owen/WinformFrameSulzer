namespace Sensors
{
    partial class IO_LinkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IO_LinkForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sensorListItem1 = new Sensors.SensorListItem();
            this.sensorListItem3 = new Sensors.SensorListItem();
            this.sensorListItem5 = new Sensors.SensorListItem();
            this.sensorListItem7 = new Sensors.SensorListItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.sensorListItem2 = new Sensors.SensorListItem();
            this.sensorListItem4 = new Sensors.SensorListItem();
            this.sensorListItem6 = new Sensors.SensorListItem();
            this.sensorListItem8 = new Sensors.SensorListItem();
            this.设备管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1270, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "IO-Link Master";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1270, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 29);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时数据ToolStripMenuItem,
            this.停止上传ToolStripMenuItem,
            this.设备管理ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            this.开始ToolStripMenuItem.Text = "IO-Link 工具(&T)";
            // 
            // 实时数据ToolStripMenuItem
            // 
            this.实时数据ToolStripMenuItem.Name = "实时数据ToolStripMenuItem";
            this.实时数据ToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.实时数据ToolStripMenuItem.Text = "连接";
            this.实时数据ToolStripMenuItem.Click += new System.EventHandler(this.连接ToolStripMenuItem_Click);
            // 
            // 停止上传ToolStripMenuItem
            // 
            this.停止上传ToolStripMenuItem.Name = "停止上传ToolStripMenuItem";
            this.停止上传ToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.停止上传ToolStripMenuItem.Text = "断开";
            this.停止上传ToolStripMenuItem.Click += new System.EventHandler(this.断开ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 629);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1270, 127);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1270, 127);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(879, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 121);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 549);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.sensorListItem1);
            this.flowLayoutPanel1.Controls.Add(this.sensorListItem3);
            this.flowLayoutPanel1.Controls.Add(this.sensorListItem5);
            this.flowLayoutPanel1.Controls.Add(this.sensorListItem7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(66, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(502, 543);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // sensorListItem1
            // 
            this.sensorListItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem1.Img = null;
            this.sensorListItem1.Location = new System.Drawing.Point(3, 3);
            this.sensorListItem1.Name = "sensorListItem1";
            this.sensorListItem1.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem1.TabIndex = 0;
            // 
            // sensorListItem3
            // 
            this.sensorListItem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem3.Img = null;
            this.sensorListItem3.Location = new System.Drawing.Point(3, 182);
            this.sensorListItem3.Name = "sensorListItem3";
            this.sensorListItem3.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem3.TabIndex = 1;
            // 
            // sensorListItem5
            // 
            this.sensorListItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem5.Img = null;
            this.sensorListItem5.Location = new System.Drawing.Point(3, 361);
            this.sensorListItem5.Name = "sensorListItem5";
            this.sensorListItem5.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem5.TabIndex = 2;
            // 
            // sensorListItem7
            // 
            this.sensorListItem7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem7.Img = null;
            this.sensorListItem7.Location = new System.Drawing.Point(3, 540);
            this.sensorListItem7.Name = "sensorListItem7";
            this.sensorListItem7.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem7.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.sensorListItem2);
            this.flowLayoutPanel2.Controls.Add(this.sensorListItem4);
            this.flowLayoutPanel2.Controls.Add(this.sensorListItem6);
            this.flowLayoutPanel2.Controls.Add(this.sensorListItem8);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(701, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(502, 543);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // sensorListItem2
            // 
            this.sensorListItem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem2.Img = null;
            this.sensorListItem2.Location = new System.Drawing.Point(3, 3);
            this.sensorListItem2.Name = "sensorListItem2";
            this.sensorListItem2.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem2.TabIndex = 1;
            // 
            // sensorListItem4
            // 
            this.sensorListItem4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem4.Img = null;
            this.sensorListItem4.Location = new System.Drawing.Point(3, 182);
            this.sensorListItem4.Name = "sensorListItem4";
            this.sensorListItem4.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem4.TabIndex = 2;
            // 
            // sensorListItem6
            // 
            this.sensorListItem6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem6.Img = null;
            this.sensorListItem6.Location = new System.Drawing.Point(3, 361);
            this.sensorListItem6.Name = "sensorListItem6";
            this.sensorListItem6.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem6.TabIndex = 3;
            // 
            // sensorListItem8
            // 
            this.sensorListItem8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sensorListItem8.Img = null;
            this.sensorListItem8.Location = new System.Drawing.Point(3, 540);
            this.sensorListItem8.Name = "sensorListItem8";
            this.sensorListItem8.Size = new System.Drawing.Size(662, 173);
            this.sensorListItem8.TabIndex = 4;
            // 
            // 设备管理ToolStripMenuItem
            // 
            this.设备管理ToolStripMenuItem.Name = "设备管理ToolStripMenuItem";
            this.设备管理ToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.设备管理ToolStripMenuItem.Text = "设备管理";
            this.设备管理ToolStripMenuItem.Click += new System.EventHandler(this.设备管理ToolStripMenuItem_Click);
            // 
            // IO_LinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 756);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IO_LinkForm";
            this.Text = "IO-Link";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IO_LinkForm_FormClosing);
            this.Load += new System.EventHandler(this.IO_LinkForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止上传ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private SensorListItem sensorListItem1;
        private SensorListItem sensorListItem3;
        private SensorListItem sensorListItem5;
        private SensorListItem sensorListItem7;
        private SensorListItem sensorListItem2;
        private SensorListItem sensorListItem4;
        private SensorListItem sensorListItem6;
        private SensorListItem sensorListItem8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 设备管理ToolStripMenuItem;
    }
}

