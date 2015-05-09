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
        public List<tblLanguageWiseProductDTO> GetAllProduct()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from lngwiseProduct in OrderWalaContext.tblLanguageWiseProducts
                        join product in OrderWalaContext.tblProducts on lngwiseProduct.ProductId equals product.ProductId
                        join catgory in OrderWalaContext.tblLanguageWiseCategories on product.CategoryId equals catgory.CategoryId
                        join subcatgory in OrderWalaContext.tblLanguageWiseSubCategories on product.SubCategoryId equals subcatgory.SubCategoryId
                        join Quantity in OrderWalaContext.tblQuantityTypes on product.QuantityTypeId equals Quantity.QuantityTypeId
                        select new tblLanguageWiseProductDTO
                        {
                           RowId = lngwiseProduct.RowId,
                           ProductId = product.ProductId,  
                           categoryname =  catgory.CategoryName,
                           Subcategoryname = subcatgory.SubCategoryName,
                           Quantity = Quantity.TypeName,
                           ProductName = lngwiseProduct.ProductName,
                           Description = lngwiseProduct.Description,
                           Logo = product.Logo                         
                        }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        public tblProductDTO GetProductById(int ProductId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblProducts.Where(ct => ct.ProductId == ProductId).FirstOrDefault().ToDTO();
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
        public int ProductSave(tblProductDTO tblProductDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if(IsDuplicateProduct(tblProductDTO.ProductName, tblProductDTO.ProductId))
                {
                    return 1;
                }

                if (tblProductDTO.ProductId == 0)
                {
                    tblProduct product = new tblProduct();
                    product.CategoryId = tblProductDTO.CategoryId;
                    product.SubCategoryId = tblProductDTO.SubCategoryId;
                    product.QuantityTypeId = tblProductDTO.QuantityTypeId;
                    product.Logo = tblProductDTO.Logo;
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

        /// <summary>
        /// product delete
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public bool   ProductDelete(int RowID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var lgwiseproduct = OrderWalaContext.tblLanguageWiseProducts.Where(lg => lg.RowId == RowID).FirstOrDefault();
                var product = OrderWalaContext.tblProducts.Where(ct => ct.ProductId == lgwiseproduct.ProductId).FirstOrDefault();
                OrderWalaContext.tblLanguageWiseProducts.Remove(lgwiseproduct);
                OrderWalaContext.tblProducts.Remove(product);
                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
