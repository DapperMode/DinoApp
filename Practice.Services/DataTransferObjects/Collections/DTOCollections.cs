using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Practice.Services.DataTransferObjects
{
    [CollectionDataContract(Name = "DTODinoCollection")]
    public class DTODinoCollection : Collection<DTODino> { }
    [CollectionDataContract(Name = "DTOImageCollection")]
    public class DTOImageCollection : Collection<DTOImage> { }
}