using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentService.Controller
{
    public static class PostToDB
    {
        public static bool PostNewUserToDB(Model.UserNew userNew)
        {

            userNew.user_id = new Helpers.RandomKey().GenerateKey(16);
            userNew.UserCreated = DateTime.Now;

            var checkedUser = new Controller.ValidationServer().UserNewValidation(userNew);

            if (checkedUser.Error == null)
            {
                Helpers.DB.Exec("CreateNewUser", new Dictionary<string, object>()
            {
                {"@user_id", userNew.user_id },
                {"@UserEmail", userNew.UserEmail },
                {"@UserPassword", userNew.UserPassword },
                {"@UserCreated", userNew.UserCreated },
            });

                return string.IsNullOrEmpty(Helpers.DB.Error);
            }
            else
            {
                return false;
            }
        }

        public static bool PostAdToDB(Model.Ad ad)
        {
            ad.ad_id = new Helpers.RandomKey().GenerateKey(16);
            //ad.ModifiedDate = DateTime.Now;

            var checkedAd = new Controller.ValidationServer().AdValidation(ad);

            if (checkedAd.adError == null)
            {
                Helpers.DB.Exec("InsertRentAd", new Dictionary<string, object>()
            {
                {"@ad_id", ad.ad_id },
                {"@ItemName", ad.ItemName },
                {"@ItemDesc", ad.ItemDesc },
                {"@City", ad.City },
                {"@StartRentDate", ad.StartRentDate },
                {"@FinishRentDate", ad.FinishRentDate },
                {"@DailyRentPrice", ad.DailyRentPrice },
                {"@WeeklyRentPrice", ad.WeeklyRentPrice },
                {"@MonthlyRentPrice", ad.MonthlyRentPrice },
                {"@OwnerName", ad.OwnerName },
                {"@PhoneNum", ad.PhoneNum },
                {"@ModifiedDate", ad.ModifiedDate }
            });

                return string.IsNullOrEmpty(Helpers.DB.Error);
            }
            else
            {
                return false;
            }

        }
    }
}