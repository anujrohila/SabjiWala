using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientSite.Models;

namespace ClientSite
{
    public class VegitableGalleryModel
    {
        public List<TblSubCategoryMaster> SubCategoryList { get; set; }
        public List<TblProductMaster> ProductListing { get; set; }
        public List<TblCategoryMaster> CategoryList { get; set; }
    }
}