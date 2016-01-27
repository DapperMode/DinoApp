using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.EF
{
    public class DinoDAL
    {
        private DinoContext db = new DinoContext();

        public Dino GetDinoItem(int dinoID)
        {
            return db.Dinos.Find(dinoID);
        }

        public DinoCollection GetDinoCollection()
        {
            var query = db.Dinos;
            DinoCollection returnCollection = new DinoCollection();

            foreach (var q in query)
            {
                returnCollection.Add(q);
            }

            return returnCollection;
        }

        public Image GetImageItem(int imageID)
        {
            return new Image();
        }

        public Image GetImageByDinoID(int dinoID)
        {
            var query = db.Images.Where(x => x.DinoID == dinoID).Single();
            return query;
        }

        public ImageCollection GetImageCollection()
        {
            return new ImageCollection();
        }
    }
}
