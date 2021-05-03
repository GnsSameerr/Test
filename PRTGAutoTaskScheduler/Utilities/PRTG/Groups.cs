using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Utilities.PRTG
{
    public static class Groups
    {
       public static void GetAllGroups(PrtgAPI.PrtgClient client)
       {
            var Groups = client.GetGroups();
            PRTGAutotaskEntities pRTGAutotaskEntities = new PRTGAutotaskEntities();
            var ExistingGroups = pRTGAutotaskEntities.PRTGGroups;
            foreach (var x in Groups)
            {
                PRTGGroup Existing = ExistingGroups.Where(y => y.GroupId == x.Id).FirstOrDefault();

                if (Existing == null)
                {

                    PRTGGroup pRTGGroup = new PRTGGroup();
                    pRTGGroup.Probe = x.Probe;
                    pRTGGroup.GroupId = x.Id;
                    pRTGGroup.ParentId = x.ParentId;
                    pRTGGroup.Name = x.Name;
                    pRTGGroup.DisplayType = x.DisplayType;
                    pRTGGroup.Active = x.Active.ToString();
                    

                    pRTGAutotaskEntities.PRTGGroups.Add(pRTGGroup);
                    pRTGAutotaskEntities.SaveChanges();
                } 
            }    
        }
    }
}
