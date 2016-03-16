using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class VerifyResult
    {
        [DataMember]
        public bool result { get; set; }
    }
}
