using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Utilities.PRTG
{
    public class Tickets
    {

        public static void GetTickets(PrtgAPI.PrtgClient client)
        {
            var Tickets = client.GetNotificationActions();
            
             
            foreach (var x in Tickets)
            {
                
            }
        }

    }
}
