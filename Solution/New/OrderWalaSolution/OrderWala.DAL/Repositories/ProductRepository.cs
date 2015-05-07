using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;
using System.IO;

namespace OrderWala.DAL
{
    public class ProductRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<tblProductDTO> GetAllProduct()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from Product in OrderWalaContext.tblProducts
                        join catgory in OrderWalaContext.tblLanguageWiseCategories on Product.CategoryId equals catgory.CategoryId
                        join subcatgory in OrderWalaContext.tblLanguageWiseSubCategories on Product.SubCategoryId equals subcatgory.SubCategoryId
                        join Quantity in OrderWalaContext.tblQuantityTypes on Product.QuantityTypeId equals Quantity.QuantityTypeId
                        select new tblProductDTO
                        {
                           ProductId = Product.ProductId,                           
                          CategoryName = catgory.CategoryName,
                          SubCategoryName = subcatgory.SubCategoryName,
                           Quantity = Quantity.TypeName,
                           Logo = Product.Logo

                        }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        public tblLanguageWiseProductDTO GetProductById(int rowid)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblLanguageWiseProducts.Where(ct => ct.RowId == rowid).FirstOrDefault().ToDTO();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool IsDuplicateProduct(string ProductName, int ProductId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var Productcount = orderwalacontext.tblLanguageWiseProducts.Where(pd => string.Compare(pd.ProductName, ProductName) == 0 && pd.ProductId != ProductId).ToList();

                return Productcount.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblProductDTO"></param>
        /// <returns></returns>
        public int ProductSave(tblLanguageWiseProductDTO tblProductDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateProduct(tblProductDTO.ProductName, tblProductDTO.ProductId.Value))
                {
                    return 1;
                }

                if (tblProductDTO.ProductId == 0)
                {

                    var product = new tblProduct();

                    product.CategoryId = tblProductDTO.CategoryID;
                    product.SubCategoryId = tblProductDTO.SubCategoryID;
                    product.QuantityTypeId = tblProductDTO.QuantityID;
                    product.IsActive = true;

                    OrderWalaContext.tblProducts.Add(product);
                    if (OrderWalaContext.SaveChanges() > 0)
                    {
                        tblLanguageWiseProduct LangWiseProduct = new tblLanguageWiseProduct();

                        LangWiseProduct.ProductId = product.ProductId;
                        LangWiseProduct.ProductName = tblProductDTO.ProductName;
                        LangWiseProduct.LanguageId = tblProductDTO.LanguageId;
                        LangWiseProduct.Description = tblProductDTO.Description;

                        OrderWalaContext.tblLanguageWiseProducts.Add(LangWiseProduct);
                    }

                   
                }               

                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
        }

    }
}
