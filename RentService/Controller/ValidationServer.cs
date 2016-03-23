using System;
using System.Collections.Generic;


using System.Text.RegularExpressions;

namespace RentService.Controller
{
    public class ValidationServer
    {
        public Model.UserNew UserNewValidation(Model.UserNew user)
        {
            // credit http://www.rhyous.com/2010/06/15/csharp-email-regular-expression/
                                     
            String theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]+)|((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z";


            if (Regex.IsMatch(user.UserEmail, theEmailPattern) && !string.IsNullOrEmpty(user.UserEmail))
            {
                user.Error = null;
                return user;
            }
            else
            {
                user.Error = "invalid Email address";
                return user;
            }
        }

        private DateTime startrentdate;
        private DateTime finishrentdate;
        private DateTime compareToThisDate;
        private DateTime modifieddate;

        public Model.Ad AdValidation(Model.Ad ad)
        {          
            startrentdate = Convert.ToDateTime(ad.StartRentDate);
            finishrentdate = Convert.ToDateTime(ad.FinishRentDate);
            modifieddate = Convert.ToDateTime(ad.ModifiedDate);
            compareToThisDate = DateTime.Today;

            bool flag = true;

            if (string.IsNullOrEmpty(ad.ItemName)  || ad.ItemName.Length < 2 || ad.ItemName.Length > 25)          
                flag = false;                        
                
            if (string.IsNullOrEmpty(ad.City) || ad.City.Length < 2 || ad.City.Length > 25)
                flag = false;

            if (startrentdate == null || finishrentdate == null)
                flag = false;

            if (startrentdate < compareToThisDate || finishrentdate < compareToThisDate || startrentdate > finishrentdate)
                flag = false;

            if(modifieddate < compareToThisDate) flag = false;

            if (string.IsNullOrEmpty(ad.OwnerName))
                flag = false;

            if (string.IsNullOrEmpty(ad.PhoneNum))
                flag = false;

            if (flag == false)
            {
                ad.adError = "One or more values are incorrect";
                return ad;
            }
            else
            {
                return ad;
            }          
        }
    }
}