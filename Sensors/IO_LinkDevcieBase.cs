using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors {
    public abstract class IO_LinkDevcieBase {

        public virtual bool Read(byte[] receive,out string data) {
            data = "";
            StringBuilder sb = new StringBuilder(data.Length * 3);
            int count = receive.Count();
            for (int i = 0; i < count; i++) {
                if (i < 9) continue;
                sb.Append(Convert.ToString(receive[i], 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            data = sb.ToString().ToUpper();
            return true;
        }

        public virtual bool Write(byte[] receive, out string data) {
            data = "";
            StringBuilder sb = new StringBuilder(data.Length * 3);
            int count = receive.Count();
            for (int i = 0; i < count; i++) {
                if (i < 9) continue;
                sb.Append(Convert.ToString(receive[i], 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            data = sb.ToString().ToUpper();
            return true;
        }
    }
}
