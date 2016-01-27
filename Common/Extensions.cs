using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extensions
    {
        public static int ToInt(this String str)
        {
            int i = 0; 
            int.TryParse(str, out i);

            return i;
        }
    }
}
