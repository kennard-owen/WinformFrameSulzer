using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.config {
   public class WholeConfig {


        public WholeConfig(){

            CheckPointList = new List<CheckPoint>();
        }
        public string CheckStationName { set; get; }
        public string CheckStationDesc { set; get; }

        public List<CheckPoint> CheckPointList { set; get; }

        public User User { set; get; }

    }
}
