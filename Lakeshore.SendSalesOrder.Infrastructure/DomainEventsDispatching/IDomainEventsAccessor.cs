

using Lakeshore.SendSalesOrder.Domain;

namespace Lakeshore.SendSalesOrder.Infrastructure.DomainEventsDispatching;

public interface IDomainEventsAccessor
{
    IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

    void ClearAllDomainEvents();
}