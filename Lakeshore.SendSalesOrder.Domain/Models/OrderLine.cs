using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderLine : Entity
{
    public OrderLine()
    {
        //for EF
    }
    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public int OrderShippingSequenceNo { get; private set; }

    public int LineNo { get; private set; }

    public string ItemNo { get; private set; } = null!;

    public string DescX { get; private set; } = null!;

    public int Qty { get; private set; }

    public decimal ListPrice { get; private set; }

    public decimal SoldPrice { get; private set; }

    public decimal TaxAmount { get; private set; }

    public string TaxCategory { get; private set; } = null!;

    public string? DiscountType { get; private set; }

    public string? DiscountReference { get; private set; }

    public string? GiftCardItemFlag { get; private set; }

    public string? NonShippableItemFlag { get; private set; }

    public string? SaleItemFlag { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public string? GiftCardNumber { get; private set; }

    public bool? BartCreate { get; private set; }

    public string? GiftCardMessage { get; private set; }

    public string? GiftCardSenderEmail { get; private set; }

    public string? GiftCardRecipientEmail { get; private set; }

    public string? LoyaltyDiscountedFlag { get; private set; }

    public string? RegistryId { get; private set; }

    public string? ItemCustomDropdown1 { get; private set; }

    public string? ItemCustomDropdown2 { get; private set; }

    public string? RegistryName { get; private set; }

    public string? RegistryFirstName { get; private set; }

    public string? RegistryLastName { get; private set; }

    public string? TaxHolidayItemFlag { get; private set; }

    public string? RegistryLineItemId { get; private set; }

    public DateTime? BackorderDate { get; private set; }

    public virtual OrderShipping Order { get; private set; } = null!;
}
