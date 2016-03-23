using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentService.Model
{
    public class Query_Ad
    {
        //public bool Active { get; set; }

        public string ad_id { get; set;}
        public string ModifiedDate { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public string City { get; set; }
        public string StartRentDate { get; set; }   //DateTime
        public string FinishRentDate { get; set; }  //DateTime
        public decimal DailyRentPrice { get; set; }
        public decimal WeeklyRentPrice { get; set; }
        public decimal MonthlyRentPrice { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNum { get; set; }
    }
}