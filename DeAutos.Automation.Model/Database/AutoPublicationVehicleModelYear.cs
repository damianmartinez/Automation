//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeAutos.Automation.Model.Database
{
    public partial class AutoPublicationVehicleModelYear
    {
        public int Id { get; set; }
        public int VehicleModel_Id { get; set; }
        public int AutoPublication_Id { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
    
        public virtual AutoPublication AutoPublication { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
    }
}
