using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Application.SendSalesOrder;

public interface ISalesOrderQueryRepository
{
    Task<List<OrderHeader>> GetAll(CancellationToken cancellationToken);
}
