using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public enum CommandIO_Link
    {
        DiagnosisDataPort1= 1500,
        DiagnosisDataPort2 = 2500,
        DiagnosisDataPort3 = 3500,
        DiagnosisDataPort4 = 4500,
        DiagnosisDataPort5 = 5500,
        DiagnosisDataPort6 = 6500,
        DiagnosisDataPort7 = 7500,
        DiagnosisDataPort8 = 8500,

        PDIPort1 = 1000,
        PDIPort2 = 2000,
        PDIPort3 = 3000,
        PDIPort4 = 4000,
        PDIPort5 = 5000,
        PDIPort6 = 6000,
        PDIPort7 = 7000,
        PDIPort8 = 8000,

        PDOPort1 = 1050,
        PDOPort2 = 2050,
        PDOPort3 = 3050,
        PDOPort4 = 4050,
        PDOPort5 = 5050,
        PDOPort6 = 6050,
        PDOPort7 = 7050,
        PDOPort8 = 8050,
    }
    public class IO_Link_DiagnosisInfo
    {
        public string Port = "";
        public string VendorName = "";
        public string VendorText = "";
        public string ProductName = "";
        public string ProductID = "";
        public string ProductText = "";
        public string SerialNumber = "";
        public string HardwareRevision = "";
        public string FirmwareRevision = "";
        public string PDILength = "";
        public string PDOLength = "";

        public override string ToString()
        {
            return Port + ":" + VendorName + ":"
                + VendorText + ":" + ProductName + ":"
                + ProductID + ":" + ProductText + ":"
                + SerialNumber + ":" + HardwareRevision + ":"
                 + FirmwareRevision + ":" + PDILength + ":"
                  + PDOLength;
        }
    }

}
