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
    public partial class AuditCatalog
    {
        public long P_id { get; set; }
        public long F_T_Sec_user_id { get; set; }
        public long F_T_BasicOperations_P_id { get; set; }
        public int F_VehicleModel_id { get; set; }
        public string A_ContentData { get; set; }
        public DateTime A_ExecutionDate { get; set; }
    
        public virtual SecurityUser SecurityUser { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual BasicOperation BasicOperation { get; set; }
    }
}
