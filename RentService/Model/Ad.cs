using System;

using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class Ad
    {
        //[DataMember]
        //public bool Active { get; set; }

        public string ad_id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string adError { get; set; }

        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StartRentDate { get; set; }   //DateTime

        [DataMember]
        public string FinishRentDate { get; set; }  //DateTime

        [DataMember]
        public float DailyRentPrice { get; set; }

        [DataMember]
        public float WeeklyRentPrice { get; set; }

        [DataMember]
        public float MonthlyRentPrice { get; set; }

        [DataMember]
        public string OwnerName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string CaptchaUserValue { get; set; }

        [DataMember]
        public string TokenServ { get; set; }

    }
}