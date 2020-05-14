using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors {
    public class R100 : IO_LinkDevcieBase {
        public override bool Read(byte[] receive, out string data) {
            return base.Read(receive, out data);
        }
    }
}
