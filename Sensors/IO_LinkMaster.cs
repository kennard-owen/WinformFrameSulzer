using Common;
using Sensors;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Sensor
{
    public class IO_LinkMaster 
    {
        private readonly object _lockerSocket = new object();
        private Socket _clientSocket;
        private string _ip = "127.0.0.1";
        private int _networkDelay = 100;

        private int _port = 20000;
        private NetStatus _netStatus;
        public IO_LinkMaster(string IP, int Port)
        {
            _ip = IP;
            _port = Port;
            _id = "" + DateTime.Now.ToString("yyMMddHHmmssfff");
        }

        private string _id = "";
        public string ID {
            get { return _id; }
        }
        public int NetworkDelay
        {
            get { return _networkDelay; }
            set { _networkDelay = value; }
        }

        public  NetStatus NetStatus
        {
            get { return _netStatus; }
            set { _netStatus = value; }
        }
        public bool Connect(out string error)
        {
            bool ret = false;
            error = "连接成功！";
            try
            {
                IPAddress ip = IPAddress.Parse(_ip);
                var ipe = new IPEndPoint(ip, _port);
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout,
                    _networkDelay*5);
                _clientSocket.Connect(ipe);
                NetStatus = NetStatus.Good;
                ret = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                if (ex is SocketException)
                {
                    var se = ex as SocketException;
                }
            }
            return ret;
        }
        public bool BatchRead(DeviceType type, CommandIO_Link command, out string data)
        {
            lock (_lockerSocket)
            {
                string aa;
                data = "";
                bool ret = false;
                byte[] bsSend = {};
                int recvRigLen = 30;
                int recvErrLen = 0;
                byte[] recvBytes = {};
                string  sss;
                bsSend = IO_LinkMasterModbusCommand.GetSendCommandBytes(type, command, ref recvRigLen).ToArray();
                recvBytes = new byte[recvRigLen];
                sss = byteToHexStr(bsSend);

                int reSendCount = 0;
                while (true)
                {
                    reSendCount++;
                    if (reSendCount > 3)
                    {
                        break;
                    }
                    try
                    {
                        aa = byteToHexStr(bsSend);
                        _clientSocket.Send(bsSend);
                        string bb;
                        if (ReceiveData(ref recvRigLen, ref recvErrLen, out recvBytes))
                        {
                                bb = byteToHexStr(recvBytes);
                                ret = IO_LinkMasterModbusCommand.GetReadAnalysisReceiveByte(type, command,recvBytes,out data);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (!ret)
                {
                    NetStatus = NetStatus.Cutoff;
                    string error = "";
                    Connect(out error);
                }
                else
                {
                    if (reSendCount == 1)
                    {
                        NetStatus = NetStatus.Good;
                    }
                    else
                    {
                        NetStatus = NetStatus.Block;
                    }
                }
                return ret;
            }
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public  bool BatchWrite(string addr, int start, int count, string data)
        {
            lock (_lockerSocket)
            {
                string daa;
                bool ret = false;
                byte[] bsSend = {};
                int recvRigLen = 0;
                int recvErrLen = 0;
                byte[] recvBytes = {};
                recvBytes = new byte[recvRigLen];

                int reSendCount = 0;
                while (true)
                {
                    reSendCount++;
                    if (reSendCount > 3)
                    {
                        break;
                    }
                    try
                    {
                        daa = byteToHexStr(bsSend);
                        _clientSocket.Send(bsSend);
                        if (ReceiveData(ref recvRigLen, ref recvErrLen, out recvBytes))
                        {
                                ret = true;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (ret == false && data == "")
                {
                    NetStatus = NetStatus.Cutoff;
                    string error = "";
                    Connect(out error);
                }
                else
                {
                    if (reSendCount == 1)
                    {
                        NetStatus = NetStatus.Good;
                    }
                    else
                    {
                        NetStatus = NetStatus.Block;
                    }
                }
                return ret;
            }
        }

        public bool ReceiveData(ref int recvRigLen, ref int recvErrLen, out byte[] recvBytes)
        {
            bool ret = false;
            recvBytes = new byte[recvRigLen];
            int byteCount = 0;
            int count = 10;
            while (true)
            {
                count--;
                if (count < 0)
                {
                    break;
                }
                try
                {
                    recvRigLen = 60;
                    var tempBytes = new byte[recvRigLen*10];
                    byteCount = _clientSocket.Receive(tempBytes); //从客户端接受消息
                    ret = true;
                    recvBytes = new byte[byteCount];
                    Array.Copy(tempBytes, 0, recvBytes, 0, byteCount);
                    break;
                }
                catch (Exception ex)
                {
                    ret = false;
                    if (ex is SocketException)
                    {
                        var se = ex as SocketException;
                        if (se.SocketErrorCode == SocketError.WouldBlock || se.SocketErrorCode == SocketError.TimedOut)
                        {
                            NetStatus = NetStatus.Busy;
                            Thread.Sleep(_networkDelay);
                        }
                        else if (se.SocketErrorCode == SocketError.ConnectionReset ||
                                 se.SocketErrorCode == SocketError.NotConnected)
                        {
                            NetStatus = NetStatus.Cutoff;
                            string error = "";
                            Connect(out error);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return ret;
        }
    }
}