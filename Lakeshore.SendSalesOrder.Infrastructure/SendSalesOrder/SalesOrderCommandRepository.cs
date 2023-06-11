using Lakeshore.SendSalesOrder.Domain.Models;
using Lakeshore.SendSalesOrder.Domain.SendSalesOrder;
using Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lakeshore.SendSalesOrder.Infrastructure.SendSalesOrder;

public class SalesOrderCommandRepository : ISalesOrderCommandRepository
{
    private readonly SalesOrderDbContext _context;
    
    public SalesOrderCommandRepository(SalesOrderDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));        
    }

    public Task Update(OrderHeader order, CancellationToken cancellationToken)
    {
        var harStageNew = _context.OrderHeaders.Attach(order);
        harStageNew.State = EntityState.Modified;

        return Task.CompletedTask;
    }
}
