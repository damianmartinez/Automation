//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DeAutos.Automation.Model.Database
{
    public partial class GeoLocationItem
    {
        public GeoLocationItem()
        {
            this.ContactDatas = new HashSet<ContactData>();
            this.GeoLocationItemAutoPublications = new HashSet<GeoLocationItemAutoPublication>();
            this.ListingSponsorGeoLocationItems = new HashSet<ListingSponsorGeoLocationItem>();
            this.Locations = new HashSet<Location>();
            this.Clients = new HashSet<Client>();
            this.Clients1 = new HashSet<Client>();
            this.Sites = new HashSet<Site>();
            this.RememberDayItems = new HashSet<RememberDayItem>();
            this.RememberDayItems1 = new HashSet<RememberDayItem>();
            this.RememberDayItems2 = new HashSet<RememberDayItem>();
            this.Publications = new HashSet<Publication>();
            this.EndUsers = new HashSet<EndUser>();
            this.GeoLocationItem1 = new HashSet<GeoLocationItem>();
            this.GeoLocationRings = new HashSet<GeoLocationRing>();
            this.Discounts = new HashSet<Discount>();
            this.ZonalSupplementAreas = new HashSet<ZonalSupplementArea>();
            this.ProductOfferings = new HashSet<ProductOffering>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeoFriendlyName { get; set; }
        public int idGeoLocationItemType { get; set; }
        public Nullable<int> idGeoLocationParentItem { get; set; }
        public Nullable<int> idSapZone { get; set; }
        public string OrderShow { get; set; }
    
        public virtual SapZone SapZone { get; set; }
        public virtual ICollection<ContactData> ContactDatas { get; set; }
        public virtual ICollection<GeoLocationItemAutoPublication> GeoLocationItemAutoPublications { get; set; }
        public virtual ICollection<ListingSponsorGeoLocationItem> ListingSponsorGeoLocationItems { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Client> Clients1 { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
        public virtual ICollection<RememberDayItem> RememberDayItems { get; set; }
        public virtual ICollection<RememberDayItem> RememberDayItems1 { get; set; }
        public virtual ICollection<RememberDayItem> RememberDayItems2 { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<EndUser> EndUsers { get; set; }
        public virtual GeoLocationItemType GeoLocationItemType { get; set; }
        public virtual ICollection<GeoLocationItem> GeoLocationItem1 { get; set; }
        public virtual GeoLocationItem GeoLocationItem2 { get; set; }
        public virtual ICollection<GeoLocationRing> GeoLocationRings { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<ZonalSupplementArea> ZonalSupplementAreas { get; set; }
        public virtual ICollection<ProductOffering> ProductOfferings { get; set; }
    }
}
