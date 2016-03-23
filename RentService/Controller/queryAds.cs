using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentService.Controller
{
    
    public static class QueryAds
    {

        public static List<Model.Query_Ad> UserQuery(string userStr)
        {

            List<Model.Query_Ad> queryList = new List<Model.Query_Ad>();

            queryList = Helpers.DB.Fill<Model.Query_Ad>("spFindQueriedAds", new Dictionary<string,object>(){

                { "@findQuery", userStr}

            });

            return queryList;
        }
    }
}