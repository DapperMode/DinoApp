using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Practice.Services.DataTransferObjects
{
    [DataContract(Name = "DTOImage")]
    public class DTOImage
    {
        [DataMember]
        public int ImageID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public int DinoID { get; set; }
    }
}