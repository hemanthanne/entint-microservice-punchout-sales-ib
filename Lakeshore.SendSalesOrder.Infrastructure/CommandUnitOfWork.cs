using Lakeshore.SendSalesOrder.Infrastructure.DomainEventsDispatching;
using Lakeshore.SendSalesOrder.Domain;
using Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;
using MediatR;
using Lakeshore.Kafka.Client.Interfaces;

namespace Lakeshore.SendSalesOrder.Infrastructure;

public class CommandUnitOfWork : ICommandUnitOfWork
{

    private readonly SalesOrderDbContext _context;
    private readonly IMediator _mediator;
    private readonly IDomainEventsAccessor _domainEventsAccessor;
    private readonly IKafkaProducerClient _kafkaProducerClient;
    
    public CommandUnitOfWork(SalesOrderDbContext context, IDomainEventsAccessor domainEventsAccessor,
        IMediator mediator, IKafkaProducerClient kafkaProducerClient)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _domainEventsAccessor = domainEventsAccessor ?? throw new ArgumentNullException(nameof(domainEventsAccessor));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _kafkaProducerClient = kafkaProducerClient ?? throw new ArgumentNullException(nameof(kafkaProducerClient));       
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        var producer = _kafkaProducerClient.Producer;
        producer.InitTransactions(System.TimeSpan.FromSeconds(_kafkaProducerClient.TimeoutInSeconds));
        producer.BeginTransaction();
        try
        {
            var domainEvents = _domainEventsAccessor.GetAllDomainEvents();
            _domainEventsAccessor.ClearAllDomainEvents();
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);                
            }
            await _context.SaveChangesAsync(cancellationToken);

            producer.CommitTransaction();
        }
        catch (Exception)
        {
            producer.AbortTransaction();            
        }
    }

}
