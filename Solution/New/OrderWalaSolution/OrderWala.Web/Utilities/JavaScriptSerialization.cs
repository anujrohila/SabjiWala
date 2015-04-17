
namespace OrderWala.Web
{
    public static class JavaScriptSerialization
    {
        /// <summary>
        /// Serialize to JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string json)
        {
          
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Json String to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T instance)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(instance);
        }
    }
}
