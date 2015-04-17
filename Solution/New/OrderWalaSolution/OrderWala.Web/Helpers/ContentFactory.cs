﻿using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace OrderWala.Web
{
    public static class ContentFactory
    {
        /// <summary>
        /// Get Use Content Delivery Network
        /// </summary>
        public static bool UseContentDeliveryNetwork
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["UseContentDeliveryNetwork"]);
            }
        }



        /// <summary>
        /// Get Work Environment
        /// </summary>
        public static string WorkEnvironment
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["WorkEnvironment"]);
            }
        }

        /// <summary>
        /// Loads a script int the view
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="configKey">configuration key value, configured in appsettings</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, string filePath)
        {
            if (UseContentDeliveryNetwork)
                filePath = filePath.Replace("~", CommonFunctions.WebUrlPrefix);

            if (string.Compare(WorkEnvironment, "Development", StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                var filePathWithoutMin = filePath.Replace(".min", string.Empty);

                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(filePathWithoutMin)))
                {
                    filePath = filePathWithoutMin;
                }
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception(string.Format("Mvc3.ContentManagement: Resource not found for {0}", filePath));
            }
            else
            {
                TagBuilder tagBuilder = new TagBuilder("script");
                tagBuilder.MergeAttribute("src", UrlHelper.GenerateContentUrl(filePath, htmlHelper.ViewContext.HttpContext));
                tagBuilder.MergeAttribute("type", "text/javascript");
                return new MvcHtmlString(tagBuilder.ToString());
            }
        }

        /// <summary>
        /// Loads a style int the view
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="filePath">configuration key value, configured in appsettings</param>
        public static MvcHtmlString Style(this HtmlHelper htmlHelper, string filePath)
        {
            if (UseContentDeliveryNetwork)
                filePath = filePath.Replace("~", CommonFunctions.WebUrlPrefix);

            if (string.Compare(WorkEnvironment, "Development", StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                var filePathWithoutMin = filePath.Replace(".min", string.Empty);

                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(filePathWithoutMin)))
                {
                    filePath = filePathWithoutMin;
                }
            }
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception(string.Format("Mvc3.ContentManagement: Resource not found for {0}", filePath));
            }
            else
            {
                TagBuilder tagBuilder = new TagBuilder("link");
                tagBuilder.MergeAttribute("href", UrlHelper.GenerateContentUrl(filePath, htmlHelper.ViewContext.HttpContext));
                tagBuilder.MergeAttribute("type", "text/css");
                tagBuilder.MergeAttribute("rel", "stylesheet");
                return new MvcHtmlString(tagBuilder.ToString());
            }
        }

    }﻿
}

