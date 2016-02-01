using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Resources;

namespace CustomDKGMonitor
{
    public class CDMSettings
    {
        #region ClassFields
        public CDMSettings() 
        { 
             RM = new ResourceManager("CustomDKGMonitor.CDMSettings", typeof(CDMSettings).Assembly);
        }
        private string SettingsFile = "CDM.conf";//Имя файла для настроек
        private string SettingsFolder = Environment.CurrentDirectory;//Путь для файла настроек
        private bool EnableLog = false;
        private int LogPeriod = 60;
        private string LogFolderName = Environment.CurrentDirectory+@"\Logs";//Путь сохранения логов
        private string LogFilePrefix = "DKGData_"; //Префикс файлов лога
        private string AlarmSoundFile = Environment.CurrentDirectory + @"\ALARM.wav"; //Путь к аудио-файлу сирены

        private int MinCoolantTemp = 2;
        private int MaxCoolantTemp = 30;
        private int NoDataAlarmPeriod = 300;

        private int SerialPortSelect = 0;
        private int BaudRate = 2400;
        private int DataBits = 8;
        private int StopBitsSelect = 1;
        private int ParitySelect = 0;
        private int HandshakeSelect = 0;
        private ResourceManager RM;

        public class Options
        {
            public string SettingsFile;
            public string SettingsFolder;
            public bool EnableLog;
            public int LogPeriod;
            public string LogFolderName;
            public string AlarmSoundFile;

            public int MinCoolantTemp;
            public int MaxCoolantTemp;
            public int NoDataAlarmPeriod;

            public int SerialPortSelect;
            public int BaudRate;
            public int DataBits;
            public int StopBitsSelect;
            public int ParitySelect;
            public int HandshakeSelect;
        }
        #endregion
        #region ClassGettersSetters
        
        public void SetLogFolderName(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            LogFolderName = folder;
        }
        public string GetLogFolderName()
        {
            return LogFolderName;
        }

        public string GetLogFilePrefix()
        {
            return LogFilePrefix;
        }

        public void SetLogEnabled(bool enable)
        {
            if (enable)
            {
                EnableLog = true;
            }
            else
            {
                EnableLog = false;
            }
        }
        public bool IsLogEnabled()
        {
            return EnableLog;
        }
       
        public void SetLogPeriod(string period)
        {
            int p;
            if (Regex.IsMatch(period, @"^\d+$"))
            {
                p = Convert.ToInt32(period);
                if (p <= 0)
                {
                    throw new Exception(RM.GetString("strLogPeriodExc"));
                }
            }
            else throw new Exception(RM.GetString("strLogPeriodExc"));
            LogPeriod = p;
        }
        public int GetLogPeriod()
        {
            return LogPeriod;
        }
        
        public void SetAlarmSoundFile(string soundFile)
        {
            if (soundFile != null || soundFile != "")
            {
                if (Regex.IsMatch(soundFile, @"^*.wav$")&&File.Exists(soundFile))
                {
                    AlarmSoundFile = soundFile;
                }
                else throw new Exception(RM.GetString("strAlarmFileNotFound"));
            }
            else throw new Exception(RM.GetString("strAlarmFileNotSpecified"));
        }
        public string GetAlarmSoundFile()
        {
            return AlarmSoundFile;
        }
        
        public void SetMinCoolantTemp(string temp)
        {
            int t;
            if (Regex.IsMatch(temp, @"^\d+$"))
            {
                t = Convert.ToInt32(temp);
            }
            else throw new Exception(RM.GetString("strMinCoolantTempExc"));
            MinCoolantTemp = t;
        }
        public int GetMinCoolantTemp()
        {
            return MinCoolantTemp;
        }
        
        public void SetMaxCoolantTemp(string temp)
        {
            int t;
            if (Regex.IsMatch(temp, @"^\d+$"))
            {
                t = Convert.ToInt32(temp);
            }
            else throw new Exception(RM.GetString("strMaxCoolantTempExc"));
            MaxCoolantTemp = t;
        }
        public int GetMaxCoolantTemp()
        {
            return MaxCoolantTemp;
        }

        public void SetNoDataAlarmPeriod(string period)
        {
            int p;
            if (Regex.IsMatch(period, @"^\d+$"))
            {
                p = Convert.ToInt32(period);
                if (p <= 0)
                {
                    throw new Exception(RM.GetString("strNoDataExc"));
                }
            }
            else throw new Exception(RM.GetString("strNoDataExc"));
            NoDataAlarmPeriod = p;
        }
        public int GetNoDataAlarmPeriod()
        {
            return NoDataAlarmPeriod;
        }

        public void SetSerialPortSelect(int select)
        {
            SerialPortSelect = select;
        }
        public int GetSerialPortSelect()
        {
            return SerialPortSelect;
        }

        public void SetBaudRate(string rate)
        {
            int r;
            if (Regex.IsMatch(rate, @"^\d+$"))
            {
                r = Convert.ToInt32(rate);
                if (r <= 0)
                {
                    throw new Exception(RM.GetString("strBaudRateExc"));
                }
            }
            else throw new Exception(RM.GetString("strBaudRateExc"));
            BaudRate = r;
        }
        public int GetBaudRate()
        {
            return BaudRate;
        }

        public void SetDataBits(string bits)
        {
            int b;
            if (Regex.IsMatch(bits, @"^\d+$"))
            {
                b = Convert.ToInt32(bits);
                if (b <= 0)
                {
                    throw new Exception(RM.GetString("strDataBitsExc"));
                }
            }
            else throw new Exception(RM.GetString("strDataBitsExc"));
            DataBits = b;
        }
        public int GetDataBits()
        {
            return DataBits;
        }

        public void SetStopBitsSelect(int select)
        {
            StopBitsSelect = select;
        }
        public int GetStopBitsSelect()
        {
            return StopBitsSelect;
        }

        public void SetParitySelect(int select)
        {
            ParitySelect = select;
        }
        public int GetParitySelect()
        {
            return ParitySelect;
        }

        public void SetHandshakeSelect(int select)
        {
            HandshakeSelect = select;
        }
        public int GetHandshakeSelect()
        {
            return HandshakeSelect;
        }        
        #endregion
        #region ClassMethods
        public bool SaveSetToFile()
        {
            Options OP = new Options();
            OP.SettingsFile = this.SettingsFile;
            OP.SettingsFolder = this.SettingsFolder;
            OP.EnableLog = this.EnableLog;
            OP.LogPeriod = this.LogPeriod;
            OP.LogFolderName = this.LogFolderName;
            OP.AlarmSoundFile = this.AlarmSoundFile;
            OP.MinCoolantTemp = this.MinCoolantTemp;
            OP.MaxCoolantTemp = this.MaxCoolantTemp;
            OP.NoDataAlarmPeriod = this.NoDataAlarmPeriod;
            OP.SerialPortSelect = this.SerialPortSelect;
            OP.BaudRate = this.BaudRate;
            OP.DataBits = this.DataBits;
            OP.StopBitsSelect = this.StopBitsSelect;
            OP.ParitySelect = this.ParitySelect;
            OP.HandshakeSelect = this.HandshakeSelect;
            try
            {
                if (!Directory.Exists(SettingsFolder))
                {
                    Directory.CreateDirectory(SettingsFolder);
                }
                XmlSerializer XmlSer = new XmlSerializer(OP.GetType());
                StreamWriter Writer = new StreamWriter(SettingsFolder+@"\"+SettingsFile);
                XmlSer.Serialize(Writer, OP);
                Writer.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, RM.GetString("strSaveSetExc"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public bool LoadSetfromFile()
        {
            Options OP = new Options();
            try
            {
                if (Directory.Exists(SettingsFolder))
                {
                    if (File.Exists(SettingsFolder + @"\" + SettingsFile))
                    {
                        XmlSerializer XmlSer = new XmlSerializer(OP.GetType());
                        FileStream Set = new FileStream(SettingsFolder + @"\" + SettingsFile, FileMode.Open);
                        OP = (Options)XmlSer.Deserialize(Set);
                        Set.Close();
                        this.SettingsFile = OP.SettingsFile;
                        this.SettingsFolder = OP.SettingsFolder;
                        this.EnableLog = OP.EnableLog;
                        this.LogPeriod = OP.LogPeriod;
                        this.LogFolderName = OP.LogFolderName;
                        this.AlarmSoundFile = OP.AlarmSoundFile;
                        this.MinCoolantTemp = OP.MinCoolantTemp;
                        this.MaxCoolantTemp = OP.MaxCoolantTemp;
                        this.NoDataAlarmPeriod = OP.NoDataAlarmPeriod;
                        this.SerialPortSelect = OP.SerialPortSelect;
                        this.BaudRate = OP.BaudRate;
                        this.DataBits = OP.DataBits;
                        this.StopBitsSelect = OP.StopBitsSelect;
                        this.ParitySelect = OP.ParitySelect;
                        this.HandshakeSelect = OP.HandshakeSelect;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, RM.GetString("strLoadSetExc"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        #endregion
    }
}
