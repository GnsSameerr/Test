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
    
    public partial class GroupCompanyLocationMapping
    {
        public int Id { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CompanyLocationId { get; set; }
        public Nullable<System.DateTime> DateMapped { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
