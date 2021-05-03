using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Model.AutoTaskLocation
{ 

    public class AutoTaskCompanyLocationModel
    {
        public Item[] items { get; set; }
        public Pagedetails pageDetails { get; set; }
    }

    public class Pagedetails
    {
        public int count { get; set; }
        public int requestCount { get; set; }
        public object prevPageUrl { get; set; }
        public string nextPageUrl { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string alternatePhone1 { get; set; }
        public string alternatePhone2 { get; set; }
        public string city { get; set; }
        public int? companyID { get; set; }
        public int? countryID { get; set; }
        public string description { get; set; }
        public string fax { get; set; }
        public bool isActive { get; set; }
        public bool isPrimary { get; set; }
        public object isTaxExempt { get; set; }
        public bool overrideCompanyTaxSettings { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string postalCode { get; set; }
        public double? roundtripDistance { get; set; }
        public string state { get; set; }
        public object taxRegionID { get; set; }
    }

    //Comment for checking GIT  22

}
