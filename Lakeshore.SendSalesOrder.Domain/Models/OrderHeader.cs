using Lakeshore.SendSalesOrder.Domain.Har.Events;
using Lakeshore.SendSalesOrder.Dto.SendSalesOrder;
using System;
using System.Collections.Generic;

namespace Lakeshore.SendSalesOrder.Domain.Models;

public class OrderHeader : Entity
{
    public OrderHeader()
    {
        //for EF
    }
    public string OrderNo { get; private set; } = null!;

    public DateTime EntryDatetime { get; private set; }

    public string OrderType { get; private set; } = null!;

    public int? CustomerNo { get; private set; }

    public string CompanyName { get; private set; } = null!;

    public string? Name { get; private set; }

    public string? Address1 { get; private set; }

    public string? Address2 { get; private set; }

    public string? City { get; private set; }

    public string? StateX { get; private set; }

    public string? Zip { get; private set; }

    public string? Country { get; private set; }

    public string? Phone { get; private set; }

    public string? Fax { get; private set; }

    public string? Email { get; private set; }

    public string? Po { get; private set; }

    public string? TaxExemptNo { get; private set; }

    public string? ShoppingAs { get; private set; }

    public DateTime CreatedDatetime { get; private set; }

    public string? WebEnv { get; private set; }

    public string? CsDecision { get; private set; }

    public string? LakeshoreDecision { get; private set; }

    public string? LakeshoreHoldCode { get; private set; }

    public string? OrderShipType { get; private set; }

    public string? GuestOrder { get; private set; }

    public string? MerchantIdSource { get; private set; }

    public string? LoyaltyClubNumber { get; private set; }

    public string? ApprovedByName { get; private set; }

    public string? SiteNumber { get; private set; }

    public string? CustomOrderDropdown { get; private set; }

    public string? ProviderNumber { get; private set; }

    public string? WebQuoteId { get; private set; }

    public string? SessionmUserId { get; private set; }

    public int? QueueNo { get; private set; }

    public string? FromApp { get; private set; }

    public string? TaxExemptOrganization { get; private set; }

    public virtual ICollection<OrderShipping> OrderShippings { get; private set;} = new List<OrderShipping>();

    public void StatusUpdate(int orderShippingSequenceNo, string exportStatus, 
        DateTime? exportProcessedDatetime, SalesOrderDto? salesOrderDto)
    {
        var orderShipping = OrderShippings
            .FirstOrDefault(x => x.OrderNo == this.OrderNo 
            && x.OrderShippingSequenceNo == orderShippingSequenceNo);

        if(orderShipping != null)
        {
            orderShipping.StatusUpdate(exportStatus, exportProcessedDatetime);
            if(salesOrderDto != null)
                this.AddDomainEvent(new SalesOrderUpdatedDomainEvent(salesOrderDto));
        }
    }
}
