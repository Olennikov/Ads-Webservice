using System;
using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class Session
    {
        [DataMember]
        public bool isValid { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string user_id { get; set; }

        [DataMember]
        public string UserEmail { get; set; }

        [DataMember]
        public string SessionToken { get; set; }

        public string SessionError { get; set; }

        public DateTime SessionTimeSpan { get; set; }

    }
}