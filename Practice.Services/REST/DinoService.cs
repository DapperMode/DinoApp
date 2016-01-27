using Practice.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using Practice.EF;
using Practice.Models;
using AutoMapper;
using Common;
using Practice.Services.Automapper;

namespace Practice.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DinoService : IDinoService
    {
        DinoDAL dal = new DinoDAL(); // instantiating DAL class
        public DinoService()
        {
            AutomapperConfig.RegisterMappings(); //registering the mappings for Automapper
        }

        public DTODino GetDinoItem(string dinoID)
        {
            Dino returnDino = dal.GetDinoItem(dinoID.ToInt());
            return ConvertToDTODino(returnDino);
        }
        public DTODinoCollection GetDinoCollection()
        {
            DinoCollection dinoCollection = dal.GetDinoCollection();
            DTODinoCollection returnDinos = ConvertToDTODinoCollection(dinoCollection);
            return returnDinos;

            //DTODinoCollection dinoCollection = new DTODinoCollection() { 
            //    new DTODino { DinoID = 1, Name = "test1", Health=10, Damage = 14, Oxigen=19, Stamina=78, Weight=43},
            //    new DTODino { DinoID = 2, Name = "test2", Health=11, Damage = 22, Oxigen=56, Stamina=67, Weight=23},
            //    new DTODino { DinoID = 3, Name = "test3", Health=12, Damage = 45, Oxigen=76, Stamina=12, Weight=12 } 
            //};
            //return dinoCollection;
        }

        public DTOImage GetImageItem(string imageID)
        {
            return new DTOImage();//---Must finish implementation
        }
        public DTOImageCollection GetImageCollection()
        {
            DTOImageCollection test = null;//---Must finish implementation
            test.Add(new DTOImage { Name = "test" });
            return test;
        }

        #region PRIVATE METHODS

        private DTODino ConvertToDTODino(Dino temp)
        {
            DTODino returnDino = Mapper.Map<DTODino>(temp);
            return returnDino;
        }

        private DTODinoCollection ConvertToDTODinoCollection(DinoCollection tempList)
        {
            DTODinoCollection returnList = new DTODinoCollection();
            foreach (Dino d in tempList)
            {
                DTODino tempDino = new DTODino();
                tempDino = Mapper.Map<DTODino>(d);

                returnList.Add(tempDino);
            }
            return returnList;
        }

        private DTOImageCollection ConvertToDTOImageCollection(ImageCollection tempList)
        {
            DTOImageCollection returnList = new DTOImageCollection();
            foreach (Image d in tempList)
            {
                DTOImage tempImage = Mapper.Map<DTOImage>(d);
                returnList.Add(tempImage);
            }
            return returnList;
        }

        #endregion
    }
}