using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OrderWala.Web
{
    public static class ResourceJavaScripter
    {
       /// <summary>
       /// Getting an item from the resource 
       /// </summary>
       /// <param name="resourceManager"></param>
       /// <returns></returns>
        public static JavaScriptResult GetResourceScript(ResourceManager resourceManager)
        {
            string cacheName = string.Format("ResourceJavaScripter.{0}", CultureInfo.CurrentCulture.Name);

            JavaScriptResult value = HttpRuntime.Cache.Get(cacheName) as JavaScriptResult;

            if (value == null)
            {
                JavaScriptResult javaScriptResult = CreateResourceScript(resourceManager);
                HttpContext.Current.Cache.Insert(cacheName, javaScriptResult);
                return javaScriptResult;
            }

            return value;
        }

        /// <summary>
        /// Convert resource file to json string
        /// </summary>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        static JavaScriptResult CreateResourceScript(ResourceManager resourceManager)
        {
            //ResourceSet defaultSet = resourceManager.GetResourceSet(CultureInfo.GetCultureInfo(CultureInfo.CurrentCulture.TwoLetterISOLanguageName), true, true);
            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            var resourceBaseName = resourceManager.BaseName;
            var jsonObjectName = resourceBaseName.Substring(resourceBaseName.LastIndexOf(".") + 1);

            StringBuilder sb = new StringBuilder();
            sb.Append(jsonObjectName);
            sb.Append("={");
            foreach (DictionaryEntry dictionaryEntry in resourceSet)
                if (dictionaryEntry.Value is string)
                {
                    string value = resourceSet.GetString((string)dictionaryEntry.Key) ?? (string)dictionaryEntry.Value;
                    sb.AppendFormat("\"{0}\":\"{1}\",", dictionaryEntry.Key, EncodeValue(value));
                }

            string script = sb.ToString();
            if (!string.IsNullOrEmpty(script))
                script = script.Remove(script.Length - 1);

            script += "};";

            JavaScriptResult result = new JavaScriptResult { Script = script };
            return result;
        }

        /// <summary>
        /// Encoding the values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string EncodeValue(string value)
        {
            value = (value).Replace("\"", "\\\"").Replace('{', '[').Replace('}', ']');
            value = value.Trim();
            value = RemoveWhiteSpace(value);
            return value;
        }
        /// <summary>
        /// method removing white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string RemoveWhiteSpace(string value)
        {
            return System.Text.RegularExpressions.Regex.Replace(value, @"\s", " ");
        }
    }
}