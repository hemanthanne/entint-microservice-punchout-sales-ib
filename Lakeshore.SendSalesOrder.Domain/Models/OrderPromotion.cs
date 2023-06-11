using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderPromotion : Entity
{
    public OrderPromotion()
    {
        //for EF
    }
    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public int SequenceNo { get; private set; }

    public int OrderShippingSequenceNo { get; private set; }
        
    public string? PromotionSubtype { get; private set; }

    public string PromotionNo { get; private set; } = null!;

    public string? PromotionNote { get; private set; }

    public decimal? McertNo { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public virtual OrderShipping Order { get; private set; } = null!;
}
