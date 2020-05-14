using Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args) {
            //IO_LinkTest();


            int bDistance = (int)((Convert.ToInt16("192")) / 1.6);
            //Program.SendBytesToServer("11213", "192.3", "29");

        }

        private static void IO_LinkTest() {
            IO_LinkMaster myIomaster = new IO_LinkMaster("192.168.1.250", 502);
            string err = "";
            myIomaster.Connect(out err);
            string data = "";
            Console.WriteLine(data);
            Console.ReadKey();
        }


        public static  byte[] SendBytesToServer(string imei, string distance, string temperature) {
            List<byte> data = new List<byte>();

            string distanceTemp;
            if (distance.Contains(".")) {
                distanceTemp = distance.Substring(0, distance.IndexOf('.'));
            }
            else {
                distanceTemp = distance;
            }


            int bDistance = (Convert.ToInt16(distanceTemp));
            int bTemperature = Convert.ToInt16(temperature);
            byte[] bimei = System.Text.Encoding.Default.GetBytes(imei);
            //head
            data.AddRange(new byte[] { 0xFF, 0xFF, 0x00, 0x00 });
            data.Add((byte)bDistance);
            data.Add((byte)bTemperature);
            data.AddRange(new byte[] { 0x00, 0x00 });
            return data.ToArray();
        }
    }
}
