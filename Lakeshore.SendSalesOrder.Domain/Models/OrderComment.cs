using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderComment : Entity
{
    public OrderComment()
    {
        //for EF
    }

    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public int OrderShippingSequenceNo { get; private set; }

    public int LineNo { get; private set; }
        
    public int SequenceNo { get; private set; }

    public string CommentType { get; private set; } = null!;

    public string? Comment { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public virtual OrderShipping Order { get; private set; } = null!;
}
