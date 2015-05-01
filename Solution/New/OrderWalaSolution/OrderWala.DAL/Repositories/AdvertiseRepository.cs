using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;


namespace OrderWala.DAL
{
    public class AdvertiseRepository
    {
        #region[methods]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<tblAdvertisementDTO> GetAllAdvertisement()
        { 
                      using (var OrderWalaContext = new OrderWalaEntities())
                        {
               

                        return OrderWalaContext.tblAdvertisements.ToList().ToDTOs();
                    }
        
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbladvertisementdto"></param>
        /// <returns></returns>
        public int AdvertiseSave(tblAdvertisementDTO tbladvertisementdto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateAdvertise(tbladvertisementdto.AdvertisementName, tbladvertisementdto.AdvertisementId))
                {
                    return 1;
                }

                if (tbladvertisementdto.AdvertisementId == 0)
                {
                    OrderWalaContext.tblAdvertisements.Add(tbladvertisementdto.ToEntity());
                }
                else
                {

                    var Advertisedata = OrderWalaContext.tblAdvertisements.Where(at => at.AdvertisementId == tbladvertisementdto.AdvertisementId).FirstOrDefault();

                    Advertisedata.AdvertisementName = tbladvertisementdto.AdvertisementName;
                    
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
        /// <param name="Advertisename"></param>
        /// <param name="AdvertisementId"></param>
        /// <returns></returns>
        public bool IsDuplicateAdvertise(string Advertisename, int AdvertisementId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
              

                var AdvertiseCount = OrderWalaContext.tblAdvertisements.Where(at => string.Compare(at.AdvertisementName, Advertisename) == 0 && at.AdvertisementId != AdvertisementId).ToList();

                return AdvertiseCount.Count > 0 ? true : false;
            }
        
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdvertiseID"></param>
        /// <returns></returns>
        public tblAdvertisementDTO GetAdvertiseByAdvertiseId(int AdvertiseID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblAdvertisements.Where(at => at.AdvertisementId == AdvertiseID).FirstOrDefault().ToDTO();
            }
        
        }


        public bool AdvertiseDelete(int Advertisementid)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Advertise = OrderWalaContext.tblAdvertisements.Where(at => at.AdvertisementId == Advertisementid ).FirstOrDefault();
                OrderWalaContext.tblAdvertisements.Remove(Advertise);
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
