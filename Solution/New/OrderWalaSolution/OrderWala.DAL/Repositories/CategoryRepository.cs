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
        public int CategorySave(tblCategoryDTO CategoryDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateCategory(CategoryDTO.CategoryName,CategoryDTO.CategoryId))
                {
                    return 1;
                }

                if (CategoryDTO.CategoryId == 0)
                {
                     CategoryDTO.Logo = CategoryDTO.Logo;
                     OrderWalaContext.tblCategories.Add(CategoryDTO.ToEntity());
                }
                else
                {
                    var categorydata = OrderWalaContext.tblCategories.Where(ct => ct.CategoryId == CategoryDTO.CategoryId).FirstOrDefault();
                   // categorydata.CategoryName = CategoryDTO.CategoryName;
                    categorydata.Logo = CategoryDTO.Logo;
                   // categorydata.Description = CategoryDTO.Description;
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

        










        public List<tblCategoryDTO> GetAllCategory()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCategories.ToList().ToDTOs();
            }
        }


        public bool IsDuplicateCategory(string CategoryName , int CategoryId)
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


        public bool CategoryDelete(int ID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Category = OrderWalaContext.tblCategories.Where(st => st.CategoryId == ID).FirstOrDefault();
                OrderWalaContext.tblCategories.Remove(Category);
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

