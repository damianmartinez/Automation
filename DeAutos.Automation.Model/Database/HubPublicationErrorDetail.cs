//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace DeAutos.Automation.Model.Database
{
    public partial class HubPublicationErrorDetail
    {
        public int Id { get; set; }
        public Nullable<int> HubPublicationId { get; set; }
        public string ErrorDetails { get; set; }
        public Nullable<int> IdProcess { get; set; }
        public Nullable<int> ImporterProcessLog_id { get; set; }
    
        public virtual ImporterProcessLog ImporterProcessLog { get; set; }
    }
}
