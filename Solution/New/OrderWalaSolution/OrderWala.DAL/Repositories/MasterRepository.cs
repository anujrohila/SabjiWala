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
        public List<tblAreaDTO> GetAllArea()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from area in OrderWalaContext.tblAreas
                        select new tblAreaDTO
                        {
                            AreaId = area.AreaId,
                            AreaName = area.AreaName,
                            CityId = area.CityId,
                            Description = area.Description,
                            StateId = area.StateId
                        }).ToList();
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
                        select new tblCityDTO
                        {
                            CityId = city.CityId,
                            CityName = city.CityName,
                            StateId = city.StateId
                        }).ToList();
            }
        }
        #endregion
    }
}
