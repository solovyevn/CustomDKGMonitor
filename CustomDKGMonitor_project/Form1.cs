using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Media;
using System.Resources;

namespace CustomDKGMonitor
{
    public partial class Form1 : Form
    {
        private ResourceManager RM = new ResourceManager("CustomDKGMonitor.WinFormStrings", typeof(Form1).Assembly);
        private SerialPort serialPortToLog = null; //Объект последовательного порта
        private static bool IsRunning = false; //Установлено соединение
        private static bool IsAlarmEnabled = false;  //Звуковая сигнализация включена
        private static bool IsAlarmInProgress = false;  //Издается звуковой сигнал
        private CDMSettings Settings = null; //Объект настроек
        delegate void MsgParseCallback(string text); //Делегат для обработки данных в процессе отличном от процесса обработчика события
        private static StringBuilder InnerBuffer; //Буфер с данными для выявления значений параметров
        private static StringBuilder MidBuffer; //Буфер с принятыми данными
        private static byte[] StartSequence = new byte[4]{0x3F,0x68,0x01,0x3F}; //Последовательность означающая начало сообщения от устройства
        private static int SerialDataSize = 108; //Размер сообщения от устройства
        private static DateTime LastLogWrite = DateTime.MinValue; //Дата и Время последней записи лога
        private static DateTime LastUpdate = DateTime.MinValue; //Дата и Время последненго обновления данных в форме
        private static DateTime DKGDateTime; //Дата и Время на устройстве полученные из сообщения
        private static string NotifyIconTmpText; //Переменная для временного хранения текста иконки в трейе
        SoundPlayer player; //Объект проигрывателя для воспроизведения сигнализации
        private static bool NoDataWarning = false; //Показывается предупреждение об отсутствии передачи данных
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings = new CDMSettings();
            Settings.LoadSetfromFile();
            initializeFields();
            notifyIcon1.Text = RM.GetString("strAppName");
            notifyIcon1.BalloonTipTitle = RM.GetString("strAppName");
        }

        private void buttonRefreshPortSelect_Click(object sender, EventArgs e)
        {
            Settings.LoadSetfromFile();
            initializeFields();
        }

        private void buttonLogFolderSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogLog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Settings.SetLogFolderName(folderBrowserDialogLog.SelectedPath);
                textBoxLogFolder.Text = Settings.GetLogFolderName();
            }
        }
        private void buttonAlarmSoundFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogAlertSound.ShowDialog();
            if (result == DialogResult.OK)
            {
                Settings.SetAlarmSoundFile(openFileDialogAlertSound.FileName);
                textBoxAlarmSoundFile.Text = Settings.GetAlarmSoundFile();
            }
        }


        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                try
                {
                    Settings.SetSerialPortSelect(comboBoxPortSelect.SelectedIndex);
                    Settings.SetBaudRate(textBoxBaudRate.Text);
                    Settings.SetDataBits(textBoxDataBits.Text);
                    Settings.SetStopBitsSelect(comboBoxStopBits.SelectedIndex);
                    Settings.SetParitySelect(comboBoxParity.SelectedIndex);
                    Settings.SetHandshakeSelect(comboBoxHandshake.SelectedIndex);
                    Settings.SetLogEnabled(checkBoxLog.Checked);
                    Settings.SetLogFolderName(textBoxLogFolder.Text);
                    Settings.SetLogPeriod(textBoxLogPeriod.Text);
                    Settings.SetAlarmSoundFile(textBoxAlarmSoundFile.Text);
                    Settings.SaveSetToFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, RM.GetString("strErrInSettings"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    serialPortToLog = initializeSerialPort();
                    if (serialPortToLog == null) return;
                    serialPortToLog.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceivedHandler);
                    serialPortToLog.Open();
                    InnerBuffer = new StringBuilder(SerialDataSize, SerialDataSize);
                    InnerBuffer.Length = 0;
                    MidBuffer = new StringBuilder();
                    MidBuffer.Length = 0;
                    if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strPortOpen"));
                }
                catch (Exception ex)
                {
                    if(serialPortToLog!=null)serialPortToLog.Close();
                    MessageBox.Show(ex.Message, RM.GetString("strErrOpenPort"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strErrOpenPort"));
                    return;
                }
                IsRunning = true;
                this.Height = 280;
                buttonStartStop.Location=new Point(100,205);
                labelLogFolder.Visible = false;
                labelLogPeriod.Visible = false;
                textBoxLogFolder.Visible = false;
                textBoxLogPeriod.Visible = false;
                buttonLogFolderSelect.Visible = false;
                checkBoxLog.Visible = false;
                notifyIcon1.Text = RM.GetString("strAppName")+" "+RM.GetString("strRunning")+" "+RM.GetString("strAlarmDisabled");
                buttonRefreshPortSelect.Enabled = false;
                comboBoxPortSelect.Enabled = false;
                textBoxBaudRate.Enabled = false;
                textBoxDataBits.Enabled = false;
                comboBoxHandshake.Enabled = false;
                comboBoxParity.Enabled = false;
                comboBoxStopBits.Enabled = false;
                checkBoxLog.Enabled = false;
                textBoxLogFolder.Enabled = false;
                buttonLogFolderSelect.Enabled = false;
                textBoxLogPeriod.Enabled = false;
                textBoxAlarmSoundFile.Enabled = false;
                buttonAlarmSoundFileSelect.Enabled = false;

                buttonStartStop.Text = RM.GetString("strStop");

                panelMonitoring.Visible = true;
                panelMonitoring.Enabled = true;
                buttonAlarmEnableDisable.Enabled = true;
                numericUpDownMaxCoolantTemp.Enabled = true;
                numericUpDownMinCoolantTemp.Enabled = true;
                numericUpDownMaxCoolantTemp.Value = Settings.GetMaxCoolantTemp();
                numericUpDownMinCoolantTemp.Value = Settings.GetMinCoolantTemp();
                textBoxNoDataAlarmPeriod.Enabled = true;
                textBoxNoDataAlarmPeriod.Text = Settings.GetNoDataAlarmPeriod().ToString();
                buttonTestAlarm.Enabled = false;
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strStarted."));
            }
            else
            {
                if (IsAlarmEnabled)
                {
                    MessageBox.Show(RM.GetString("strDisAlarmBeforeStop"), RM.GetString("strAlarmStillEnabled"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                IsRunning = false;
                this.Height = 400;
                buttonStartStop.Location = new Point(100, 325);
                labelLogFolder.Visible = true;
                labelLogPeriod.Visible = true;
                textBoxLogFolder.Visible = true;
                textBoxLogPeriod.Visible = true;
                buttonLogFolderSelect.Visible = true;
                checkBoxLog.Visible = true;
                if (serialPortToLog != null)
                {
                    serialPortToLog.Close();
                    if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strPortClose"));
                }
                notifyIcon1.Text = RM.GetString("strAppName")+" "+RM.GetString("strIsStopped");
                buttonRefreshPortSelect.Enabled = true;
                comboBoxPortSelect.Enabled = true;
                textBoxBaudRate.Enabled = true;
                textBoxDataBits.Enabled = true;
                comboBoxHandshake.Enabled = true;
                comboBoxParity.Enabled = true;
                comboBoxStopBits.Enabled = true;
                checkBoxLog.Enabled = true;
                textBoxLogFolder.Enabled = true;
                buttonLogFolderSelect.Enabled = true;
                textBoxLogPeriod.Enabled = true;
                textBoxAlarmSoundFile.Enabled = true;
                buttonAlarmSoundFileSelect.Enabled = true;

                buttonStartStop.Text = RM.GetString("strStart");

                panelMonitoring.Visible = false;
                panelMonitoring.Enabled = false;
                buttonAlarmEnableDisable.Enabled = false;
                numericUpDownMaxCoolantTemp.Enabled = false;
                numericUpDownMinCoolantTemp.Enabled = false;
                textBoxNoDataAlarmPeriod.Enabled = false;
                buttonTestAlarm.Enabled = false;
                textBoxDKGDateTime.Text = RM.GetString("strNA");
                textBoxCoolantTemp.Text = RM.GetString("strNA");
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strStopped"));
            }
        }

        #region Icon
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = false;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (!IsRunning)
            {
                sb.Append(RM.GetString("strAppName")+" "+RM.GetString("strIsStopped"));
                if (textBoxDKGDateTime.Text != "") sb.Append(" " + RM.GetString("strLastDataUpd") + ": " + textBoxDKGDateTime.Text);
                notifyIcon1.BalloonTipIcon=ToolTipIcon.Warning;
            }
            else
            {
                sb.Append(RM.GetString("strAppName") + " " + RM.GetString("strRunning"));
                if (IsAlarmEnabled && !IsAlarmInProgress) sb.Append(" "+RM.GetString("strAlarmEnabled"));
                if (!IsAlarmEnabled) sb.Append(" " + RM.GetString("strAlarmDisabled"));
                if (IsAlarmInProgress) sb.Append(RM.GetString("strAlarmExcl"));
                if (textBoxDKGDateTime.Text != "") sb.Append(" " + RM.GetString("strLastDataUpd") + ": " + textBoxDKGDateTime.Text);
                sb.Append(" " + RM.GetString("strCoolantTemp") + ": " + textBoxCoolantTemp.Text);
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }
            notifyIcon1.BalloonTipText = sb.ToString();
            notifyIcon1.ShowBalloonTip(15000);
        }
        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        #endregion

        private void initializePortListComboBox()
        {
            comboBoxPortSelect.Items.Clear();
            try
            {
                comboBoxPortSelect.Items.AddRange(SerialPort.GetPortNames());
                comboBoxPortSelect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + RM.GetString("strMakeSurePorts"), RM.GetString("strErrEnumPorts"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void initializeFields()
        {
            try
            {
                initializePortListComboBox();
                comboBoxPortSelect.SelectedIndex = Settings.GetSerialPortSelect();
                textBoxBaudRate.Text = Settings.GetBaudRate().ToString();
                textBoxDataBits.Text = Settings.GetDataBits().ToString();
                comboBoxHandshake.Items.Clear();
                comboBoxHandshake.Items.Add("None");
                comboBoxHandshake.Items.Add("RTS");
                comboBoxHandshake.Items.Add("XON/XOFF");
                comboBoxHandshake.Items.Add("RTS and XON/XOFF");
                comboBoxHandshake.SelectedIndex = Settings.GetHandshakeSelect();
                comboBoxParity.Items.Clear();
                comboBoxParity.Items.Add("None");
                comboBoxParity.Items.Add("Even");
                comboBoxParity.Items.Add("Odd");
                comboBoxParity.Items.Add("Mark");
                comboBoxParity.Items.Add("Space");
                comboBoxParity.SelectedIndex = Settings.GetParitySelect();
                comboBoxStopBits.Items.Clear();
                comboBoxStopBits.Items.Add("None");
                comboBoxStopBits.Items.Add("1");
                comboBoxStopBits.Items.Add("1.5");
                comboBoxStopBits.Items.Add("2");
                comboBoxStopBits.SelectedIndex = Settings.GetStopBitsSelect();
                if (Settings.IsLogEnabled())
                {
                    checkBoxLog.Checked = true;
                    textBoxLogFolder.Enabled = true;
                    textBoxLogPeriod.Enabled = true;
                    buttonLogFolderSelect.Enabled = true;
                }
                else
                {
                    checkBoxLog.Checked = false;
                    textBoxLogFolder.Enabled = false;
                    textBoxLogPeriod.Enabled = false;
                    buttonLogFolderSelect.Enabled = false;
                }
                textBoxLogFolder.Text = Settings.GetLogFolderName();
                textBoxLogPeriod.Text = Settings.GetLogPeriod().ToString();
                textBoxAlarmSoundFile.Text = Settings.GetAlarmSoundFile();
                numericUpDownMinCoolantTemp.Value = Settings.GetMinCoolantTemp();
                numericUpDownMaxCoolantTemp.Value = Settings.GetMaxCoolantTemp();
                textBoxNoDataAlarmPeriod.Text = Settings.GetNoDataAlarmPeriod().ToString();
                buttonStartStop.Text = RM.GetString("strStart");
                buttonAlarmEnableDisable.Text = RM.GetString("strEnableAlarm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/n" + RM.GetString("strTryDelSet"), RM.GetString("strInitErr"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private SerialPort initializeSerialPort()
        {
            SerialPort serialPort = new SerialPort(comboBoxPortSelect.GetItemText(comboBoxPortSelect.Items[(Settings.GetSerialPortSelect())]));
            serialPort.BaudRate = Settings.GetBaudRate();
            serialPort.DataBits = Settings.GetDataBits();
            switch (Settings.GetStopBitsSelect())
            {
                case 0: serialPort.StopBits=StopBits.None;
                    break;
                case 1: serialPort.StopBits=StopBits.One;
                    break;
                case 2: serialPort.StopBits=StopBits.OnePointFive;
                    break;
                case 3: serialPort.StopBits=StopBits.Two;
                    break;
            }
            switch (Settings.GetParitySelect())
            {
                case 0: serialPort.Parity = Parity.None;
                    break;
                case 1: serialPort.Parity = Parity.Even;
                    break;
                case 2: serialPort.Parity = Parity.Odd;
                    break;
                case 3: serialPort.Parity = Parity.Mark;
                    break;
                case 4: serialPort.Parity = Parity.Space;
                    break;
            }
            switch (Settings.GetHandshakeSelect())
            {
                case 0: serialPort.Handshake = Handshake.None;
                    break;
                case 1: serialPort.Handshake = Handshake.RequestToSend;
                    break;
                case 2: serialPort.Handshake = Handshake.XOnXOff;
                    break;
                case 3: serialPort.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
            }
            return serialPort;
        }

        private void SerialPortDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            string data = serialPort.ReadExisting();
            MidBuffer.Append(data);
            if (MidBuffer.Length >= SerialDataSize + StartSequence.Length)
            {
                data = MidBuffer.ToString();
                MidBuffer.Remove(0, MidBuffer.Length);
                MidBuffer.Length = 0;
                int index = -1;
                index = data.IndexOf(Encoding.ASCII.GetString(StartSequence));
                if (index >= 0)
                {
                    if (InnerBuffer.Length == 0)
                    {
                        if (data.Length - index >= SerialDataSize)
                        {
                            string tmp = data.Substring(index + SerialDataSize);
                            InnerBuffer.Append(data, index, SerialDataSize);
                            MidBuffer.Append(tmp);
                        }
                        else
                        {
                            InnerBuffer.Append(data, index, data.Length - index);
                        }
                    }
                    else if(InnerBuffer.Length > 0 && InnerBuffer.Length <= SerialDataSize)
                    {
                        if (InnerBuffer.Length + index <= SerialDataSize)
                        {
                            string tmp = data.Substring(index);
                            InnerBuffer.Append(data, 0, index);
                            MidBuffer.Append(tmp);
                        }
                        else
                        {
                            //ветка работает только при ошибке приема
                            InnerBuffer.Remove(0, InnerBuffer.Length);
                            InnerBuffer.Length = 0;
                            if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strRecieveErr") + " " + RM.GetString("strSkipData"));
                        }
                    }
                }
                else
                {
                    if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strRecieveErr") + " " + RM.GetString("strIndexLow0"));
                    //ветка работает только при ошибке приема
                }
                if (InnerBuffer.Length == SerialDataSize)
                {
                    //обработка данных буфера
                    string Msg = InnerBuffer.ToString();
                    DataMsgParse(Msg);
                    //конец обработки
                    InnerBuffer.Remove(0, InnerBuffer.Length);
                    InnerBuffer.Length = 0;
                }
            }
        }


        private void DataMsgParse(string msg)
        {
            if (this.textBoxCoolantTemp.InvokeRequired)
            {
                MsgParseCallback d = new MsgParseCallback(DataMsgParse);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                try
                {
                    byte[] BinarySeq = Encoding.ASCII.GetBytes(msg);
                    string CoolantTemp = ((int)BinarySeq[43]).ToString();
                    string Day = String.Format("{0,2:X2}", BinarySeq[94]);
                    string Month = String.Format("{0,2:X2}", BinarySeq[93]);
                    string Year = String.Format("{0,2:X2}", BinarySeq[92]);
                    string Hour = String.Format("{0,2:X2}", BinarySeq[96]);
                    string Minute = String.Format("{0,2:X2}", BinarySeq[97]);
                    string Second = String.Format("{0,2:X2}", BinarySeq[98]);
                    LastUpdate = DateTime.Now;
                    DKGDateTime = DateTime.Parse(Day + "." + Month + "." + Year + " " + Hour + ":" + Minute + ":" + Second);
                    textBoxCoolantTemp.Text = CoolantTemp;
                    textBoxDKGDateTime.Text = DKGDateTime.ToString();
                    textBoxDKGDateTime.BackColor = Color.White;
                    if (Settings.IsLogEnabled())
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (byte dataByte in BinarySeq) sb.AppendFormat("{0,3:X2}", dataByte);
                        WriteLogWithDateTimeUpd(sb.ToString() + " ("+RM.GetString("strCoolantTemp")+": " + CoolantTemp + "; "+RM.GetString("strDKGDT")+":" + DKGDateTime.ToString() + ")");
                    }
                    if (IsAlarmEnabled)
                    {
                        if (int.Parse(CoolantTemp) <= Settings.GetMinCoolantTemp() || int.Parse(CoolantTemp) >= Settings.GetMaxCoolantTemp())
                        {
                            textBoxCoolantTemp.BackColor = Color.Red;
                            StartAlarm();
                            if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strCoolantTemp") + " " + RM.GetString("strOutLimit"));
                        }
                        else
                        {
                            textBoxCoolantTemp.BackColor = Color.Lime;
                            if (IsAlarmInProgress) StopAlarm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strParseErr")+": " + ex.Message);
                    return;
                }
            }
        }
        
        private void checkBoxLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked)
            {
                textBoxLogFolder.Enabled = true;
                textBoxLogPeriod.Enabled = true;
                buttonLogFolderSelect.Enabled = true;
            }
            else
            {
                textBoxLogFolder.Enabled = false;
                textBoxLogPeriod.Enabled = false;
                buttonLogFolderSelect.Enabled = false;
            }
        }

        private void WriteLog(string msg)
        {
                try
                {
                    string LogFileName = Settings.GetLogFolderName() + @"\" + Settings.GetLogFilePrefix() + DateTime.Today.Date.ToString("ddMMyyyy") + ".log";
                    StreamWriter sw = new StreamWriter(new FileStream(LogFileName, FileMode.Append, FileAccess.Write));
                    sw.WriteLine("["+DateTime.Now+"]: "+msg);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, RM.GetString("strErrAccessLog"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
        }
        private void WriteLogWithDateTimeUpd(string msg)
        {
            if (DateTime.Now.Subtract(LastLogWrite).TotalSeconds >= Settings.GetLogPeriod())
            {
                WriteLog(msg);
                LastLogWrite = DateTime.Now;
            }
        }

        private void StartAlarm()
        {
            player.PlayLooping();
            IsAlarmInProgress = true;
            NotifyIconTmpText = notifyIcon1.Text;
            notifyIcon1.Text = RM.GetString("strAppName") + " " + RM.GetString("strRunning") + RM.GetString("strAlarmExcl");
            if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strAlarmSoundOn"));
        }
        private void StopAlarm()
        {
            player.Stop();
            IsAlarmInProgress = false;
            notifyIcon1.Text = NotifyIconTmpText;
            if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strAlarmSoundOff"));
        }

        private void timerNoData_Tick(object sender, EventArgs e)
        {
            double noDataPeriod = DateTime.Now.Subtract(LastUpdate).TotalSeconds;
            if (!NoDataWarning&&(noDataPeriod>= Settings.GetNoDataAlarmPeriod()))
            {
                NoDataWarning = true;
                if (!IsAlarmInProgress) StartAlarm();
                notifyIcon1.BalloonTipText = RM.GetString("strNoDataFor") + " " + noDataPeriod.ToString("F1") + " " + RM.GetString("strSeconds") + "!";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon1.ShowBalloonTip(30000);
                textBoxDKGDateTime.BackColor = Color.Red;
                textBoxCoolantTemp.BackColor = Color.Red;
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strNoDataFor") + " " + noDataPeriod.ToString("F1") + " " + RM.GetString("strSeconds") + "!");
                if (MessageBox.Show(RM.GetString("strNoDataFor") + " " + noDataPeriod.ToString("F1") + " " + RM.GetString("strSeconds") + "!", RM.GetString("strAlarmExcl"), MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    StopAlarm();
                }
            }
            else if (NoDataWarning && (noDataPeriod < Settings.GetNoDataAlarmPeriod()))
            {
                NoDataWarning = false;
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strDataFlowRestored")+ "!");
                textBoxDKGDateTime.BackColor = Color.White;
                textBoxCoolantTemp.BackColor = Color.White;
            }
        }

        private void buttonAlarmEnableDisable_Click(object sender, EventArgs e)
        {
            if (!IsAlarmEnabled)
            {
                try
                {
                    player = new System.Media.SoundPlayer(Settings.GetAlarmSoundFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, RM.GetString("strErrLoadSound"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    Settings.SetMinCoolantTemp(numericUpDownMinCoolantTemp.Value.ToString());
                    Settings.SetMaxCoolantTemp(numericUpDownMaxCoolantTemp.Value.ToString());
                    Settings.SetNoDataAlarmPeriod(textBoxNoDataAlarmPeriod.Text);
                    Settings.SaveSetToFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, RM.GetString("strErrInSettings"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                IsAlarmEnabled = true;
                this.Height = 230;
                notifyIcon1.Text = RM.GetString("strAppName") + " " + RM.GetString("strRunning") + " " + RM.GetString("strAlarmEnabled");
                buttonAlarmEnableDisable.Text = RM.GetString("strDisableAlarm");
                buttonStartStop.Enabled = false;
                numericUpDownMaxCoolantTemp.Enabled = false;
                numericUpDownMinCoolantTemp.Enabled = false;
                textBoxNoDataAlarmPeriod.Enabled = false;
                buttonTestAlarm.Enabled = true;
                LastUpdate = DateTime.Now;
                timerNoData.Interval = 1000;
                timerNoData.Start();
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strAlarmEnabled"));
            }
            else
            {
                timerNoData.Stop();
                NoDataWarning = false;
                if (IsAlarmInProgress) StopAlarm();
                player.Dispose();
                textBoxDKGDateTime.BackColor = Color.White;
                textBoxCoolantTemp.BackColor = Color.White;
                this.Height = 280;
                notifyIcon1.Text = RM.GetString("strAppName") + " " + RM.GetString("strRunning") + " " + RM.GetString("strAlarmDisabled");
                IsAlarmEnabled = false;
                buttonAlarmEnableDisable.Text = RM.GetString("strEnableAlarm");
                buttonStartStop.Enabled = true;
                numericUpDownMaxCoolantTemp.Enabled = true;
                numericUpDownMinCoolantTemp.Enabled = true;
                textBoxNoDataAlarmPeriod.Enabled = true;
                buttonTestAlarm.Enabled = false;
                if (Settings.IsLogEnabled()) WriteLog(RM.GetString("strAlarmDisabled"));
            }
        }

        private void buttonTestAlarm_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortToLog != null && serialPortToLog.IsOpen)
            {
                if (MessageBox.Show(RM.GetString("strSerialStillOpen"), RM.GetString("strSerialIsOpened"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    serialPortToLog.Close();
                }
            }
        }

    }
}