using Newtonsoft.Json;
using PRTGAutoTaskScheduler.Model.AutoTaskLocation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Utilities.AutoTask
{
    public class AutoTaskCompanyLocations
    {

        public static void GetAllCompanyLocations()
        {

            string API = "https://webservices14.autotask.net/ATServicesRest/V1.0/CompanyLocations/query?search={\"Filter\":[{\"field\":\"Id\",\"op\":\"gte\",\"value\":0}]}";
            AllCompanyLocationsExecution(API);
        }

        private static void AllCompanyLocationsExecution(string API)
        {
            IRestResponse response = Common.ExecuteAutoTaskAPI(API);

            AutoTaskCompanyLocationModel AutoTaskCompanyLocationModel = JsonConvert.DeserializeObject<AutoTaskCompanyLocationModel>(response.Content);

            SaveData(AutoTaskCompanyLocationModel);
        }

        private static void SaveData(AutoTaskCompanyLocationModel autoTaskCompanyLocationModel)
        {
            try
            {
                PRTGAutotaskEntities pRTGAutotaskEntities = new PRTGAutotaskEntities();
                var ExistingCompanyLocation = pRTGAutotaskEntities.AutoTaskCompanyLocations;

                foreach (var x in autoTaskCompanyLocationModel.items)
                {
                    int? CompanyLocation = x.id;

                    var existing = pRTGAutotaskEntities.AutoTaskCompanyLocations
                       .Where(c => c.Id == CompanyLocation)
                       .FirstOrDefault();

                    if (existing == null)
                    {
                        AutoTaskCompanyLocation AutoTaskCompanyLocations = new AutoTaskCompanyLocation();


                        AutoTaskCompanyLocations.Id = x.id;
                        AutoTaskCompanyLocations.address1 = x.address1;
                        AutoTaskCompanyLocations.address2 = x.address2;
                        AutoTaskCompanyLocations.alternatePhone1 = x.alternatePhone1;
                        AutoTaskCompanyLocations.alternatePhone2 = x.alternatePhone2;
                        AutoTaskCompanyLocations.city = x.city;
                        AutoTaskCompanyLocations.companyID = x.companyID;
                        AutoTaskCompanyLocations.countryID = x.countryID;
                        AutoTaskCompanyLocations.description = x.description;
                        AutoTaskCompanyLocations.fax = x.fax;
                        AutoTaskCompanyLocations.isActive = Convert.ToString(x.isActive);
                        AutoTaskCompanyLocations.isPrimary = Convert.ToString(x.isPrimary);
                        AutoTaskCompanyLocations.isTaxExempt = Convert.ToString(x.isTaxExempt);
                        AutoTaskCompanyLocations.overrideCompanyTaxSettings = Convert.ToString(x.overrideCompanyTaxSettings);
                        AutoTaskCompanyLocations.name = x.name;
                        AutoTaskCompanyLocations.phone = x.phone;
                        AutoTaskCompanyLocations.postalCode = x.postalCode;
                        AutoTaskCompanyLocations.roundtripDistance = x.roundtripDistance;
                        AutoTaskCompanyLocations.state = x.state;
                        AutoTaskCompanyLocations.taxRegionID = Convert.ToString(x.taxRegionID);


                        pRTGAutotaskEntities.AutoTaskCompanyLocations.Add(AutoTaskCompanyLocations);
                        pRTGAutotaskEntities.SaveChanges();

                    }
                }
                if (autoTaskCompanyLocationModel.pageDetails.nextPageUrl != null)
                {
                    string API = autoTaskCompanyLocationModel.pageDetails.nextPageUrl.ToString();
                    AllCompanyLocationsExecution(API);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();

            }
        }
    }
}
