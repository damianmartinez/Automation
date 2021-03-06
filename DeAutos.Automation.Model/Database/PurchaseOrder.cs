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
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.PaymentTickets = new HashSet<PaymentTicket>();
            this.PaymentTicketGatewayRequests = new HashSet<PaymentTicketGatewayRequest>();
            this.AppliedDiscountCoupons = new HashSet<AppliedDiscountCoupon>();
            this.CreditPacks = new HashSet<CreditPack>();
            this.PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            this.Suscriptions = new HashSet<Suscription>();
        }
    
        public int Id { get; set; }
        public string PurchaseOrderState { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<bool> Invoiced { get; set; }
        public int idUser { get; set; }
        public Nullable<int> PublicationId { get; set; }
        public Nullable<bool> Clienting { get; set; }
        public Nullable<DateTime> PaymentDate { get; set; }
        public string Discriminator { get; set; }
        public Nullable<int> idCustomCurrency { get; set; }
        public Nullable<int> BackOfficePaymentUserId { get; set; }
        public Nullable<DateTime> InvoicedDate { get; set; }
    
        public virtual ICollection<PaymentTicket> PaymentTickets { get; set; }
        public virtual ICollection<PaymentTicketGatewayRequest> PaymentTicketGatewayRequests { get; set; }
        public virtual ICollection<AppliedDiscountCoupon> AppliedDiscountCoupons { get; set; }
        public virtual ICollection<CreditPack> CreditPacks { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual ICollection<Suscription> Suscriptions { get; set; }
    }
}
