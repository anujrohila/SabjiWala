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
        public List<tblSubCategoryDTO> GetAllSubCategory()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblSubCategories.ToList().ToDTOs();
            }
        }


        public int SubCategorySavedata(tblSubCategoryDTO tblSubCategoryDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateDevice(tblSubCategoryDTO.SubCategoryName, tblSubCategoryDTO.SubCategoryId))
                {
                    return 1;
                }

                if (tblSubCategoryDTO.SubCategoryId == 0)
                {
                    tblSubCategoryDTO.LanguageId = 1;
                    tblSubCategoryDTO.IsActive= true;
                    tblSubCategoryDTO.IsDeleted = true;
                    OrderWalaContext.tblSubCategories.Add(tblSubCategoryDTO.ToEntity());
                }
                else
                {
                    var subcatdata = OrderWalaContext.tblSubCategories.Where(dt => dt.SubCategoryId == tblSubCategoryDTO.SubCategoryId).FirstOrDefault();
                    subcatdata.SubCategoryName = tblSubCategoryDTO.SubCategoryName;
                    subcatdata.Logo = tblSubCategoryDTO.Logo;
                    subcatdata.Description = tblSubCategoryDTO.Description;
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

        public bool IsDuplicateDevice(string SubCategoryName, int SubCategoryId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var SubCatCount = orderwalacontext.tblSubCategories.Where(dt => string.Compare(dt.SubCategoryName, SubCategoryName) == 0 && dt.SubCategoryId != SubCategoryId).ToList();

                return SubCatCount.Count > 0 ? true : false;
            }
        }

       

    }
}
