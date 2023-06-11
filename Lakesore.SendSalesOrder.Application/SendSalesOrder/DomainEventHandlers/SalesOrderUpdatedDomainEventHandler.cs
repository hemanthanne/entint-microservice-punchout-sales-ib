using Lakeshore.SendSalesOrder.Domain.Har.Events;
using Lakeshore.Kafka.Client.Interfaces;
using MediatR;
using System.Text.Json;
using Confluent.Kafka;


namespace Lakeshore.SendSalesOrder.Application.Har.DomainEventHandlers;

public class SalesOrderUpdatedDomainEventHandler : INotificationHandler<SalesOrderUpdatedDomainEvent>
{
    private readonly IKafkaProducerClient _kafkaProducerClient;

    public SalesOrderUpdatedDomainEventHandler(IKafkaProducerClient kafkaProducerClient)
    {
        _kafkaProducerClient = kafkaProducerClient ?? throw new ArgumentNullException(nameof(kafkaProducerClient));
    }
    public async Task Handle(SalesOrderUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        string strJson = JsonSerializer.Serialize(notification.orderExtract);
        await _kafkaProducerClient.Producer.ProduceAsync(_kafkaProducerClient.Topic, new Message<Null, string> { Value = strJson }, cancellationToken);
    }
}
