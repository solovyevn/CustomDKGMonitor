namespace CustomDKGMonitor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxPortSelect = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.buttonRefreshPortSelect = new System.Windows.Forms.Button();
            this.buttonLogFolderSelect = new System.Windows.Forms.Button();
            this.labelLogFolder = new System.Windows.Forms.Label();
            this.textBoxLogFolder = new System.Windows.Forms.TextBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonAlarmEnableDisable = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelBaud = new System.Windows.Forms.Label();
            this.labelDataBits = new System.Windows.Forms.Label();
            this.labelStopBits = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.labelHandshake = new System.Windows.Forms.Label();
            this.textBoxBaudRate = new System.Windows.Forms.TextBox();
            this.textBoxDataBits = new System.Windows.Forms.TextBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.labelLogPeriod = new System.Windows.Forms.Label();
            this.textBoxLogPeriod = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogLog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogAlertSound = new System.Windows.Forms.OpenFileDialog();
            this.labelAlarmSoundFile = new System.Windows.Forms.Label();
            this.textBoxAlarmSoundFile = new System.Windows.Forms.TextBox();
            this.buttonAlarmSoundFileSelect = new System.Windows.Forms.Button();
            this.panelMonitoring = new System.Windows.Forms.Panel();
            this.buttonTestAlarm = new System.Windows.Forms.Button();
            this.textBoxNoDataAlarmPeriod = new System.Windows.Forms.TextBox();
            this.labelNoDataAlarmPeriod = new System.Windows.Forms.Label();
            this.numericUpDownMaxCoolantTemp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinCoolantTemp = new System.Windows.Forms.NumericUpDown();
            this.textBoxCoolantTemp = new System.Windows.Forms.TextBox();
            this.labelMaxCoolantTemp = new System.Windows.Forms.Label();
            this.labelMinCoolantTemp = new System.Windows.Forms.Label();
            this.labelCoolantTemp = new System.Windows.Forms.Label();
            this.textBoxDKGDateTime = new System.Windows.Forms.TextBox();
            this.labelLastDataUpdate = new System.Windows.Forms.Label();
            this.timerNoData = new System.Windows.Forms.Timer(this.components);
            this.panelMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCoolantTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinCoolantTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPortSelect
            // 
            this.comboBoxPortSelect.AccessibleDescription = null;
            this.comboBoxPortSelect.AccessibleName = null;
            resources.ApplyResources(this.comboBoxPortSelect, "comboBoxPortSelect");
            this.comboBoxPortSelect.BackgroundImage = null;
            this.comboBoxPortSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPortSelect.Font = null;
            this.comboBoxPortSelect.FormattingEnabled = true;
            this.comboBoxPortSelect.Name = "comboBoxPortSelect";
            this.comboBoxPortSelect.Sorted = true;
            // 
            // labelPort
            // 
            this.labelPort.AccessibleDescription = null;
            this.labelPort.AccessibleName = null;
            resources.ApplyResources(this.labelPort, "labelPort");
            this.labelPort.Font = null;
            this.labelPort.Name = "labelPort";
            // 
            // buttonRefreshPortSelect
            // 
            this.buttonRefreshPortSelect.AccessibleDescription = null;
            this.buttonRefreshPortSelect.AccessibleName = null;
            resources.ApplyResources(this.buttonRefreshPortSelect, "buttonRefreshPortSelect");
            this.buttonRefreshPortSelect.BackgroundImage = null;
            this.buttonRefreshPortSelect.Font = null;
            this.buttonRefreshPortSelect.Name = "buttonRefreshPortSelect";
            this.buttonRefreshPortSelect.UseVisualStyleBackColor = true;
            this.buttonRefreshPortSelect.Click += new System.EventHandler(this.buttonRefreshPortSelect_Click);
            // 
            // buttonLogFolderSelect
            // 
            this.buttonLogFolderSelect.AccessibleDescription = null;
            this.buttonLogFolderSelect.AccessibleName = null;
            resources.ApplyResources(this.buttonLogFolderSelect, "buttonLogFolderSelect");
            this.buttonLogFolderSelect.BackgroundImage = null;
            this.buttonLogFolderSelect.Font = null;
            this.buttonLogFolderSelect.Name = "buttonLogFolderSelect";
            this.buttonLogFolderSelect.UseVisualStyleBackColor = true;
            this.buttonLogFolderSelect.Click += new System.EventHandler(this.buttonLogFolderSelect_Click);
            // 
            // labelLogFolder
            // 
            this.labelLogFolder.AccessibleDescription = null;
            this.labelLogFolder.AccessibleName = null;
            resources.ApplyResources(this.labelLogFolder, "labelLogFolder");
            this.labelLogFolder.Font = null;
            this.labelLogFolder.Name = "labelLogFolder";
            // 
            // textBoxLogFolder
            // 
            this.textBoxLogFolder.AccessibleDescription = null;
            this.textBoxLogFolder.AccessibleName = null;
            resources.ApplyResources(this.textBoxLogFolder, "textBoxLogFolder");
            this.textBoxLogFolder.BackgroundImage = null;
            this.textBoxLogFolder.Font = null;
            this.textBoxLogFolder.Name = "textBoxLogFolder";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.AccessibleDescription = null;
            this.buttonStartStop.AccessibleName = null;
            resources.ApplyResources(this.buttonStartStop, "buttonStartStop");
            this.buttonStartStop.BackgroundImage = null;
            this.buttonStartStop.Font = null;
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // buttonAlarmEnableDisable
            // 
            this.buttonAlarmEnableDisable.AccessibleDescription = null;
            this.buttonAlarmEnableDisable.AccessibleName = null;
            resources.ApplyResources(this.buttonAlarmEnableDisable, "buttonAlarmEnableDisable");
            this.buttonAlarmEnableDisable.BackgroundImage = null;
            this.buttonAlarmEnableDisable.Font = null;
            this.buttonAlarmEnableDisable.Name = "buttonAlarmEnableDisable";
            this.buttonAlarmEnableDisable.UseVisualStyleBackColor = true;
            this.buttonAlarmEnableDisable.Click += new System.EventHandler(this.buttonAlarmEnableDisable_Click);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // labelBaud
            // 
            this.labelBaud.AccessibleDescription = null;
            this.labelBaud.AccessibleName = null;
            resources.ApplyResources(this.labelBaud, "labelBaud");
            this.labelBaud.Font = null;
            this.labelBaud.Name = "labelBaud";
            // 
            // labelDataBits
            // 
            this.labelDataBits.AccessibleDescription = null;
            this.labelDataBits.AccessibleName = null;
            resources.ApplyResources(this.labelDataBits, "labelDataBits");
            this.labelDataBits.Font = null;
            this.labelDataBits.Name = "labelDataBits";
            // 
            // labelStopBits
            // 
            this.labelStopBits.AccessibleDescription = null;
            this.labelStopBits.AccessibleName = null;
            resources.ApplyResources(this.labelStopBits, "labelStopBits");
            this.labelStopBits.Font = null;
            this.labelStopBits.Name = "labelStopBits";
            // 
            // labelParity
            // 
            this.labelParity.AccessibleDescription = null;
            this.labelParity.AccessibleName = null;
            resources.ApplyResources(this.labelParity, "labelParity");
            this.labelParity.Font = null;
            this.labelParity.Name = "labelParity";
            // 
            // labelHandshake
            // 
            this.labelHandshake.AccessibleDescription = null;
            this.labelHandshake.AccessibleName = null;
            resources.ApplyResources(this.labelHandshake, "labelHandshake");
            this.labelHandshake.Font = null;
            this.labelHandshake.Name = "labelHandshake";
            // 
            // textBoxBaudRate
            // 
            this.textBoxBaudRate.AccessibleDescription = null;
            this.textBoxBaudRate.AccessibleName = null;
            resources.ApplyResources(this.textBoxBaudRate, "textBoxBaudRate");
            this.textBoxBaudRate.BackgroundImage = null;
            this.textBoxBaudRate.Font = null;
            this.textBoxBaudRate.Name = "textBoxBaudRate";
            // 
            // textBoxDataBits
            // 
            this.textBoxDataBits.AccessibleDescription = null;
            this.textBoxDataBits.AccessibleName = null;
            resources.ApplyResources(this.textBoxDataBits, "textBoxDataBits");
            this.textBoxDataBits.BackgroundImage = null;
            this.textBoxDataBits.Font = null;
            this.textBoxDataBits.Name = "textBoxDataBits";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.AccessibleDescription = null;
            this.comboBoxStopBits.AccessibleName = null;
            resources.ApplyResources(this.comboBoxStopBits, "comboBoxStopBits");
            this.comboBoxStopBits.BackgroundImage = null;
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.Font = null;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.AccessibleDescription = null;
            this.comboBoxParity.AccessibleName = null;
            resources.ApplyResources(this.comboBoxParity, "comboBoxParity");
            this.comboBoxParity.BackgroundImage = null;
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.Font = null;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Name = "comboBoxParity";
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.AccessibleDescription = null;
            this.comboBoxHandshake.AccessibleName = null;
            resources.ApplyResources(this.comboBoxHandshake, "comboBoxHandshake");
            this.comboBoxHandshake.BackgroundImage = null;
            this.comboBoxHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHandshake.Font = null;
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AccessibleDescription = null;
            this.checkBoxLog.AccessibleName = null;
            resources.ApplyResources(this.checkBoxLog, "checkBoxLog");
            this.checkBoxLog.BackgroundImage = null;
            this.checkBoxLog.Font = null;
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.checkBoxLog_CheckedChanged);
            // 
            // labelLogPeriod
            // 
            this.labelLogPeriod.AccessibleDescription = null;
            this.labelLogPeriod.AccessibleName = null;
            resources.ApplyResources(this.labelLogPeriod, "labelLogPeriod");
            this.labelLogPeriod.Font = null;
            this.labelLogPeriod.Name = "labelLogPeriod";
            // 
            // textBoxLogPeriod
            // 
            this.textBoxLogPeriod.AccessibleDescription = null;
            this.textBoxLogPeriod.AccessibleName = null;
            resources.ApplyResources(this.textBoxLogPeriod, "textBoxLogPeriod");
            this.textBoxLogPeriod.BackgroundImage = null;
            this.textBoxLogPeriod.Font = null;
            this.textBoxLogPeriod.Name = "textBoxLogPeriod";
            // 
            // folderBrowserDialogLog
            // 
            resources.ApplyResources(this.folderBrowserDialogLog, "folderBrowserDialogLog");
            // 
            // openFileDialogAlertSound
            // 
            this.openFileDialogAlertSound.DefaultExt = "wav";
            resources.ApplyResources(this.openFileDialogAlertSound, "openFileDialogAlertSound");
            // 
            // labelAlarmSoundFile
            // 
            this.labelAlarmSoundFile.AccessibleDescription = null;
            this.labelAlarmSoundFile.AccessibleName = null;
            resources.ApplyResources(this.labelAlarmSoundFile, "labelAlarmSoundFile");
            this.labelAlarmSoundFile.Font = null;
            this.labelAlarmSoundFile.Name = "labelAlarmSoundFile";
            // 
            // textBoxAlarmSoundFile
            // 
            this.textBoxAlarmSoundFile.AccessibleDescription = null;
            this.textBoxAlarmSoundFile.AccessibleName = null;
            resources.ApplyResources(this.textBoxAlarmSoundFile, "textBoxAlarmSoundFile");
            this.textBoxAlarmSoundFile.BackgroundImage = null;
            this.textBoxAlarmSoundFile.Font = null;
            this.textBoxAlarmSoundFile.Name = "textBoxAlarmSoundFile";
            // 
            // buttonAlarmSoundFileSelect
            // 
            this.buttonAlarmSoundFileSelect.AccessibleDescription = null;
            this.buttonAlarmSoundFileSelect.AccessibleName = null;
            resources.ApplyResources(this.buttonAlarmSoundFileSelect, "buttonAlarmSoundFileSelect");
            this.buttonAlarmSoundFileSelect.BackgroundImage = null;
            this.buttonAlarmSoundFileSelect.Font = null;
            this.buttonAlarmSoundFileSelect.Name = "buttonAlarmSoundFileSelect";
            this.buttonAlarmSoundFileSelect.UseVisualStyleBackColor = true;
            this.buttonAlarmSoundFileSelect.Click += new System.EventHandler(this.buttonAlarmSoundFileSelect_Click);
            // 
            // panelMonitoring
            // 
            this.panelMonitoring.AccessibleDescription = null;
            this.panelMonitoring.AccessibleName = null;
            resources.ApplyResources(this.panelMonitoring, "panelMonitoring");
            this.panelMonitoring.BackgroundImage = null;
            this.panelMonitoring.Controls.Add(this.buttonTestAlarm);
            this.panelMonitoring.Controls.Add(this.textBoxNoDataAlarmPeriod);
            this.panelMonitoring.Controls.Add(this.labelNoDataAlarmPeriod);
            this.panelMonitoring.Controls.Add(this.numericUpDownMaxCoolantTemp);
            this.panelMonitoring.Controls.Add(this.numericUpDownMinCoolantTemp);
            this.panelMonitoring.Controls.Add(this.textBoxCoolantTemp);
            this.panelMonitoring.Controls.Add(this.labelMaxCoolantTemp);
            this.panelMonitoring.Controls.Add(this.labelMinCoolantTemp);
            this.panelMonitoring.Controls.Add(this.labelCoolantTemp);
            this.panelMonitoring.Controls.Add(this.textBoxDKGDateTime);
            this.panelMonitoring.Controls.Add(this.labelLastDataUpdate);
            this.panelMonitoring.Controls.Add(this.buttonAlarmEnableDisable);
            this.panelMonitoring.Font = null;
            this.panelMonitoring.Name = "panelMonitoring";
            // 
            // buttonTestAlarm
            // 
            this.buttonTestAlarm.AccessibleDescription = null;
            this.buttonTestAlarm.AccessibleName = null;
            resources.ApplyResources(this.buttonTestAlarm, "buttonTestAlarm");
            this.buttonTestAlarm.BackgroundImage = null;
            this.buttonTestAlarm.Font = null;
            this.buttonTestAlarm.Name = "buttonTestAlarm";
            this.buttonTestAlarm.UseVisualStyleBackColor = true;
            this.buttonTestAlarm.Click += new System.EventHandler(this.buttonTestAlarm_Click);
            // 
            // textBoxNoDataAlarmPeriod
            // 
            this.textBoxNoDataAlarmPeriod.AccessibleDescription = null;
            this.textBoxNoDataAlarmPeriod.AccessibleName = null;
            resources.ApplyResources(this.textBoxNoDataAlarmPeriod, "textBoxNoDataAlarmPeriod");
            this.textBoxNoDataAlarmPeriod.BackgroundImage = null;
            this.textBoxNoDataAlarmPeriod.Font = null;
            this.textBoxNoDataAlarmPeriod.Name = "textBoxNoDataAlarmPeriod";
            // 
            // labelNoDataAlarmPeriod
            // 
            this.labelNoDataAlarmPeriod.AccessibleDescription = null;
            this.labelNoDataAlarmPeriod.AccessibleName = null;
            resources.ApplyResources(this.labelNoDataAlarmPeriod, "labelNoDataAlarmPeriod");
            this.labelNoDataAlarmPeriod.Font = null;
            this.labelNoDataAlarmPeriod.Name = "labelNoDataAlarmPeriod";
            // 
            // numericUpDownMaxCoolantTemp
            // 
            this.numericUpDownMaxCoolantTemp.AccessibleDescription = null;
            this.numericUpDownMaxCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.numericUpDownMaxCoolantTemp, "numericUpDownMaxCoolantTemp");
            this.numericUpDownMaxCoolantTemp.Font = null;
            this.numericUpDownMaxCoolantTemp.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownMaxCoolantTemp.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numericUpDownMaxCoolantTemp.Name = "numericUpDownMaxCoolantTemp";
            // 
            // numericUpDownMinCoolantTemp
            // 
            this.numericUpDownMinCoolantTemp.AccessibleDescription = null;
            this.numericUpDownMinCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.numericUpDownMinCoolantTemp, "numericUpDownMinCoolantTemp");
            this.numericUpDownMinCoolantTemp.Font = null;
            this.numericUpDownMinCoolantTemp.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownMinCoolantTemp.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numericUpDownMinCoolantTemp.Name = "numericUpDownMinCoolantTemp";
            // 
            // textBoxCoolantTemp
            // 
            this.textBoxCoolantTemp.AccessibleDescription = null;
            this.textBoxCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.textBoxCoolantTemp, "textBoxCoolantTemp");
            this.textBoxCoolantTemp.BackColor = System.Drawing.Color.White;
            this.textBoxCoolantTemp.BackgroundImage = null;
            this.textBoxCoolantTemp.Name = "textBoxCoolantTemp";
            this.textBoxCoolantTemp.ReadOnly = true;
            // 
            // labelMaxCoolantTemp
            // 
            this.labelMaxCoolantTemp.AccessibleDescription = null;
            this.labelMaxCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.labelMaxCoolantTemp, "labelMaxCoolantTemp");
            this.labelMaxCoolantTemp.Font = null;
            this.labelMaxCoolantTemp.Name = "labelMaxCoolantTemp";
            // 
            // labelMinCoolantTemp
            // 
            this.labelMinCoolantTemp.AccessibleDescription = null;
            this.labelMinCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.labelMinCoolantTemp, "labelMinCoolantTemp");
            this.labelMinCoolantTemp.Font = null;
            this.labelMinCoolantTemp.Name = "labelMinCoolantTemp";
            // 
            // labelCoolantTemp
            // 
            this.labelCoolantTemp.AccessibleDescription = null;
            this.labelCoolantTemp.AccessibleName = null;
            resources.ApplyResources(this.labelCoolantTemp, "labelCoolantTemp");
            this.labelCoolantTemp.Font = null;
            this.labelCoolantTemp.MaximumSize = new System.Drawing.Size(80, 0);
            this.labelCoolantTemp.Name = "labelCoolantTemp";
            // 
            // textBoxDKGDateTime
            // 
            this.textBoxDKGDateTime.AccessibleDescription = null;
            this.textBoxDKGDateTime.AccessibleName = null;
            resources.ApplyResources(this.textBoxDKGDateTime, "textBoxDKGDateTime");
            this.textBoxDKGDateTime.BackColor = System.Drawing.Color.White;
            this.textBoxDKGDateTime.BackgroundImage = null;
            this.textBoxDKGDateTime.Font = null;
            this.textBoxDKGDateTime.Name = "textBoxDKGDateTime";
            this.textBoxDKGDateTime.ReadOnly = true;
            // 
            // labelLastDataUpdate
            // 
            this.labelLastDataUpdate.AccessibleDescription = null;
            this.labelLastDataUpdate.AccessibleName = null;
            resources.ApplyResources(this.labelLastDataUpdate, "labelLastDataUpdate");
            this.labelLastDataUpdate.Font = null;
            this.labelLastDataUpdate.Name = "labelLastDataUpdate";
            // 
            // timerNoData
            // 
            this.timerNoData.Tick += new System.EventHandler(this.timerNoData_Tick);
            // 
            // Form1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panelMonitoring);
            this.Controls.Add(this.buttonAlarmSoundFileSelect);
            this.Controls.Add(this.textBoxAlarmSoundFile);
            this.Controls.Add(this.labelAlarmSoundFile);
            this.Controls.Add(this.textBoxLogPeriod);
            this.Controls.Add(this.labelLogPeriod);
            this.Controls.Add(this.checkBoxLog);
            this.Controls.Add(this.comboBoxHandshake);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.textBoxDataBits);
            this.Controls.Add(this.textBoxBaudRate);
            this.Controls.Add(this.labelHandshake);
            this.Controls.Add(this.labelParity);
            this.Controls.Add(this.labelStopBits);
            this.Controls.Add(this.labelDataBits);
            this.Controls.Add(this.labelBaud);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.textBoxLogFolder);
            this.Controls.Add(this.labelLogFolder);
            this.Controls.Add(this.buttonLogFolderSelect);
            this.Controls.Add(this.buttonRefreshPortSelect);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.comboBoxPortSelect);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelMonitoring.ResumeLayout(false);
            this.panelMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCoolantTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinCoolantTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPortSelect;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button buttonRefreshPortSelect;
        private System.Windows.Forms.Button buttonLogFolderSelect;
        private System.Windows.Forms.Label labelLogFolder;
        private System.Windows.Forms.TextBox textBoxLogFolder;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonAlarmEnableDisable;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label labelBaud;
        private System.Windows.Forms.Label labelDataBits;
        private System.Windows.Forms.Label labelStopBits;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.Label labelHandshake;
        private System.Windows.Forms.TextBox textBoxBaudRate;
        private System.Windows.Forms.TextBox textBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Label labelLogPeriod;
        private System.Windows.Forms.TextBox textBoxLogPeriod;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLog;
        private System.Windows.Forms.OpenFileDialog openFileDialogAlertSound;
        private System.Windows.Forms.Label labelAlarmSoundFile;
        private System.Windows.Forms.TextBox textBoxAlarmSoundFile;
        private System.Windows.Forms.Button buttonAlarmSoundFileSelect;
        private System.Windows.Forms.Panel panelMonitoring;
        private System.Windows.Forms.Label labelMinCoolantTemp;
        private System.Windows.Forms.Label labelCoolantTemp;
        private System.Windows.Forms.TextBox textBoxDKGDateTime;
        private System.Windows.Forms.Label labelLastDataUpdate;
        private System.Windows.Forms.TextBox textBoxCoolantTemp;
        private System.Windows.Forms.Label labelMaxCoolantTemp;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxCoolantTemp;
        private System.Windows.Forms.NumericUpDown numericUpDownMinCoolantTemp;
        private System.Windows.Forms.Timer timerNoData;
        private System.Windows.Forms.TextBox textBoxNoDataAlarmPeriod;
        private System.Windows.Forms.Label labelNoDataAlarmPeriod;
        private System.Windows.Forms.Button buttonTestAlarm;
    }
}

