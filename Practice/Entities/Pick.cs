using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Entities
{
    public class Pick
    {
        public Pick() { } //    default constructor
        public int DrawingID { get; set; }
        public int PickID { get; set; }
        public int Value { get; set; }
    }
}
