using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extensions
    {
        /// <summary>
        /// Tries to parse a string value into an integer and return it. Returns 0 if it fails
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this String str)
        {
            int i = 0; 
            int.TryParse(str, out i);

            return i;
        }
    }
}
