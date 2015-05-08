using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
    public class MasterRepository
    {
        #region [Declaration]

        #endregion

        #region [Constructor]

        public MasterRepository()
        {

        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Area List
        /// </summary>
        /// <returns></returns>
        public List<tblCategoryDTO> GetProductMainCategoryList(int languageId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from category in OrderWalaContext.tblCategories
                        join languageWiseCategories in OrderWalaContext.tblLanguageWiseCategories on category.CategoryId equals languageWiseCategories.CategoryId
                        where category.IsActive == true
                                && category.IsDeleted == false
                                && languageWiseCategories.LanguageId == languageId
                        select new tblCategoryDTO
                        {
                            CategoryId = category.CategoryId,
                            IsActive = category.IsActive,
                            IsDeleted = category.IsDeleted,
                            Logo = category.Logo,
                            CategoryName = languageWiseCategories.CategoryName,
                            Description = languageWiseCategories.Description,
                            LanguageId = languageWiseCategories.LanguageId
                        }).ToList();
            }
        }

        /// <summary>
        /// Get Product Sub Category List
        /// </summary>
        /// <returns></returns>
        public List<tblSubCategoryDTO> GetProductSubCategoryList(int mainCategoryId, int languageId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from subCategory in OrderWalaContext.tblSubCategories
                        join languageWiseSubCategories in OrderWalaContext.tblLanguageWiseSubCategories on subCategory.SubCategoryId equals languageWiseSubCategories.SubCategoryId
                        where subCategory.IsActive == true
                                && subCategory.IsDeleted == false
                                && languageWiseSubCategories.LanguageId == languageId
                                && subCategory.CategoryId == mainCategoryId
                        select new tblSubCategoryDTO
                        {
                            SubCategoryId = subCategory.SubCategoryId,
                            CategoryName = languageWiseSubCategories.SubCategoryName,
                            CategoryId = subCategory.CategoryId,
                            Description = languageWiseSubCategories.Description,
                            IsActive = subCategory.IsActive,
                            IsDeleted = subCategory.IsDeleted,
                            LanguageId = languageWiseSubCategories.LanguageId,
                            Logo = subCategory.Logo,
                        }).ToList();
            }
        }

        /// <summary>
        /// Area List
        /// </summary>
        /// <returns></returns>
        public List<tblProductDTO> GetProductList(int subCategoryId, int languageId, int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from product in OrderWalaContext.tblProducts
                        join languageWiseSubCategories in OrderWalaContext.tblLanguageWiseSubCategories on product.SubCategoryId equals languageWiseSubCategories.SubCategoryId
                        join languageWiseProduct in OrderWalaContext.tblLanguageWiseProducts on product.ProductId equals languageWiseProduct.ProductId
                        join productPrice in OrderWalaContext.tblProductPrices on product.ProductId equals productPrice.ProductId
                        join quantityType in OrderWalaContext.tblQuantityTypes on product.QuantityTypeId equals quantityType.QuantityTypeId
                        where product.IsActive == true
                                && product.IsDeleted == false
                                && languageWiseProduct.LanguageId == languageId
                                && product.SubCategoryId == subCategoryId
                                && productPrice.CityId == cityId
                        select new tblProductDTO
                        {
                            ProductId = product.ProductId,
                            SubCategoryId = product.SubCategoryId,
                            CategoryId = product.CategoryId,
                            QuantityTypeId = product.QuantityTypeId,
                            IsActive = product.IsActive,
                            IsDeleted = product.IsDeleted,
                            ProductName = languageWiseProduct.ProductName,
                            Description = languageWiseProduct.Description,
                            LanguageId = languageWiseProduct.LanguageId ?? 0,
                            OldPrice = productPrice.OldPrice ?? 0,
                            NewPrice = productPrice.NewPrice ?? 0,
                            QuantityTypeName = quantityType.TypeName,
                            Logo = product.Logo,
                            SubCategoryName = languageWiseSubCategories.SubCategoryName
                        }).ToList();
            }
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        public tblProductDTO GetProduct(int productId, int languageId, int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from product in OrderWalaContext.tblProducts
                        join languageWiseSubCategories in OrderWalaContext.tblLanguageWiseSubCategories on product.SubCategoryId equals languageWiseSubCategories.SubCategoryId
                        join languageWiseProduct in OrderWalaContext.tblLanguageWiseProducts on product.ProductId equals languageWiseProduct.ProductId
                        join productPrice in OrderWalaContext.tblProductPrices on product.ProductId equals productPrice.ProductId
                        join quantityType in OrderWalaContext.tblQuantityTypes on product.QuantityTypeId equals quantityType.QuantityTypeId
                        where product.ProductId == productId
                                && product.IsActive == true
                                && product.IsDeleted == false
                                && languageWiseProduct.LanguageId == languageId
                                && productPrice.CityId == cityId
                        select new tblProductDTO
                        {
                            ProductId = product.ProductId,
                            SubCategoryId = product.SubCategoryId,
                            CategoryId = product.CategoryId,
                            QuantityTypeId = product.QuantityTypeId,
                            IsActive = product.IsActive,
                            IsDeleted = product.IsDeleted,
                            ProductName = languageWiseProduct.ProductName,
                            Description = languageWiseProduct.Description,
                            LanguageId = languageWiseProduct.LanguageId ?? 0,
                            OldPrice = productPrice.OldPrice ?? 0,
                            NewPrice = productPrice.NewPrice ?? 0,
                            QuantityTypeName = quantityType.TypeName,
                            Logo = product.Logo,
                            SubCategoryName = languageWiseSubCategories.SubCategoryName
                        }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Area List
        /// </summary>
        /// <returns></returns>
        public List<tblAreaDTO> GetAllArea()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                //return (from area in OrderWalaContext.tblAreas
                //        join city in OrderWalaContext.tblCities on area.CityId equals city.CityId
                //        select new tblAreaDTO
                //        {
                //            AreaId = area.AreaId,
                //            AreaName = area.AreaName,
                //            CityId = area.CityId,
                //            Description = area.Description


                //        }).ToList();

                return OrderWalaContext.tblAreas.ToList().ToDTOs();
            }
        }

        /// <summary>
        /// City List
        /// </summary>
        /// <returns></returns>
        public List<tblCityDTO> GetAllCity()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from city in OrderWalaContext.tblCities
                        join state in OrderWalaContext.tblStates on city.StateId equals state.StateId
                        select new tblCityDTO
                        {
                            CityId = city.CityId,
                            CityName = city.CityName,
                            StateId = city.StateId,
                            StateName = state.StateName
                        }).ToList();
            }
            //using (var OrderWalaContext = new OrderWalaEntities())
            //{
            //    return OrderWalaContext.tblCities.ToList().ToDTOs();
            //}
        }

        /// <summary>
        /// Save And Update state
        /// </summary>
        /// <param name="statedto"></param>
        /// <returns></returns>
        public int StateSave(tblStateDTO statedto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateState(statedto.StateName, statedto.StateId))
                {
                    return 1;
                }

                if (statedto.StateId == 0)
                {
                    OrderWalaContext.tblStates.Add(statedto.ToEntity());
                }
                else
                {

                    var statedata = OrderWalaContext.tblStates.Where(st => st.StateId == statedto.StateId).FirstOrDefault();

                    statedata.StateName = statedto.StateName;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<tblStateDTO> GetAllState()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblStates.ToList().ToDTOs();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateID"></param>
        /// <returns></returns>
        public tblStateDTO GetStateByStateID(int StateID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblStates.Where(st => st.StateId == StateID).FirstOrDefault().ToDTO();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateID"></param>
        /// <returns></returns>
        public bool StateDelete(int StateID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var state = OrderWalaContext.tblStates.Where(st => st.StateId == StateID).FirstOrDefault();
                OrderWalaContext.tblStates.Remove(state);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statename"></param>
        /// <param name="StateID"></param>
        /// <returns></returns>
        public bool IsDuplicateState(string Statename, int StateID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                //userDetailDTO = new UserDetailResponse();
                //var loginDetails = (from login in OrderWalaContext.tblLogins
                //                    where string.Compare(mobileNo, login.MobileNo, StringComparison.CurrentCultureIgnoreCase) == 0
                //                    select login).ToList();

                var stattcount = OrderWalaContext.tblStates.Where(st => string.Compare(st.StateName, Statename) == 0 && st.StateId != StateID).ToList();

                return stattcount.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityname"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public bool IsDuplicateCity(string cityname, int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {

                var citycount = OrderWalaContext.tblCities.Where(ct => string.Compare(ct.CityName, cityname) == 0 && ct.CityId != cityId).ToList();
                return citycount.Count > 0 ? true : false;


            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblcitydto"></param>
        /// <returns></returns>
        public int CitySave(tblCityDTO tblcitydto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateCity(tblcitydto.CityName, tblcitydto.CityId))
                {
                    return 1;
                }

                if (tblcitydto.CityId == 0)
                {
                    OrderWalaContext.tblCities.Add(tblcitydto.ToEntity());
                }
                else
                {
                    var citydata = OrderWalaContext.tblCities.Where(ct => ct.CityId == tblcitydto.CityId).FirstOrDefault();
                    citydata.StateId = tblcitydto.StateId;
                    citydata.CityName = tblcitydto.CityName;

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
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public tblCityDTO GetCityByCityId(int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCities.Where(ct => ct.CityId == cityId).FirstOrDefault().ToDTO();

            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public bool citydelete(int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var city = OrderWalaContext.tblCities.Where(ct => ct.CityId == cityId).FirstOrDefault();
                OrderWalaContext.tblCities.Remove(city);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblareadto"></param>
        /// <returns></returns>
        public int AreaSave(tblAreaDTO tblareadto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateArea(tblareadto.AreaName, tblareadto.AreaId))
                {
                    return 1;
                }

                if (tblareadto.AreaId == 0)
                {
                    tblArea area = new tblArea();
                    area.StateId = tblareadto.StateId;
                    area.CityId = tblareadto.CityId;
                    tblareadto.StateId = area.StateId;
                    tblareadto.CityId = area.CityId;
                    OrderWalaContext.tblAreas.Add(tblareadto.ToEntity());
                }
                else
                {


                    var citydata = OrderWalaContext.tblAreas.Where(at => at.AreaId == tblareadto.AreaId).FirstOrDefault();

                    citydata.AreaName = tblareadto.AreaName;
                    citydata.CityId = tblareadto.CityId;
                    citydata.StateId = tblareadto.StateId;

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
        /// 
        /// </summary>
        /// <param name="AreaName"></param>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public bool IsDuplicateArea(string AreaName, int AreaId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {

                var Areacount = OrderWalaContext.tblAreas.Where(at => string.Compare(at.AreaName, AreaName) == 0 && at.AreaId != AreaId).ToList();
                return Areacount.Count > 0 ? true : false;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public tblAreaDTO GetAreaByAreaId(int AreaId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblAreas.Where(at => at.AreaId == AreaId).FirstOrDefault().ToDTO();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public bool AreaDelete(int AreaId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Area = OrderWalaContext.tblAreas.Where(at => at.AreaId == AreaId).FirstOrDefault();
                OrderWalaContext.tblAreas.Remove(Area);
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




        #endregion

    }
}
