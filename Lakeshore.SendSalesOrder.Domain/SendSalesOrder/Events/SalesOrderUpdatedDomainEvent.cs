using Lakeshore.SendSalesOrder.Dto.SendSalesOrder;
using MediatR;
using System.Text.Json;

namespace Lakeshore.SendSalesOrder.Domain.Har.Events;

public class SalesOrderUpdatedDomainEvent : IDomainEvent
{
    public SalesOrderDto orderExtract { get;}

    public Guid Id => new Guid();

    public DateTime OccurredOn => DateTime.Now;

    public string NotificationJson => JsonSerializer.Serialize(orderExtract);

    public SalesOrderUpdatedDomainEvent(SalesOrderDto orderExtract)
    {
        this.orderExtract = orderExtract;        
    }
}
