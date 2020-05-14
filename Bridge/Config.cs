using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bridge {
    public class Config {
        public static string GetValueByKey(string key) {
           Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           return config.AppSettings.Settings[key].Value;
        }
    }
}
