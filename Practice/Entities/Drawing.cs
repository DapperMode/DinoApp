using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Entities
{
    public class Drawing
    {
        public Drawing() //Default constructor
        {

        }
        public Drawing(int id)// with supplied ID param
        {
            int counter = 1;
            Random rnd = new Random();
            this.DrawingID = id;

            this.Picks = new PickCollection {
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
                                new Pick { DrawingID = id, PickID = counter++, Value = rnd.Next(1,99) },
            };
        }

        public int DrawingID { get; set; }

        public PickCollection Picks { get; set; }
    }
}
