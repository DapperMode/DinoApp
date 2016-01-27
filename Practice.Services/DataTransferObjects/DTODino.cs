using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Practice.Services.DataTransferObjects
{
    [DataContract(Name = "DTODino")]
    public class DTODino
    {
        [DataMember]
        public int DinoID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Health { get; set; }
        [DataMember]
        public int Stamina { get; set; }
        [DataMember]
        public int Oxigen { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public int Damage { get; set; }
    }
}