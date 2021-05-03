using AutoTask.Api;
using PrtgAPI; 
using PRTGAutoTaskScheduler.Utilities.AutoTask;
using PRTGAutoTaskScheduler.Utilities.PRTG;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler
{
    class Program
    { 
        static void Main(string[] args)
        {
            string PRTGServer = ConfigurationManager.AppSettings["PRTGServer"];
            string PRTGUserName = ConfigurationManager.AppSettings["PRTGUserName"];  
            string PRTGPassword = ConfigurationManager.AppSettings["PRTGPassword"];

            var client = new PrtgClient(PRTGServer, PRTGUserName, PRTGPassword);             
            Console.WriteLine("AutoTask Companies started..");
            AutoTaskCompanies.GetAllCompanies();
            Console.WriteLine("AutoTask Companies completed..");
            Console.WriteLine("AutoTask configuration item started..");

            AutoTaskConfiguration.GetAllConfigurationItems();
            Console.WriteLine("AutoTask configuration item completed");
            Console.WriteLine("AutoTask configuration location started..");


            AutoTaskCompanyLocations.GetAllCompanyLocations();
            Console.WriteLine("AutoTask configuration location completed..");
            Console.WriteLine("PRTG group started..");

            Groups.GetAllGroups(client);
            Console.WriteLine("PRTG group completed..");
            Console.WriteLine("PRTG devices started..");

            Devices.GetAllDevices(client);
            Console.WriteLine("PRTG devices completed..");

            //Tickets.GetTickets(client);
        }
    }
}
