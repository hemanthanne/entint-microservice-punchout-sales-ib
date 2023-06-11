using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderShipping : Entity
{
    public OrderShipping()
    {
        //for EF
    }
    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public int OrderShippingSequenceNo { get; private set; }

    public int? CustomerNo { get; private set; }

    public string? CompanyName { get; private set; }

    public string? Name { get; private set; }

    public string? Address1 { get; private set; }

    public string? Address2 { get; private set; }

    public string? City { get; private set; }

    public string? StateX { get; private set; }

    public string? Zip { get; private set; }

    public string? Country { get; private set; }

    public decimal Subtotal { get; private set; }

    public decimal TaxAmount { get; private set; }

    public decimal? FreightAmount { get; private set; }

    public decimal FreightTaxAmount { get; private set; }

    public string? ShipVia { get; private set; }

    public string? ExpressShippingFlag { get; private set; }

    public string? TaxExemptFlag { get; private set; }

    public string? FreeFreightFlag { get; private set; }

    public string? GsaOrderFlag { get; private set; }

    public string? AutoReleaseFlag { get; private set; }

    public string? PossibleFraudFlag { get; private set; }

    public string? HoldCode { get; private set; }

    public string ExportStatus { get; private set; } = null!;

    public DateTime? ExportProcessedDatetime { get; private set; }

    public string? ExportMessage { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public string? Phone { get; private set; }

    public string? Attention1 { get; private set; }

    public string? Attention2 { get; private set; }

    public string? Attention3 { get; private set; }

    public string? Under13 { get; private set; }

    public string? AddressType { get; private set; }

    public string? Email { get; private set; }

    public DateTime? ShipDate { get; private set; }

    public decimal? DiscountAmount { get; private set; }

    public virtual ICollection<OrderComment> OrderComments { get; } = new List<OrderComment>();

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public virtual OrderHeader OrderNoNavigation { get; private set; } = null!;

    public virtual ICollection<OrderPayment> OrderPayments { get; } = new List<OrderPayment>();

    public virtual ICollection<OrderPromotion> OrderPromotions { get; } = new List<OrderPromotion>();

    public void StatusUpdate(string exportStatus, DateTime? exportProcessedDatetime)
    {
        this.ExportStatus = exportStatus;
        this.ExportProcessedDatetime = exportProcessedDatetime;
    }
}
