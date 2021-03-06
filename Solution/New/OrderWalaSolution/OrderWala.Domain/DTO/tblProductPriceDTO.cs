//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/05/07 - 17:17:13
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderWala.Domain
{
    [DataContract()]
    public partial class tblProductPriceDTO
    {
        [DataMember()]
        public Int32 PriceId { get; set; }

        [DataMember()]
        public Nullable<Int32> ProductId { get; set; }

        [DataMember()]
        public Nullable<Int32> CityId { get; set; }

        [DataMember()]
        public Nullable<Double> OldPrice { get; set; }

        [DataMember()]
        public Nullable<Double> NewPrice { get; set; }

        [DataMember()]
        public Nullable<DateTime> CreationDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> UpdationDateTime { get; set; }

        public tblProductPriceDTO()
        {
        }

        public tblProductPriceDTO(Int32 priceId, Nullable<Int32> productId, Nullable<Int32> cityId, Nullable<Double> oldPrice, Nullable<Double> newPrice, Nullable<DateTime> creationDateTime, Nullable<DateTime> updationDateTime)
        {
			this.PriceId = priceId;
			this.ProductId = productId;
			this.CityId = cityId;
			this.OldPrice = oldPrice;
			this.NewPrice = newPrice;
			this.CreationDateTime = creationDateTime;
			this.UpdationDateTime = updationDateTime;
        }
    }
}
