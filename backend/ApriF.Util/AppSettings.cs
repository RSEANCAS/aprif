using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Util
{
    public class AppSettings
    {
        public static T Get<T>(string key)
        {
            T value = default(T);

            string valueAppSettings = ConfigurationManager.AppSettings[key];

            value = valueAppSettings == null ? default(T) : (T)Convert.ChangeType(valueAppSettings, typeof(T));

            return value;
        }
    }
}
