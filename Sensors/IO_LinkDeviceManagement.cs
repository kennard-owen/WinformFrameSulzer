using Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors {
    public class IO_LinkDeviceManagement {

        #region static
        private static object _syncObj = new object();
        private static IO_LinkDeviceManagement _instance;
        public static IO_LinkDeviceManagement Instance {
            get {
                if (_instance == null) {
                    lock (_syncObj) {
                        if (_instance == null) {
                            _instance = new IO_LinkDeviceManagement();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        private Dictionary<string, IO_LinkMaster> _devices = new Dictionary<string, IO_LinkMaster>();
        public Dictionary<string, IO_LinkMaster> Devices {
            get { return _devices; }
        }

        public void Add(IO_LinkMaster IO_LinkMaster) {
            _devices.Add(IO_LinkMaster.ID, IO_LinkMaster);
        }
    }
}
