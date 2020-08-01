using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Helper
{
    public static class Util
    {
        public const string ConfigFileName = "K3DoNetConfig.json";

        public static string GetComType(object obj)
        {
            return Microsoft.VisualBasic.Information.TypeName(obj);
        }

        public static T GetConfig<T>()
        {
            if (!File.Exists(ConfigFileName))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(ConfigFileName));
        }

        public static void SetConfig<T>(T config)
        {
            File.WriteAllText(ConfigFileName, JsonConvert.SerializeObject(config));
        }
    }
}
