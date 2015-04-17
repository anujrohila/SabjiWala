using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWala.Web
{
    public static class ApplicationMember
    {
        public static Int32 LoggedUserId
        {
            get
            {
                return Convert.ToInt32(System.Web.HttpContext.Current.Session["LoggedUserId"]);
            }
        }

    }
}