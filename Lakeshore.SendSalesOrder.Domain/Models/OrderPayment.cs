using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderPayment : Entity
{
    public OrderPayment()
    {
        //for EF
    }
    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public int OrderShippingSequenceNo { get; private set; }

    public int SequenceNo { get; private set; }

    public decimal Amount { get; private set; }

    public string PaymentType { get; private set; } = null!;

    public string? PaymentSubtype { get; private set; }

    public string ReferenceNo { get; private set; } = null!;

    public string? Name { get; private set; }

    public string? ExpirationDate { get; private set; }

    public string? Token { get; private set; }

    public string? AuthCode { get; private set; }

    public string? TroutId { get; private set; }

    public string? PaymentNote { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public string? GsaCc { get; private set; }

    public bool? BartCreate { get; private set; }

    public bool? Deleted { get; private set; }

    public string? CsAvsCode { get; private set; }

    public string? TransactionId { get; private set; }

    public string? PaymentProvider { get; private set; }

    public decimal? TaxAmount { get; private set; }

    public string? Requisition { get; private set; }

    public DateTime? OfferAppliedTime { get; private set; }

    public int? StackOrder { get; private set; }

    public virtual OrderShipping Order { get; private set; } = null!;
}
