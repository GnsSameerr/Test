//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRTGAutoTaskScheduler
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeviceConfigurationItemsMapping
    {
        public int Id { get; set; }
        public Nullable<int> DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Nullable<int> ConfigurationItemId { get; set; }
        public string ConfigurationItemTittle { get; set; }
        public Nullable<System.DateTime> DateMapped { get; set; }
        public string DateUpdated { get; set; }
        public Nullable<int> PRTGGroupID { get; set; }
        public string PRTGGroupName { get; set; }
        public Nullable<int> AutoTaskCompanyID { get; set; }
        public string AutoTaskCompanyName { get; set; }
        public Nullable<int> RootGroupID { get; set; }
    }
}