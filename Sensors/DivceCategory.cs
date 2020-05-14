using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors {
    public enum DeviceType 
    {
        Ultrasonic,
        R100
    }

    public class DivceCategory 
   {
        IO_LinkDevcieBase _devcie;
        public DivceCategory(DeviceType devcieEnum)
        {
            switch (devcieEnum) {
                case DeviceType.R100:
                    _devcie = new R100();
                    break;
                case DeviceType.Ultrasonic:
                    throw new Exception("未实现");
            }
        }

        public bool ReadDataAnalysis(byte[] receive, out string data) {
           return _devcie.Read(receive, out data);
        }

        public bool WriteDataAnalysis(byte[] receive, out string data) {
            return _devcie.Write(receive, out data);
        }
    }
}
