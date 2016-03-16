using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace RentService.Controller
{
    public static class Login
    {
        //static Dictionary<string, string> SessionDic = new Dictionary<string, string>();
        static Dictionary<string, DateTime> SessTimeDic = new Dictionary<string, DateTime>();

        public static Model.Session UserLogin(Model.UserNew user)
        {
            Model.Session ms = new Model.Session();
            ms.SessionToken = string.Empty;
            ms.SessionTimeSpan = DateTime.Now;
            ms.isValid = false;

            if (Helpers.DB.CredentialsCheck(user, "Login_check"))
            {
                //if (SessionDic.Keys.Contains(user.UserEmail))
                //{
                //    ms.SessionError = "You already loged in on one device";
                //}
                ms.isValid = true;

                var u = Helpers.DB.Fill<Model.UserFirstDetalies>("spGetUserFirstDetails", new Dictionary<string, object>()
                {
                    { "@UserEmail", user.UserEmail }
                });

                foreach (var item in u)
                {
                    ms.UserEmail = item.UserEmail;
                    ms.UserName = item.UserName;
                }
                HttpContext.Current.Session["UserId"] = ms.SessionToken = new Helpers.RandomKey().GenerateKey(16);
                SessTimeDic.Add((string)HttpContext.Current.Session["UserId"], ms.SessionTimeSpan);

                
                // Read from session state
                //ms.SessionToken = (string)(HttpContext.Current.Session["UserId"]);
                //var UserTo = HttpContext.Current.Session.SessionID;               
            }
            else
            {
                ms.isValid = false;
            }
            return ms;
        }

        public static bool UserToken(string token)
        {
            ClearSessTimeDic();

            if (token == null || token == "null") return false; // No such value in session state;

            return SessTimeDic.Keys.Contains(token);
            //return HttpContext.Current.Session["UserId"].ToString() == token; // return whatever "if" statement returns
        }

        private static void ClearSessTimeDic()
        {
            if (SessTimeDic.Count == 0)
            {
                bool f = false;
            }
            else
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(0, 0, 20, 0);
                DateTime combinedDate = date.Subtract(time);

                foreach (var value in SessTimeDic.Where(kvp => kvp.Value <= combinedDate).ToList())
                {
                    SessTimeDic.Remove(value.Key);
                }
            }


        }

    }
}