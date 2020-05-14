using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sulzer {
    public static class MyExtensions {
        private static byte[] temperature = new byte[] { 175, 255, 1, 112 };
        private static byte[] distance = new byte[] { 175, 253, 254, 81 };
        private static byte[] ClosePWM = new byte[] { 167, 10, 1, 81 };
        private static byte[] OpenPWM = new byte[] { 167, 10, 254, 81 };


        public static void SendCommand(this SerialPort port, byte[] command) {
            port.Write(command, 0, command.Length);
            port.DiscardOutBuffer();
            port.DiscardInBuffer();
        }

        public static string Receive(this SerialPort port,out byte[] byteReceived) {
            string res = "";
            byte[] buff = new byte[255];
            int readCount = port.Read(buff, 0, buff.Length);
            byteReceived = new byte[readCount];
            if (readCount > 0) {
                Buffer.BlockCopy(buff, 0, byteReceived, 0, readCount);
                res = byteToHexStr(byteReceived);
            }
            return res;
        }

        public static void Get_T_and_D(this SerialPort port,out string distanceValue, out string temperatureValue) {
            port.SendCommand(distance);
            Thread.Sleep(500);
            distanceValue = port.Receive(out byte[] a);
            port.SendCommand(temperature);
            Thread.Sleep(500);
            temperatureValue = port.Receive(out byte[] b);
        }


        public static void Get_T_and_D(this SerialPort port, out string distanceValueCommand, out string temperatureValueCommand, out string distanceValue, out string temperatureValue) {
            port.SendCommand(distance);
            Thread.Sleep(500);
            distanceValueCommand = port.Receive(out byte[] a);
            int bDistance = (int)(a[4]);
            distanceValue = bDistance.ToString();
            port.SendCommand(temperature);
            Thread.Sleep(500);
            temperatureValueCommand = port.Receive(out byte[] b);
            temperatureValue = (b[4]).ToString();

        }


        private static string byteToHexStr(byte[] bytes) {
            string returnStr = "";
            if (bytes != null) {
                for (int i = 0; i < bytes.Length; i++) {
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }
    }
}
