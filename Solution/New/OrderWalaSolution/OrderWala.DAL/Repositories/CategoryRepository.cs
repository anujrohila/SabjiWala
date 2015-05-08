using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL.Repositories;
using OrderWala.Domain;
using System.IO;
using System.Data;
using System.Web;

namespace OrderWala.DAL
{
    public class CategoryRepository
    {
        public int CategorySave(tblLanguageWiseCategoryDTO CategoryDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateCategory(CategoryDTO.CategoryName, CategoryDTO.CategoryId))
                {
                    return 1;
                }

                if (CategoryDTO.CategoryId == 0)
                {
                    tblCategory tblcategory = new tblCategory();
                    tblcategory.IsActive = true;
                    tblcategory.Logo = CategoryDTO.Logo;
                    OrderWalaContext.tblCategories.Add(tblcategory);
                    if (OrderWalaContext.SaveChanges() > 0)
                    {
                        tblLanguageWiseCategory tbllngwiseCategory = new tblLanguageWiseCategory();
                        tbllngwiseCategory.CategoryId = tblcategory.CategoryId;
                        tbllngwiseCategory.CategoryName = CategoryDTO.CategoryName;
                        tbllngwiseCategory.Description = CategoryDTO.Description;
                        tbllngwiseCategory.LanguageId = CategoryDTO.LanguageId;
                        OrderWalaContext.tblLanguageWiseCategories.Add(tbllngwiseCategory);
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


        public List<tblLanguageWiseCategoryDTO> GetAllCategory()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from lngcategory in OrderWalaContext.tblLanguageWiseCategories
                        join catgory in OrderWalaContext.tblCategories on lngcategory.CategoryId equals catgory.CategoryId
                       
                        select new tblLanguageWiseCategoryDTO
                        {
                            CategoryId = catgory.CategoryId,
                            CategoryName = lngcategory.CategoryName,
                            Description = lngcategory.Description,
                            Logo = catgory.Logo

                        }).ToList();
                
            }
        }


        public bool IsDuplicateCategory(string CategoryName, int CategoryId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var CAtegoryCount = OrderWalaContext.tblLanguageWiseCategories.Where(ct => string.Compare(ct.CategoryName, CategoryName) == 0 && ct.CategoryId != CategoryId).ToList();

                return CAtegoryCount.Count > 0 ? true : false;
            }
        }


        public tblCategoryDTO GetCAtegoryById(int CategoryId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCategories.Where(ct => ct.CategoryId == CategoryId).FirstOrDefault().ToDTO();
            }
        }


        public bool CategoryDelete(int RowID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var lgwisecategory = OrderWalaContext.tblLanguageWiseCategories.Where(lg => lg.RowId == RowID).FirstOrDefault();
                var category = OrderWalaContext.tblCategories.Where(ct => ct.CategoryId == lgwisecategory.CategoryId).FirstOrDefault();              
                OrderWalaContext.tblLanguageWiseCategories.Remove(lgwisecategory);
                OrderWalaContext.tblCategories.Remove(category);               
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

