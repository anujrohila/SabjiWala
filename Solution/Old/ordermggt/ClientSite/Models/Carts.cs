using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSite
{
    public static class Carts
    {
        public static List<itemDetails> CartDetails;
    }
    public class itemDetails
    {
      
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
       
       
    }
}