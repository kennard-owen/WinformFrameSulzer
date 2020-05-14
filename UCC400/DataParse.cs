using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer {
   public class DataParse {
        public static byte[] SendBytes(string distance, string temperature) {
            string origin = $"Distance:{distance};Temperature:{temperature}";
            byte [] res= System.Text.Encoding.Default.GetBytes(origin);
            return res;
        }

        public static byte[] SendBytesToServer(string imei,string distance, string temperature) {
            List<byte> data = new List<byte>();

            string distanceTemp;
            if (distance.Contains(".")) {
                distanceTemp = distance.Substring(0, distance.IndexOf('.'));
            }
            else {
                distanceTemp = distance;
            }
            int bDistance = (int)((Convert.ToInt16(distanceTemp))/1.6);
            int bTemperature = Convert.ToInt16(temperature);
            byte[] bimei = System.Text.Encoding.Default.GetBytes(imei);
            //head
            data.AddRange(new byte[] { 0xFF, 0xFF, 0x00, 0x00 });
            data.Add((byte)bDistance);
            data.Add((byte)bTemperature);
            data.AddRange(new byte[] { 0x00, 0x00 });
            data.AddRange(strToToHexByte(imei));
            return data.ToArray();
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString) {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
    }
}
