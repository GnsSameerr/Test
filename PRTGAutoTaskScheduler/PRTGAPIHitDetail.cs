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
    
    public partial class PRTGAPIHitDetail
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Device { get; set; }
        public string Group { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string DownMessage { get; set; }
        public string UpMessage { get; set; }
        public Nullable<System.DateTime> APIHitDate { get; set; }
        public string IsTicketCreated { get; set; }
        public string TicketNumber { get; set; }
    }
}