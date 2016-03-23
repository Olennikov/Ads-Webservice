using System;

using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class UserNew
    {
        public string user_id { get; set; }

        public DateTime UserCreated { get; set; }

        public string Error { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string UserEmail { get; set; }

        [DataMember]
        public string UserPassword { get; set; }
    }
}