using ApplicationLog;
using Common;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Sulzer;

namespace Sensor
{
    public class UCCSocket {
        private readonly object _lockerSocket = new object();
        private UdpClient _clientSocket;
        private string _ip = "127.0.0.1";
        private int _networkDelay = 100;

        private int _port = 20000;
        private NetStatus _netStatus;


        IPAddress ip;
        IPEndPoint ipe;
        public UCCSocket(string IP, int Port)
        {
            _ip = IP;
            _port = Port;
            _id = "UCC" + DateTime.Now.ToString("yyMMddHHmmssfff");
            Connect(out string err);
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
                 ip = IPAddress.Parse(_ip);
                 ipe = new IPEndPoint(ip, _port);
                _clientSocket = new UdpClient();
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

        public  bool BatchWrite(string imei, string distance, string temperature)
        {
            lock (_lockerSocket)
            {
                bool ret = false;
                byte[] bsSend = {};
                int recvRigLen = 0;
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
                        bsSend = DataParse.SendBytesToServer(imei,distance, temperature);
                        _clientSocket.Send(bsSend, bsSend.Length);
                        ret = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        LogManager.WriteLog(LogFile.Error, ex.ToString());
                    }
                }
                if (ret == false)
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
                    tempBytes = _clientSocket.Receive(ref ipe);
                    byteCount = tempBytes.Length;
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