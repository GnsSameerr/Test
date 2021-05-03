using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoTask.Api;
using Newtonsoft.Json;
using RestSharp;
using PRTGAutoTaskScheduler.Model.Companies;

namespace PRTGAutoTaskScheduler.Utilities.AutoTask
{
    class AutoTaskCompanies
    {

        //    public static async Task GetAllCompanies()
        //    {

        //        var result = await client
        //.ExecuteQueryAsync("<queryxml><entity>Account</entity><query><field>id<expression op=\"greaterthan\">0</expression></field></query></queryxml>")
        //.ConfigureAwait(false);
        //    }

        public static void GetAllCompanies()
        {
            //var Client = new Client("cauwhce2kcepoft@APPLIEDI.NET", "6s$Z*Ht53~Ki@Xm7Aa4#w1$D8", "6KLTYSJEWX5FUAZCABSOU7MMTAF");
            //var result = await Client.QueryAsync("<queryxml><entity>Account</entity><query><field>id<expression op=\"greaterthan\">0</expression></field></query></queryxml>").ConfigureAwait(false);
            //var result = await Client.QueryAsync("<queryxml><entity>Account</entity><query><field>Id<expression op=\"greaterthan\">0</expression></field></query></queryxml>").ConfigureAwait(false);
            //var result = await Client.QueryAsync("<queryxml><entity>Account</entity><query><field>Id<expression op=\"greaterthan\">0</expression></field></query></queryxml>").ConfigureAwait(false);
            string api = "https://webservices14.autotask.net/ATServicesRest/V1.0/Companies/query?search={\"Filter\":[{\"field\":\"Id\",\"op\":\"gte\",\"value\":0}]}";
            AllCompaniesExecution(api);

        }

        private static void AllCompaniesExecution(string API)
        {

            IRestResponse response = Common.ExecuteAutoTaskAPI(API);

            AutoTaskCompaniesModel AutoTaskCompaniesModel = JsonConvert.DeserializeObject<AutoTaskCompaniesModel>(response.Content);

            SaveData(AutoTaskCompaniesModel);
        }

        private static void SaveData(AutoTaskCompaniesModel autoTaskCompaniesModel)
        {
            PRTGAutotaskEntities pRTGAutotaskEntities = new PRTGAutotaskEntities();
            var ExistingAutotaskCompanies = pRTGAutotaskEntities.AutoTaskCompanies;

            foreach (var x in autoTaskCompaniesModel.items)
            {
                int? CompanyID = x.id;
                //var existing = ExistingAutotaskCompanies.Where(y => y.CompanyId.Equals(x.id)).ToList();

                var existing = pRTGAutotaskEntities.AutoTaskCompanies
                   .Where(c => c.CompanyId == CompanyID)
                   .FirstOrDefault();
                

                if (existing == null)
                {

                    AutoTaskCompany autoTaskCompany = new AutoTaskCompany();

                    autoTaskCompany.CompanyId = x.id;
                   
                    autoTaskCompany.AdditionalAddressInformation = x.additionalAddressInformation;
                    autoTaskCompany.Address1 = x.address1;
                    autoTaskCompany.Address2 = x.address2;
                    autoTaskCompany.AlternatePhone1 = x.alternatePhone1;
                    autoTaskCompany.AlternatePhone2 = x.alternatePhone2;
                    autoTaskCompany.ApiVendorID = Convert.ToString(x.apiVendorID);
                    autoTaskCompany.AssetValue = Convert.ToString(x.assetValue);
                    autoTaskCompany.BillToCompanyLocationID = Convert.ToString(x.billToCompanyLocationID);
                    autoTaskCompany.BillToAdditionalAddressInformation = x.billToAdditionalAddressInformation;
                    autoTaskCompany.BillingAddress1 = x.billingAddress1;
                    autoTaskCompany.BillingAddress2 = x.billingAddress2;
                    autoTaskCompany.BillToAddressToUse = x.billToAddressToUse;
                    autoTaskCompany.BillToAttention = x.billToAttention;
                    autoTaskCompany.BillToCity = x.billToCity;
                    autoTaskCompany.BillToCountryID = x.billToCountryID;
                    autoTaskCompany.BillToState = x.billToState;
                    autoTaskCompany.BillToZipCode = x.billToZipCode;
                    autoTaskCompany.City = x.city;
                    autoTaskCompany.Classification = x.classification;
                    autoTaskCompany.CompanyName = x.companyName;
                    autoTaskCompany.CompanyNumber = x.companyNumber;
                    autoTaskCompany.CompanyType = x.companyType;
                    autoTaskCompany.CompetitorID = Convert.ToString(x.competitorID);
                    autoTaskCompany.CountryID = x.countryID;
                    autoTaskCompany.CreateDate = x.createDate;
                    autoTaskCompany.CreatedByResourceID = x.createdByResourceID;
                    autoTaskCompany.CurrencyID = x.currencyID;
                    autoTaskCompany.Fax = x.fax;
                    autoTaskCompany.ImpersonatorCreatorResourceID = Convert.ToString(x.impersonatorCreatorResourceID);
                    autoTaskCompany.InvoiceEmailMessageID = x.invoiceEmailMessageID;
                    autoTaskCompany.InvoiceMethod = x.invoiceMethod;
                    autoTaskCompany.InvoiceNonContractItemsToParentCompany = Convert.ToString(x.invoiceNonContractItemsToParentCompany);
                    autoTaskCompany.InvoiceTemplateID = x.invoiceTemplateID;
                    autoTaskCompany.IsActive = Convert.ToString(x.isActive);
                    autoTaskCompany.IsClientPortalActive = Convert.ToString(x.isClientPortalActive);
                    autoTaskCompany.IsEnabledForComanaged = Convert.ToString(x.isEnabledForComanaged);
                    autoTaskCompany.IsTaskFireActive = Convert.ToString(x.isTaskFireActive);
                    autoTaskCompany.IsTaxExempt = Convert.ToString(x.isTaxExempt);
                    autoTaskCompany.LastActivityDate = x.lastActivityDate;
                    autoTaskCompany.LastTrackedModifiedDateTime = x.lastTrackedModifiedDateTime;
                    autoTaskCompany.MarketSegmentID = Convert.ToString(x.marketSegmentID);
                    autoTaskCompany.OwnerResourceID = x.ownerResourceID;
                    autoTaskCompany.ParentCompanyID = x.parentCompanyID;
                    autoTaskCompany.Phone = x.phone;
                    autoTaskCompany.PostalCode = x.postalCode;
                    autoTaskCompany.QuoteEmailMessageID = x.quoteEmailMessageID;
                    autoTaskCompany.QuoteTemplateID = x.quoteTemplateID;
                    autoTaskCompany.SicCode = x.sicCode;
                    autoTaskCompany.State = x.state;
                    autoTaskCompany.StockMarket = x.stockMarket;
                    autoTaskCompany.StockSymbol = x.stockSymbol;
                    autoTaskCompany.SurveyCompanyRating = Convert.ToString(x.surveyCompanyRating);
                    autoTaskCompany.TaxID = x.taxID.ToString();
                    autoTaskCompany.TaxRegionID = Convert.ToString(x.taxRegionID);
                    autoTaskCompany.TerritoryID = Convert.ToString(x.territoryID);
                    autoTaskCompany.WebAddress = x.webAddress;
                    pRTGAutotaskEntities.AutoTaskCompanies.Add(autoTaskCompany);
                    pRTGAutotaskEntities.SaveChanges();
                }
            }
            if(autoTaskCompaniesModel.pageDetails.nextPageUrl != null)
            {
                string API = autoTaskCompaniesModel.pageDetails.nextPageUrl.ToString();
                AllCompaniesExecution(API);
            }
        }

    }
}
