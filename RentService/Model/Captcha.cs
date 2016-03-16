using System;
using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class Captcha
    {
        [DataMember]
        public string token { get; set; }

        [DataMember]
        public string image { get; set; }

    }
}