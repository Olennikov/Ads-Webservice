using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentService.Model
{
    [DataContract]
    public class UserFirstDetalies
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string user_id { get; set; }

        [DataMember]
        public string UserEmail { get; set; }
    }
}