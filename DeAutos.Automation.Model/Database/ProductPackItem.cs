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
    public partial class ProductPackItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int idProduct { get; set; }
        public Nullable<int> ProductPack_id { get; set; }
        public Nullable<int> ProductOfferingId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual ProductOffering ProductOffering { get; set; }
    }
}
