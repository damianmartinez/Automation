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
    public partial class User
    {
        public User()
        {
            this.PaymentTicketGatewayRequests = new HashSet<PaymentTicketGatewayRequest>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.ListingSponsors = new HashSet<ListingSponsor>();
            this.UserCustomerGroups = new HashSet<UserCustomerGroup>();
            this.Conversations = new HashSet<Conversation>();
            this.Messages = new HashSet<Message>();
            this.AppliedDiscountCoupons = new HashSet<AppliedDiscountCoupon>();
            this.DiscountCoupons = new HashSet<DiscountCoupon>();
            this.CreditPacks = new HashSet<CreditPack>();
            this.Publications = new HashSet<Publication>();
            this.EMailAudits = new HashSet<EMailAudit>();
            this.UserClaims = new HashSet<UserClaim>();
            this.UserLogins = new HashSet<UserLogin>();
            this.Roles = new HashSet<Role>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public Nullable<bool> EmailConfirmed { get; set; }
        public string State { get; set; }
        public Nullable<int> idBusinessDomain { get; set; }
        public Nullable<int> idPrimaryPhoneNumber { get; set; }
        public Nullable<int> idSecondaryPhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    
        public virtual ICollection<PaymentTicketGatewayRequest> PaymentTicketGatewayRequests { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ListingSponsor> ListingSponsors { get; set; }
        public virtual ICollection<UserCustomerGroup> UserCustomerGroups { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual BusinessDomain BusinessDomain { get; set; }
        public virtual ICollection<AppliedDiscountCoupon> AppliedDiscountCoupons { get; set; }
        public virtual ICollection<DiscountCoupon> DiscountCoupons { get; set; }
        public virtual ICollection<CreditPack> CreditPacks { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<EMailAudit> EMailAudits { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ClientUser ClientUser { get; set; }
        public virtual EndUser EndUser { get; set; }
        public virtual ImportUser ImportUser { get; set; }
        public virtual PhoneNumber PhoneNumber { get; set; }
        public virtual PhoneNumber PhoneNumber1 { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}