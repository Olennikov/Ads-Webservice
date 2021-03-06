﻿using System;

using System.Runtime.Serialization;

namespace RentService.Model
{
    [DataContract]
    public class Ad
    {
        //[DataMember]
        //public bool Active { get; set; }

        public string ad_id { get; set; }
        public string adError { get; set; }

        [DataMember]
        public string ModifiedDate { get; set; }

        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public string ItemDesc { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StartRentDate { get; set; }   //DateTime

        [DataMember]
        public string FinishRentDate { get; set; }  //DateTime

        [DataMember]
        public decimal DailyRentPrice { get; set; }

        [DataMember]
        public decimal WeeklyRentPrice { get; set; }

        [DataMember]
        public decimal MonthlyRentPrice { get; set; }

        [DataMember]
        public string OwnerName { get; set; }

        [DataMember]
        public string PhoneNum { get; set; }

        [DataMember]
        public string CaptchaUserValue { get; set; }

        [DataMember]
        public string TokenServ { get; set; }

    }
}