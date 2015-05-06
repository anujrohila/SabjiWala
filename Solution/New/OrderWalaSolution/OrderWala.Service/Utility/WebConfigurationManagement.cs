using System;

namespace OrderWala.Service
{
    public static class WebConfigurationManagement
    {
        public static string WebAdminPath
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["WebAdminPath"]);
            }
        }
    }
}