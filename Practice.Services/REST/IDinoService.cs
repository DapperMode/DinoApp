using Practice.Models;
using Practice.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace Practice.Services
{
    [ServiceContract]
    public interface IDinoService
    {
        [OperationContract]
        [Description("Gets a single dino record from the database by dinoID.")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Dino/Item/{dinoID}")]
        DTODino GetDinoItem(string dinoID);

        [OperationContract]
        [Description("Gets a collection of dino records from the database.")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Dino/Collection")]
        DTODinoCollection GetDinoCollection();

        [OperationContract]
        [Description("Gets a single image record from the database by imageID.")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Image/Item/{ImageID}")]
        DTOImage GetImageItem(string imageID);

        [OperationContract]
        [Description("Gets a collection of image records from the database.")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Image/Collection")]
        DTOImageCollection GetImageCollection();
    }
}