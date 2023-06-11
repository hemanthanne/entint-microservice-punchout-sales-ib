
namespace Lakeshore.SendSalesOrder.Domain;

public interface ICommandUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
