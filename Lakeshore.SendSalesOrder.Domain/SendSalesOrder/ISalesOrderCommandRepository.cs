using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Domain.SendSalesOrder;

public interface ISalesOrderCommandRepository
{
    Task Update(OrderHeader order, CancellationToken cancellationToken);
}
