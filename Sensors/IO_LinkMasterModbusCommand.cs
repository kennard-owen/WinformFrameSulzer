using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sensors
{
    public class IO_LinkMasterModbusCommand
    {
        public static List<byte> SendReadCommand(int startAdress , int count, ref int recvRigLen)
        {
            recvRigLen = 9 + count * 2;
            var sendlist = new List<byte> {0x00,01,0x00,0x00,0x00,0x06,0x01,0x03};
            var adressHigh = (byte)(startAdress / 256);
            var adressLow = (byte)(startAdress % 256);
            var countHigh = (byte)(count / 256);
            var CountLow = (byte)(count % 256);
            sendlist.AddRange(new byte[] { adressHigh, adressLow, countHigh, CountLow });
            return sendlist;
        }

        public static bool AnalyzeReadCommand(byte[] receive, out string data)
        {
            data = "";
            StringBuilder sb = new StringBuilder(data.Length * 3);
            int count = receive.Count();
            for (int i = 0; i < count; i++)
            {
                if (i < 9) continue;
                sb.Append(Convert.ToString(receive[i], 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            data = sb.ToString().ToUpper();
            return true;
        }

        public static List<byte> GetSendCommandBytes(DeviceType type, CommandIO_Link command, ref int recvRigLen)
        {
            List<byte> res = new List<byte> { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03 };
            switch (command)
            {
                case CommandIO_Link.DiagnosisDataPort1 :
                case CommandIO_Link.DiagnosisDataPort2:
                case CommandIO_Link.DiagnosisDataPort3:
                case CommandIO_Link.DiagnosisDataPort4:
                case CommandIO_Link.DiagnosisDataPort5:
                case CommandIO_Link.DiagnosisDataPort6:
                case CommandIO_Link.DiagnosisDataPort7:
                case CommandIO_Link.DiagnosisDataPort8:
                    res.AddRange(new byte[] { (byte)((int)command / 256), (byte)((int)command % 256), (byte)((int)234/ 256), (byte)((int)234 % 256) });
                    break;
                case CommandIO_Link.PDIPort1:
                case CommandIO_Link.PDIPort2:
                case CommandIO_Link.PDIPort3:
                case CommandIO_Link.PDIPort4:
                case CommandIO_Link.PDIPort5:
                case CommandIO_Link.PDIPort6:
                case CommandIO_Link.PDIPort7:
                case CommandIO_Link.PDIPort8:
                    res.AddRange(new byte[] { (byte)((int)command / 256), (byte)((int)command % 256), (byte)((int)36 / 256), (byte)((int)36 % 256) });
                    break;
                case CommandIO_Link.PDOPort1:
                case CommandIO_Link.PDOPort2:
                case CommandIO_Link.PDOPort3:
                case CommandIO_Link.PDOPort4:
                case CommandIO_Link.PDOPort5:
                case CommandIO_Link.PDOPort6:
                case CommandIO_Link.PDOPort7:
                case CommandIO_Link.PDOPort8:
                    res.AddRange(new byte[] { (byte)((int)command / 256), (byte)((int)command % 256), (byte)((int)36 / 256), (byte)((int)36 % 256) });
                    break;
            };
            return res;
        }

        public static bool GetReadAnalysisReceiveByte(DeviceType type, CommandIO_Link command, byte[] receive, out string data)
        {
            data = "";
            switch (command)
            {
                case CommandIO_Link.DiagnosisDataPort1:
                case CommandIO_Link.DiagnosisDataPort2:
                case CommandIO_Link.DiagnosisDataPort3:
                case CommandIO_Link.DiagnosisDataPort4:
                case CommandIO_Link.DiagnosisDataPort5:
                case CommandIO_Link.DiagnosisDataPort6:
                case CommandIO_Link.DiagnosisDataPort7:
                case CommandIO_Link.DiagnosisDataPort8:
                string VendorName = Encoding.ASCII.GetString(receive.GetBytes(9, 64)).Replace("\0", "");
                string VendorText = Encoding.ASCII.GetString(receive.GetBytes(73, 64)).Replace("\0", "");
                string ProductName = Encoding.ASCII.GetString(receive.GetBytes(137, 64)).Replace("\0", "");
                string ProductID =Encoding.ASCII.GetString(receive.GetBytes(201, 64)).Replace("\0", "");
                string ProductText = Encoding.ASCII.GetString(receive.GetBytes(265, 64)).Replace("\0", "");
                string SerialNumber = Encoding.ASCII.GetString(receive.GetBytes(329, 16)).Replace("\0", "");
                string HardwareRevision = Encoding.ASCII.GetString(receive.GetBytes(345, 64)).Replace("\0", "");
                string FirmwareRevision = Encoding.ASCII.GetString(receive.GetBytes(409, 64)).Replace("\0", "");
                string PDILength = Encoding.ASCII.GetString(receive.GetBytes(473, 2)).Replace("\0", "");
                string PDOLength = Encoding.ASCII.GetString(receive.GetBytes(474, 2)).Replace("\0", "");
                    IO_Link_DiagnosisInfo info = new IO_Link_DiagnosisInfo()
                    {
                        Port = GetPort(command),
                        VendorName = VendorName,
                        VendorText = VendorText,
                        ProductName = ProductName,
                        ProductID = ProductID,
                        ProductText = ProductText,
                        SerialNumber = SerialNumber,
                        HardwareRevision = HardwareRevision,
                        FirmwareRevision = FirmwareRevision,
                        PDILength = PDILength,
                        PDOLength = PDOLength
                    };
                    data = info.ToJSON();
                    break;
                case CommandIO_Link.PDIPort1:
                case CommandIO_Link.PDIPort2:
                case CommandIO_Link.PDIPort3:
                case CommandIO_Link.PDIPort4:
                case CommandIO_Link.PDIPort5:
                case CommandIO_Link.PDIPort6:
                case CommandIO_Link.PDIPort7:
                case CommandIO_Link.PDIPort8:
                    data = "";
                    new DivceCategory(type).ReadDataAnalysis(receive, out data);
                    return true;
                case CommandIO_Link.PDOPort1:
                case CommandIO_Link.PDOPort2:
                case CommandIO_Link.PDOPort3:
                case CommandIO_Link.PDOPort4:
                case CommandIO_Link.PDOPort5:
                case CommandIO_Link.PDOPort6:
                case CommandIO_Link.PDOPort7:
                case CommandIO_Link.PDOPort8:
                    break;
            };
            return true;
        }


        public static string GetPort(CommandIO_Link command)
        {
            switch (command)
            {
                case CommandIO_Link.DiagnosisDataPort1:
                    return "port1";
                case CommandIO_Link.DiagnosisDataPort2:
                    return "port2";
                case CommandIO_Link.DiagnosisDataPort3:
                    return "port3";
                case CommandIO_Link.DiagnosisDataPort4:
                    return "port4";
                case CommandIO_Link.DiagnosisDataPort5:
                    return "port5";
                case CommandIO_Link.DiagnosisDataPort6:
                    return "port6";
                case CommandIO_Link.DiagnosisDataPort7:
                    return "port7";
                case CommandIO_Link.DiagnosisDataPort8:
                    return "port8";
            }
            return "?";
        }

        public static CommandIO_Link GetPortCommand(string port)
        {
            switch (port)
            {
                case "Port1":
                    return CommandIO_Link.DiagnosisDataPort1;
                case "Port2":
                    return CommandIO_Link.DiagnosisDataPort2;
                case "Port3":
                    return CommandIO_Link.DiagnosisDataPort3;
                case "Port4":
                    return CommandIO_Link.DiagnosisDataPort4;
                case "Port5":
                    return CommandIO_Link.DiagnosisDataPort5;
                case "Port6":
                    return CommandIO_Link.DiagnosisDataPort6;
                case "Port7":
                    return CommandIO_Link.DiagnosisDataPort7;
                case "Port8":
                    return CommandIO_Link.DiagnosisDataPort8;
            }
            return CommandIO_Link.DiagnosisDataPort1;
        }
    }
}
