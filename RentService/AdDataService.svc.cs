using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RentService.Model;

namespace RentService
{
    public class AdDataService : IAdDataService
    {
        private static Dictionary<string, string> tokens = new Dictionary<string, string>();

        static AdDataService()  // (1) static constructor goes first
        {
            Helpers.DB.ConnectionString(".", "RentData");
        }

        public bool AddNewAd(Ad ad)
        {
            // server check if user value = captcha value 
            if (tokens.ContainsKey(ad.TokenServ) && tokens[ad.TokenServ].Equals(ad.CaptchaUserValue, StringComparison.OrdinalIgnoreCase)) 
            {
                return Controller.PostToDB.PostAdToDB(ad);
            }
            else
            {
                return false;
            }
            
        }


        public bool AddNewUser(UserNew user)
        {
            return Controller.PostToDB.PostNewUserToDB(user);
        }

        public Model.Captcha ShowCaptcha()
        {
            string token = new Helpers.RandomKey().GenerateKey(16);
            while (tokens.ContainsKey(token))
            {
                new Helpers.RandomKey().GenerateKey(16);
            }
            tokens.Add(token, new Controller.CaptchaImage().GenerateKeyImage(140, 70, 4, token)); // add to dic token16 and part of token (4 letters)

            return new Model.Captcha()
            {
                token = token,
                image = string.Format("{0}.jpg", token)
            };
        }

        public Model.Session ValidateUser(UserNew user)
        {
            return Controller.Login.UserLogin(user);
        }

        public bool CheckUser(string token)
        {
            return Controller.Login.UserToken(token);
        }

        public Model.VerifyResult Verify(string token, string userValue)
        {
            Model.VerifyResult vr = new Model.VerifyResult();
            if (tokens.ContainsKey(token) && tokens[token].Equals(userValue, StringComparison.OrdinalIgnoreCase))
            {
                vr.result = true;
            }
            else
            {
                vr.result = false;
            }

            return vr;
        }
    }
}
