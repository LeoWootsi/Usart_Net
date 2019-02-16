namespace Uart_Net
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SerialBaudBox = new System.Windows.Forms.ComboBox();
            this.SerialPortBox = new System.Windows.Forms.ComboBox();
            this.SerialOpenBtn = new System.Windows.Forms.Button();
            this.SerialRfrshBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SerialRcvPause = new System.Windows.Forms.CheckBox();
            this.SerialClearBtn = new System.Windows.Forms.Button();
            this.SerialSaveBtn = new System.Windows.Forms.Button();
            this.SerialRcvShowSend = new System.Windows.Forms.CheckBox();
            this.SerialRcvShowTime = new System.Windows.Forms.CheckBox();
            this.SerialRcvHEX = new System.Windows.Forms.RadioButton();
            this.SerialRcvASCII = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialSndTimerNum = new System.Windows.Forms.NumericUpDown();
            this.SerialSndAutoSend = new System.Windows.Forms.CheckBox();
            this.SerialSndNewLine = new System.Windows.Forms.CheckBox();
            this.SerialSndHEX = new System.Windows.Forms.RadioButton();
            this.SerialSndASCII = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.NetPortTextBox = new System.Windows.Forms.TextBox();
            this.NetIPTextBox = new System.Windows.Forms.TextBox();
            this.NetModeBox = new System.Windows.Forms.ComboBox();
            this.NetConnectBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.SerialRcvTextBox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.NetHidePortBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NetHideIPBox = new System.Windows.Forms.TextBox();
            this.NetClientList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NetRcvTextBox = new System.Windows.Forms.TextBox();
            this.SerialSndTextBox = new System.Windows.Forms.TextBox();
            this.NetSndTextBox = new System.Windows.Forms.TextBox();
            this.SerialSndBtn = new System.Windows.Forms.Button();
            this.NetSndBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.NetRcvPause = new System.Windows.Forms.CheckBox();
            this.NetClearBtn = new System.Windows.Forms.Button();
            this.NetSaveBtn = new System.Windows.Forms.Button();
            this.NetRcvShowSend = new System.Windows.Forms.CheckBox();
            this.NetRcvShowTime = new System.Windows.Forms.CheckBox();
            this.NetRcvHEX = new System.Windows.Forms.RadioButton();
            this.NetRcvASCII = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NetSndTimerNum = new System.Windows.Forms.NumericUpDown();
            this.NetSndAutoSend = new System.Windows.Forms.CheckBox();
            this.NetSndNewLine = new System.Windows.Forms.CheckBox();
            this.NetSndHEX = new System.Windows.Forms.RadioButton();
            this.NetSndASCII = new System.Windows.Forms.RadioButton();
            this.SerialInfo = new System.Windows.Forms.Label();
            this.NetInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SerialRxCnt = new System.Windows.Forms.Label();
            this.SerialTxCnt = new System.Windows.Forms.Label();
            this.NetRxCnt = new System.Windows.Forms.Label();
            this.NetTxCnt = new System.Windows.Forms.Label();
            this.SerialTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NetTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SerialSndTimerNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NetSndTimerNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.SerialBaudBox);
            this.groupBox1.Controls.Add(this.SerialPortBox);
            this.groupBox1.Controls.Add(this.SerialOpenBtn);
            this.groupBox1.Controls.Add(this.SerialRfrshBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // SerialBaudBox
            // 
            resources.ApplyResources(this.SerialBaudBox, "SerialBaudBox");
            this.SerialBaudBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialBaudBox.FormattingEnabled = true;
            this.SerialBaudBox.Items.AddRange(new object[] {
            resources.GetString("SerialBaudBox.Items"),
            resources.GetString("SerialBaudBox.Items1"),
            resources.GetString("SerialBaudBox.Items2"),
            resources.GetString("SerialBaudBox.Items3")});
            this.SerialBaudBox.Name = "SerialBaudBox";
            this.SerialBaudBox.SelectedIndexChanged += new System.EventHandler(this.SerialBaudBox_SelectedIndexChanged);
            // 
            // SerialPortBox
            // 
            resources.ApplyResources(this.SerialPortBox, "SerialPortBox");
            this.SerialPortBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortBox.Name = "SerialPortBox";
            this.SerialPortBox.SelectedIndexChanged += new System.EventHandler(this.SerialPortBox_SelectedIndexChanged);
            // 
            // SerialOpenBtn
            // 
            resources.ApplyResources(this.SerialOpenBtn, "SerialOpenBtn");
            this.SerialOpenBtn.Name = "SerialOpenBtn";
            this.SerialOpenBtn.UseVisualStyleBackColor = true;
            this.SerialOpenBtn.Click += new System.EventHandler(this.SerialOpenBtn_Click);
            // 
            // SerialRfrshBtn
            // 
            resources.ApplyResources(this.SerialRfrshBtn, "SerialRfrshBtn");
            this.SerialRfrshBtn.Name = "SerialRfrshBtn";
            this.SerialRfrshBtn.UseVisualStyleBackColor = true;
            this.SerialRfrshBtn.Click += new System.EventHandler(this.SerailRfrshBtn_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.SerialRcvPause);
            this.groupBox2.Controls.Add(this.SerialClearBtn);
            this.groupBox2.Controls.Add(this.SerialSaveBtn);
            this.groupBox2.Controls.Add(this.SerialRcvShowSend);
            this.groupBox2.Controls.Add(this.SerialRcvShowTime);
            this.groupBox2.Controls.Add(this.SerialRcvHEX);
            this.groupBox2.Controls.Add(this.SerialRcvASCII);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // SerialRcvPause
            // 
            resources.ApplyResources(this.SerialRcvPause, "SerialRcvPause");
            this.SerialRcvPause.Name = "SerialRcvPause";
            this.SerialRcvPause.UseVisualStyleBackColor = true;
            this.SerialRcvPause.CheckedChanged += new System.EventHandler(this.SerialRcvPause_CheckedChanged);
            // 
            // SerialClearBtn
            // 
            resources.ApplyResources(this.SerialClearBtn, "SerialClearBtn");
            this.SerialClearBtn.Name = "SerialClearBtn";
            this.SerialClearBtn.UseVisualStyleBackColor = true;
            this.SerialClearBtn.Click += new System.EventHandler(this.SerialClearBtn_Click);
            // 
            // SerialSaveBtn
            // 
            resources.ApplyResources(this.SerialSaveBtn, "SerialSaveBtn");
            this.SerialSaveBtn.Name = "SerialSaveBtn";
            this.SerialSaveBtn.UseVisualStyleBackColor = true;
            this.SerialSaveBtn.Click += new System.EventHandler(this.SerialSaveBtn_Click);
            // 
            // SerialRcvShowSend
            // 
            resources.ApplyResources(this.SerialRcvShowSend, "SerialRcvShowSend");
            this.SerialRcvShowSend.Name = "SerialRcvShowSend";
            this.SerialRcvShowSend.UseVisualStyleBackColor = true;
            // 
            // SerialRcvShowTime
            // 
            resources.ApplyResources(this.SerialRcvShowTime, "SerialRcvShowTime");
            this.SerialRcvShowTime.Name = "SerialRcvShowTime";
            this.SerialRcvShowTime.UseVisualStyleBackColor = true;
            // 
            // SerialRcvHEX
            // 
            resources.ApplyResources(this.SerialRcvHEX, "SerialRcvHEX");
            this.SerialRcvHEX.Name = "SerialRcvHEX";
            this.SerialRcvHEX.TabStop = true;
            this.SerialRcvHEX.UseVisualStyleBackColor = true;
            // 
            // SerialRcvASCII
            // 
            resources.ApplyResources(this.SerialRcvASCII, "SerialRcvASCII");
            this.SerialRcvASCII.Checked = true;
            this.SerialRcvASCII.Name = "SerialRcvASCII";
            this.SerialRcvASCII.TabStop = true;
            this.SerialRcvASCII.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.SerialSndTimerNum);
            this.groupBox3.Controls.Add(this.SerialSndAutoSend);
            this.groupBox3.Controls.Add(this.SerialSndNewLine);
            this.groupBox3.Controls.Add(this.SerialSndHEX);
            this.groupBox3.Controls.Add(this.SerialSndASCII);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SerialSndTimerNum
            // 
            resources.ApplyResources(this.SerialSndTimerNum, "SerialSndTimerNum");
            this.SerialSndTimerNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SerialSndTimerNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SerialSndTimerNum.Name = "SerialSndTimerNum";
            this.SerialSndTimerNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SerialSndTimerNum.ValueChanged += new System.EventHandler(this.SerialSndTimerNum_ValueChanged);
            // 
            // SerialSndAutoSend
            // 
            resources.ApplyResources(this.SerialSndAutoSend, "SerialSndAutoSend");
            this.SerialSndAutoSend.Name = "SerialSndAutoSend";
            this.SerialSndAutoSend.UseVisualStyleBackColor = true;
            this.SerialSndAutoSend.CheckedChanged += new System.EventHandler(this.SerialSndAutoSend_CheckedChanged);
            // 
            // SerialSndNewLine
            // 
            resources.ApplyResources(this.SerialSndNewLine, "SerialSndNewLine");
            this.SerialSndNewLine.Name = "SerialSndNewLine";
            this.SerialSndNewLine.UseVisualStyleBackColor = true;
            // 
            // SerialSndHEX
            // 
            resources.ApplyResources(this.SerialSndHEX, "SerialSndHEX");
            this.SerialSndHEX.Name = "SerialSndHEX";
            this.SerialSndHEX.TabStop = true;
            this.SerialSndHEX.UseVisualStyleBackColor = true;
            this.SerialSndHEX.CheckedChanged += new System.EventHandler(this.SerialSndHEX_CheckedChanged);
            // 
            // SerialSndASCII
            // 
            resources.ApplyResources(this.SerialSndASCII, "SerialSndASCII");
            this.SerialSndASCII.Checked = true;
            this.SerialSndASCII.Name = "SerialSndASCII";
            this.SerialSndASCII.TabStop = true;
            this.SerialSndASCII.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.NetPortTextBox);
            this.groupBox4.Controls.Add(this.NetIPTextBox);
            this.groupBox4.Controls.Add(this.NetModeBox);
            this.groupBox4.Controls.Add(this.NetConnectBtn);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // NetPortTextBox
            // 
            resources.ApplyResources(this.NetPortTextBox, "NetPortTextBox");
            this.NetPortTextBox.Name = "NetPortTextBox";
            this.NetPortTextBox.TextChanged += new System.EventHandler(this.NetPortTextBox_TextChanged);
            this.NetPortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetPortTextBox_KeyPress);
            // 
            // NetIPTextBox
            // 
            resources.ApplyResources(this.NetIPTextBox, "NetIPTextBox");
            this.NetIPTextBox.Name = "NetIPTextBox";
            this.NetIPTextBox.TextChanged += new System.EventHandler(this.NetIPTextBox_TextChanged);
            this.NetIPTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetIPTextBox_KeyPress);
            // 
            // NetModeBox
            // 
            resources.ApplyResources(this.NetModeBox, "NetModeBox");
            this.NetModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetModeBox.FormattingEnabled = true;
            this.NetModeBox.Items.AddRange(new object[] {
            resources.GetString("NetModeBox.Items"),
            resources.GetString("NetModeBox.Items1"),
            resources.GetString("NetModeBox.Items2")});
            this.NetModeBox.Name = "NetModeBox";
            this.NetModeBox.SelectedIndexChanged += new System.EventHandler(this.NetModeBox_SelectedIndexChanged);
            // 
            // NetConnectBtn
            // 
            resources.ApplyResources(this.NetConnectBtn, "NetConnectBtn");
            this.NetConnectBtn.Name = "NetConnectBtn";
            this.NetConnectBtn.UseVisualStyleBackColor = true;
            this.NetConnectBtn.Click += new System.EventHandler(this.NetConnectBtn_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Controls.Add(this.SerialRcvTextBox);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // SerialRcvTextBox
            // 
            resources.ApplyResources(this.SerialRcvTextBox, "SerialRcvTextBox");
            this.SerialRcvTextBox.BackColor = System.Drawing.Color.White;
            this.SerialRcvTextBox.Name = "SerialRcvTextBox";
            this.SerialRcvTextBox.ReadOnly = true;
            // 
            // groupBox8
            // 
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Controls.Add(this.NetHidePortBox);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.NetHideIPBox);
            this.groupBox8.Controls.Add(this.NetClientList);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.NetRcvTextBox);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // NetHidePortBox
            // 
            resources.ApplyResources(this.NetHidePortBox, "NetHidePortBox");
            this.NetHidePortBox.Name = "NetHidePortBox";
            this.NetHidePortBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetPortTextBox_KeyPress);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // NetHideIPBox
            // 
            resources.ApplyResources(this.NetHideIPBox, "NetHideIPBox");
            this.NetHideIPBox.Name = "NetHideIPBox";
            this.NetHideIPBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetIPTextBox_KeyPress);
            // 
            // NetClientList
            // 
            resources.ApplyResources(this.NetClientList, "NetClientList");
            this.NetClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetClientList.FormattingEnabled = true;
            this.NetClientList.Items.AddRange(new object[] {
            resources.GetString("NetClientList.Items")});
            this.NetClientList.Name = "NetClientList";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // NetRcvTextBox
            // 
            resources.ApplyResources(this.NetRcvTextBox, "NetRcvTextBox");
            this.NetRcvTextBox.BackColor = System.Drawing.Color.White;
            this.NetRcvTextBox.Name = "NetRcvTextBox";
            this.NetRcvTextBox.ReadOnly = true;
            // 
            // SerialSndTextBox
            // 
            resources.ApplyResources(this.SerialSndTextBox, "SerialSndTextBox");
            this.SerialSndTextBox.Name = "SerialSndTextBox";
            this.SerialSndTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SerialSndTextBox_KeyPress);
            // 
            // NetSndTextBox
            // 
            resources.ApplyResources(this.NetSndTextBox, "NetSndTextBox");
            this.NetSndTextBox.Name = "NetSndTextBox";
            this.NetSndTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetSndTextBox_KeyPress);
            // 
            // SerialSndBtn
            // 
            resources.ApplyResources(this.SerialSndBtn, "SerialSndBtn");
            this.SerialSndBtn.Name = "SerialSndBtn";
            this.SerialSndBtn.UseVisualStyleBackColor = true;
            this.SerialSndBtn.Click += new System.EventHandler(this.SerialSndBtn_Click);
            // 
            // NetSndBtn
            // 
            resources.ApplyResources(this.NetSndBtn, "NetSndBtn");
            this.NetSndBtn.Name = "NetSndBtn";
            this.NetSndBtn.UseVisualStyleBackColor = true;
            this.NetSndBtn.Click += new System.EventHandler(this.NetSndBtn_Click);
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.NetRcvPause);
            this.groupBox5.Controls.Add(this.NetClearBtn);
            this.groupBox5.Controls.Add(this.NetSaveBtn);
            this.groupBox5.Controls.Add(this.NetRcvShowSend);
            this.groupBox5.Controls.Add(this.NetRcvShowTime);
            this.groupBox5.Controls.Add(this.NetRcvHEX);
            this.groupBox5.Controls.Add(this.NetRcvASCII);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // NetRcvPause
            // 
            resources.ApplyResources(this.NetRcvPause, "NetRcvPause");
            this.NetRcvPause.Name = "NetRcvPause";
            this.NetRcvPause.UseVisualStyleBackColor = true;
            this.NetRcvPause.CheckedChanged += new System.EventHandler(this.NetRcvPause_CheckedChanged);
            // 
            // NetClearBtn
            // 
            resources.ApplyResources(this.NetClearBtn, "NetClearBtn");
            this.NetClearBtn.Name = "NetClearBtn";
            this.NetClearBtn.UseVisualStyleBackColor = true;
            this.NetClearBtn.Click += new System.EventHandler(this.NetClearBtn_Click);
            // 
            // NetSaveBtn
            // 
            resources.ApplyResources(this.NetSaveBtn, "NetSaveBtn");
            this.NetSaveBtn.Name = "NetSaveBtn";
            this.NetSaveBtn.UseVisualStyleBackColor = true;
            this.NetSaveBtn.Click += new System.EventHandler(this.NetSaveBtn_Click);
            // 
            // NetRcvShowSend
            // 
            resources.ApplyResources(this.NetRcvShowSend, "NetRcvShowSend");
            this.NetRcvShowSend.Name = "NetRcvShowSend";
            this.NetRcvShowSend.UseVisualStyleBackColor = true;
            // 
            // NetRcvShowTime
            // 
            resources.ApplyResources(this.NetRcvShowTime, "NetRcvShowTime");
            this.NetRcvShowTime.Name = "NetRcvShowTime";
            this.NetRcvShowTime.UseVisualStyleBackColor = true;
            // 
            // NetRcvHEX
            // 
            resources.ApplyResources(this.NetRcvHEX, "NetRcvHEX");
            this.NetRcvHEX.Name = "NetRcvHEX";
            this.NetRcvHEX.TabStop = true;
            this.NetRcvHEX.UseVisualStyleBackColor = true;
            // 
            // NetRcvASCII
            // 
            resources.ApplyResources(this.NetRcvASCII, "NetRcvASCII");
            this.NetRcvASCII.Checked = true;
            this.NetRcvASCII.Name = "NetRcvASCII";
            this.NetRcvASCII.TabStop = true;
            this.NetRcvASCII.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.NetSndTimerNum);
            this.groupBox6.Controls.Add(this.NetSndAutoSend);
            this.groupBox6.Controls.Add(this.NetSndNewLine);
            this.groupBox6.Controls.Add(this.NetSndHEX);
            this.groupBox6.Controls.Add(this.NetSndASCII);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // NetSndTimerNum
            // 
            resources.ApplyResources(this.NetSndTimerNum, "NetSndTimerNum");
            this.NetSndTimerNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NetSndTimerNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NetSndTimerNum.Name = "NetSndTimerNum";
            this.NetSndTimerNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NetSndTimerNum.ValueChanged += new System.EventHandler(this.NetSndTimerNum_ValueChanged);
            // 
            // NetSndAutoSend
            // 
            resources.ApplyResources(this.NetSndAutoSend, "NetSndAutoSend");
            this.NetSndAutoSend.Name = "NetSndAutoSend";
            this.NetSndAutoSend.UseVisualStyleBackColor = true;
            this.NetSndAutoSend.CheckedChanged += new System.EventHandler(this.NetSndAutoSend_CheckedChanged);
            // 
            // NetSndNewLine
            // 
            resources.ApplyResources(this.NetSndNewLine, "NetSndNewLine");
            this.NetSndNewLine.Name = "NetSndNewLine";
            this.NetSndNewLine.UseVisualStyleBackColor = true;
            // 
            // NetSndHEX
            // 
            resources.ApplyResources(this.NetSndHEX, "NetSndHEX");
            this.NetSndHEX.Name = "NetSndHEX";
            this.NetSndHEX.TabStop = true;
            this.NetSndHEX.UseVisualStyleBackColor = true;
            this.NetSndHEX.CheckedChanged += new System.EventHandler(this.NetSndHEX_CheckedChanged);
            // 
            // NetSndASCII
            // 
            resources.ApplyResources(this.NetSndASCII, "NetSndASCII");
            this.NetSndASCII.Checked = true;
            this.NetSndASCII.Name = "NetSndASCII";
            this.NetSndASCII.TabStop = true;
            this.NetSndASCII.UseVisualStyleBackColor = true;
            // 
            // SerialInfo
            // 
            resources.ApplyResources(this.SerialInfo, "SerialInfo");
            this.SerialInfo.Name = "SerialInfo";
            // 
            // NetInfo
            // 
            resources.ApplyResources(this.NetInfo, "NetInfo");
            this.NetInfo.Name = "NetInfo";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // SerialRxCnt
            // 
            resources.ApplyResources(this.SerialRxCnt, "SerialRxCnt");
            this.SerialRxCnt.Name = "SerialRxCnt";
            // 
            // SerialTxCnt
            // 
            resources.ApplyResources(this.SerialTxCnt, "SerialTxCnt");
            this.SerialTxCnt.Name = "SerialTxCnt";
            // 
            // NetRxCnt
            // 
            resources.ApplyResources(this.NetRxCnt, "NetRxCnt");
            this.NetRxCnt.Name = "NetRxCnt";
            // 
            // NetTxCnt
            // 
            resources.ApplyResources(this.NetTxCnt, "NetTxCnt");
            this.NetTxCnt.Name = "NetTxCnt";
            // 
            // SerialTimer
            // 
            this.SerialTimer.Tick += new System.EventHandler(this.SerialTimer_Tick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.NetTxCnt);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.NetRxCnt);
            this.panel1.Controls.Add(this.NetSndTextBox);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.NetSndBtn);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.NetInfo);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.SerialTxCnt);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.SerialRxCnt);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.SerialSndTextBox);
            this.panel2.Controls.Add(this.SerialSndBtn);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.SerialInfo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Name = "panel2";
            // 
            // NetTimer
            // 
            this.NetTimer.Tick += new System.EventHandler(this.NetTimer_Tick);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SerialSndTimerNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NetSndTimerNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox SerialBaudBox;
        private System.Windows.Forms.ComboBox SerialPortBox;
        private System.Windows.Forms.Button SerialOpenBtn;
        private System.Windows.Forms.Button SerialRfrshBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SerialRcvPause;
        private System.Windows.Forms.Button SerialClearBtn;
        private System.Windows.Forms.Button SerialSaveBtn;
        private System.Windows.Forms.CheckBox SerialRcvShowSend;
        private System.Windows.Forms.CheckBox SerialRcvShowTime;
        private System.Windows.Forms.RadioButton SerialRcvHEX;
        private System.Windows.Forms.RadioButton SerialRcvASCII;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SerialSndTimerNum;
        private System.Windows.Forms.CheckBox SerialSndAutoSend;
        private System.Windows.Forms.CheckBox SerialSndNewLine;
        private System.Windows.Forms.RadioButton SerialSndHEX;
        private System.Windows.Forms.RadioButton SerialSndASCII;
        private System.Windows.Forms.TextBox SerialRcvTextBox;
        private System.Windows.Forms.TextBox NetRcvTextBox;
        private System.Windows.Forms.TextBox SerialSndTextBox;
        private System.Windows.Forms.TextBox NetSndTextBox;
        private System.Windows.Forms.Button SerialSndBtn;
        private System.Windows.Forms.Button NetSndBtn;
        private System.Windows.Forms.TextBox NetPortTextBox;
        private System.Windows.Forms.TextBox NetIPTextBox;
        private System.Windows.Forms.ComboBox NetModeBox;
        private System.Windows.Forms.Button NetConnectBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox NetRcvPause;
        private System.Windows.Forms.Button NetClearBtn;
        private System.Windows.Forms.Button NetSaveBtn;
        private System.Windows.Forms.CheckBox NetRcvShowSend;
        private System.Windows.Forms.CheckBox NetRcvShowTime;
        private System.Windows.Forms.RadioButton NetRcvHEX;
        private System.Windows.Forms.RadioButton NetRcvASCII;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NetSndTimerNum;
        private System.Windows.Forms.CheckBox NetSndAutoSend;
        private System.Windows.Forms.CheckBox NetSndNewLine;
        private System.Windows.Forms.RadioButton NetSndHEX;
        private System.Windows.Forms.RadioButton NetSndASCII;
        private System.Windows.Forms.Label SerialInfo;
        private System.Windows.Forms.Label NetInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label SerialRxCnt;
        private System.Windows.Forms.Label SerialTxCnt;
        private System.Windows.Forms.Label NetRxCnt;
        private System.Windows.Forms.Label NetTxCnt;
        private System.Windows.Forms.Timer SerialTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox NetClientList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NetHideIPBox;
        private System.Windows.Forms.TextBox NetHidePortBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer NetTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

