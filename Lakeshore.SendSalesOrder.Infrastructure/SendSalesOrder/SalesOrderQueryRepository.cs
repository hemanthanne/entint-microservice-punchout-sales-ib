using Lakeshore.SendSalesOrder.Application.SendSalesOrder;
using Lakeshore.SendSalesOrder.Domain.Models;
using Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lakeshore.SendSalesOrder.Infrastructure.SendSalesOrder;

public class SalesOrderQueryRepository : ISalesOrderQueryRepository
{
    private readonly SalesOrderDbContext _context;

    public SalesOrderQueryRepository(SalesOrderDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<OrderHeader>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await _context.OrderHeaders
            .Include(x => x.OrderShippings.Where(y => y.ExportStatus == "R" && y.ExportProcessedDatetime == null))
            .Include("OrderShippings.OrderComments")
            .Include("OrderShippings.OrderLines")
            .Include("OrderShippings.OrderPayments")
            .Include("OrderShippings.OrderPromotions")
            .ToListAsync(cancellationToken);

        return orders;
    }
}
