using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.Domain;
using OrderWala.DAL;

namespace OrderWala.DAL.Repositories
{
    public class SubCategoryRepository
    {           
        public int SubCategorySavedata(tblLanguageWiseSubCategoryDTO tblSubCategoryDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateSubcategory(tblSubCategoryDTO.SubCategoryName, tblSubCategoryDTO.SubCategoryId))
                {
                    return 1;
                }

                if (tblSubCategoryDTO.SubCategoryId == 0)
                {
                    tblSubCategory tblsubcategory = new tblSubCategory();
                    tblsubcategory.IsActive = true;
                    tblsubcategory.Logo = tblSubCategoryDTO.Logo;
                    tblsubcategory.CategoryId = tblSubCategoryDTO.CategoryId;
                    OrderWalaContext.tblSubCategories.Add(tblsubcategory);

                    if (OrderWalaContext.SaveChanges() > 0)
                    {
                        tblLanguageWiseSubCategory lngwisesubcategory = new tblLanguageWiseSubCategory();
                        lngwisesubcategory.SubCategoryId = tblsubcategory.SubCategoryId;
                        lngwisesubcategory.Description = tblSubCategoryDTO.Description;
                        lngwisesubcategory.LanguageId = tblSubCategoryDTO.LanguageId;
                        lngwisesubcategory.SubCategoryName = tblSubCategoryDTO.SubCategoryName;
                        OrderWalaContext.tblLanguageWiseSubCategories.Add(lngwisesubcategory);
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

        public tblSubCategoryDTO GetSubCategoryById(int SubCategoryId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblSubCategories.Where(ct => ct.SubCategoryId == SubCategoryId).FirstOrDefault().ToDTO();
            }
        }

        public bool IsDuplicateSubcategory(string SubCategoryName, int SubCategoryId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var SubCatCount = orderwalacontext.tblLanguageWiseSubCategories.Where(dt => string.Compare(dt.SubCategoryName, SubCategoryName) == 0 && dt.SubCategoryId != SubCategoryId).ToList();
                return SubCatCount.Count > 0 ? true : false;
            }
        }

        
        public List<tblLanguageWiseSubCategoryDTO> GetAllSubCategory()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from lngsubcategory in OrderWalaContext.tblLanguageWiseSubCategories
                        join subcatgory in OrderWalaContext.tblSubCategories on lngsubcategory.SubCategoryId equals subcatgory.SubCategoryId
                        join category in OrderWalaContext.tblLanguageWiseCategories on subcatgory.CategoryId equals category.CategoryId
                                             
                        select new tblLanguageWiseSubCategoryDTO
                        {
                           Categoryname = category.CategoryName,
                           SubCategoryName = lngsubcategory.SubCategoryName,
                           Description = lngsubcategory.Description,
                           Logo = subcatgory.Logo

                        }).ToList();
            }
            
        }

        public bool SubCategoryDelete(int ID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var lngwisesubcategory = OrderWalaContext.tblLanguageWiseSubCategories.Where(lg => lg.RowId == ID).FirstOrDefault();
                var SubCategory = OrderWalaContext.tblSubCategories.Where(st => st.SubCategoryId == lngwisesubcategory.SubCategoryId).FirstOrDefault();
                OrderWalaContext.tblLanguageWiseSubCategories.Remove(lngwisesubcategory);
                OrderWalaContext.tblSubCategories.Remove(SubCategory);
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
