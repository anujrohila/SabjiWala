using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    /// <summary>
    /// This view model will be inherited in all models (DTOs)
    /// </summary>
    public class PageHeaderModel
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string CannonicalLink { get; set; }
    }

}
