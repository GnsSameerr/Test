using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Utilities.PRTG
{
    public static class Devices
    {
        public static void GetAllDevices(PrtgAPI.PrtgClient client)
        {
            var Devices = client.GetDevices();
            PRTGAutotaskEntities pRTGAutotaskEntities = new PRTGAutotaskEntities();
            var ExistingDevices = pRTGAutotaskEntities.PRTGDevices;

            foreach (var x in Devices)
            {
                PRTGDevice Existing = ExistingDevices.Where(y => y.DeviceId == x.Id).FirstOrDefault();

                if (Existing == null)
                {

                    PRTGDevice pRTGDevice = new PRTGDevice();
                    pRTGDevice.Group = x.Group;
                    pRTGDevice.Host = x.Host;
                    pRTGDevice.Location = x.Location;
                    pRTGDevice.Probe = x.Probe;
                    pRTGDevice.Dependency = x.Dependency;
                    pRTGDevice.DeviceId = x.Id;
                    pRTGDevice.Name = x.Name;
                    pRTGDevice.Active = x.Active.ToString();
                    pRTGDevice.DisplayType = x.DisplayType;
                    pRTGDevice.ParentId= x.ParentId;                    
                    pRTGAutotaskEntities.PRTGDevices.Add(pRTGDevice);
                    pRTGAutotaskEntities.SaveChanges();
                }
            }
        }
    }
}
