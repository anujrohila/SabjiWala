using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
    public class DeviceRepository
    {

        #region [methods]

        public List<tblDeviceTypeDTO> GetAllDevice()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblDeviceTypes.ToList().ToDTOs();
            }
        }

        public int DeviceSave(tblDeviceTypeDTO tbldevicetypedto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateDevice(tbldevicetypedto.DeviceType, tbldevicetypedto.DeviceId))
                {
                    return 1;
                }

                if (tbldevicetypedto.DeviceId == 0)
                {
                    OrderWalaContext.tblDeviceTypes.Add(tbldevicetypedto.ToEntity());
                }
                else
                {
                    var devicedata = OrderWalaContext.tblDeviceTypes.Where(dt => dt.DeviceId == tbldevicetypedto.DeviceId).FirstOrDefault();
                    devicedata.DeviceType = tbldevicetypedto.DeviceType;
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

        public bool IsDuplicateDevice(string devicetypename, int deviceId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var devicecount = orderwalacontext.tblDeviceTypes.Where(dt => string.Compare(dt.DeviceType, devicetypename) == 0 && dt.DeviceId != deviceId).ToList();

                return devicecount.Count > 0 ? true : false;
            }
        }

        public tblDeviceTypeDTO GetDeviceByDeviceId(int DeviceId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblDeviceTypes.Where(dt => dt.DeviceId == DeviceId).FirstOrDefault().ToDTO();
            }

        }

        public bool DeviceDelete(int DeviceId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Device = OrderWalaContext.tblDeviceTypes.Where(dt => dt.DeviceId == DeviceId).FirstOrDefault();
                OrderWalaContext.tblDeviceTypes.Remove(Device);
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
