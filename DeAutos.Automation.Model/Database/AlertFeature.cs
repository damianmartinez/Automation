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
    public partial class AlertFeature
    {
        public int P_ID_Alert_Feature { get; set; }
        public int F_IDAlert { get; set; }
        public string A_Feature { get; set; }
        public string A_Value { get; set; }
    
        public virtual Alert Alert { get; set; }
    }
}