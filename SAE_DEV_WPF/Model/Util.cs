using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_WPF.Model
{
    public class Util
    {
        public static string ConvertToOneUpperCase(string txt)
        {
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1).ToLower();
        }
    }
}
