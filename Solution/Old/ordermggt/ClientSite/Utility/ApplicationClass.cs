using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSite.Utility
{
    public static class ApplicationClass
    {
        public static string ApplicationPath
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApplicationPath"]);
            }
        }
    }
}