using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.EF;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Test.ModelTests
{
    [TestClass]
    public class DinoTests
    {
        //Instantiate new context
        DinoContext db = new DinoContext();

        //Dino for use in CRUD operationss
        Dino crudDino = new Dino { Damage = 2, Health = 3, Name = "crudDino", Oxigen = 4, Stamina = 5, Weight = 6 };

        [TestMethod]
        public void CreateInstanceOfDino()
        {
            Dino testDino = new Dino { DinoID = 1, Damage = 2, Health = 3, Name = "TestDino", Oxigen = 4, Stamina= 5, Weight= 6};

            Assert.IsNotNull(testDino);

            Assert.AreEqual("TestDino", testDino.Name);
        }

        [TestMethod]
        [TestCategory("DinoCRUD")]
        public void SavingDinoToDB()
        {
            //call EF to persist data
            db.Dinos.Add(crudDino);
            db.SaveChanges();
        }

        [TestMethod]
        [TestCategory("DinoCRUD")]
        public void SelectDinoFromDB()
        {
            Dino testDino = db.Dinos.Find(1);
            Assert.IsNotNull(testDino.DinoID);
        }

        [TestMethod]
        [TestCategory("DinoCRUD")]
        public void SelectDinoCollectionFromDB()
        {
            List<Dino> testDinoCollection = db.Dinos.ToList();
            foreach (Dino dino in testDinoCollection)
            {
                Assert.IsNotNull(dino.DinoID);
            }
        }

        [TestMethod]
        [TestCategory("DinoCRUD")]
        public void UpdateDinoInDB()
        {
            //first we need to retrieve a record to modify it
            Dino testDino = db.Dinos.Where(x => x.Name == "crudDino").Single();

            //update some values
            testDino.Health = 999;
            testDino.Oxigen = 777;
            testDino.Weight += 50;

            //save changes and persist to db
            //db.Entry(testDino).State = System.Data.Entity.EntityState.Modified; // You would manually add this in order to track changes done to an entity opened by another context
            db.SaveChanges();
        }

        [TestMethod]
        [TestCategory("DinoCRUD")]
        public void DeleteDinoFromDB()
        {
            //We could simply issue a deletion based on a entity ID to avoid two calls to DB
            //Dino deleteDino = new Dino { DinoID = 42 };
            //db.Dinos.Attach(deleteDino);

            //Here we will use the name property to retrieve the record
            Dino deleteDino = db.Dinos.Where(x => x.Name == "crudDino").Single();

            //And then use EF to delete it
            db.Dinos.Remove(deleteDino);
            db.SaveChanges();
        }
    }
}
