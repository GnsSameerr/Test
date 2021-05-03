using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Utilities
{
    public class Common
    {

        public static IRestResponse ExecuteAutoTaskAPI(string API)
        {
            string AutoTaskUserName = ConfigurationManager.AppSettings["AutoTaskUserName"];
            string AutoTaskSecret = ConfigurationManager.AppSettings["AutoTaskSecret"];
            string AutoTAskAPIIntegrationCode = ConfigurationManager.AppSettings["AutoTAskAPIIntegrationCode"];

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var client = new RestClient("https://webservices14.autotask.net/ATServicesRest/V1.0");
            var request = new RestRequest(API, Method.GET);

            request.AddHeader("accept", "application/json");
            request.AddHeader("ApiIntegrationCode", AutoTAskAPIIntegrationCode);
            request.AddHeader("UserName", AutoTaskUserName);
            request.AddHeader("Secret", AutoTaskSecret);
            IRestResponse response = client.Execute(request);

            return response;
        }

    }
}
