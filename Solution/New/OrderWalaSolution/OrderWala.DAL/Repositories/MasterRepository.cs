﻿using System;
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



     public  List<tblStateDTO> GetAllState()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblStates.ToList().ToDTOs();
            }
        }

        public tblStateDTO GetStateByStateID(int StateID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblStates.Where(st => st.StateId == StateID).FirstOrDefault().ToDTO();
            }
        }


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

        public bool IsDuplicateCity(string cityname, int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {

                var citycount = OrderWalaContext.tblCities.Where(ct => string.Compare(ct.CityName, cityname) == 0 && ct.CityId != cityId).ToList();
                return citycount.Count > 0 ? true : false;

            
            }
        
        }


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

        public tblCityDTO GetCityByCityId(int cityId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCities.Where(ct => ct.CityId == cityId).FirstOrDefault().ToDTO();
                
            }
        
        }



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
                    OrderWalaContext.tblAreas.Add(tblareadto.ToEntity());
                }
                else
                {

                    GetAllCity();
                    GetAllState();
                    var citydata = OrderWalaContext.tblAreas.Where(at => at.AreaId == tblareadto.AreaId).FirstOrDefault();
                    citydata.AreaName = tblareadto.AreaName;

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

       

        public bool IsDuplicateArea(string AreaName, int AreaId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {

                var Areacount = OrderWalaContext.tblAreas.Where(at => string.Compare(at.AreaName, AreaName) == 0 && at.AreaId != AreaId).ToList();
                return Areacount.Count > 0 ? true : false;
            }
        }


       

        public tblAreaDTO GetAreaByAreaId(int AreaId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblAreas.Where(at => at.AreaId == AreaId).FirstOrDefault().ToDTO();

            }   
        }


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
