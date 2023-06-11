using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;
using Lakeshore.SendSalesOrder.Infrastructure.SendSalesOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Lakeshore.SendSalesOrder.Infrastructure.DomainEventsDispatching;
using Lakeshore.SendSalesOrder.Infrastructure;
using Lakeshore.SendSalesOrder.Domain;
using Lakeshore.SendSalesOrder.Application.SendSalesOrder.Command.UpdateOrder;
using Lakeshore.SendSalesOrder.Domain.SendSalesOrder;
using Lakeshore.SendSalesOrder.Application.SendSalesOrder;
using Lakeshore.Kafka.Client;
using Lakeshore.Kafka.Client.Interfaces;
using Lakeshore.Kafka.Client.Implementation;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ExtractSalesOrderCommandHandler).Assembly));
builder.Services.AddTransient<ISalesOrderCommandRepository, SalesOrderCommandRepository> ();
builder.Services.AddTransient<ISalesOrderQueryRepository, SalesOrderQueryRepository>();
builder.Services.AddTransient<IDomainEventsAccessor,DomainEventsAccessor>();
builder.Services.AddTransient<ICommandUnitOfWork,CommandUnitOfWork>();

builder.Services.Configure<ProducerSettings>(configuration.GetSection("KafkaSettings:ProducerSettings"));

var logger = new LoggerConfiguration()
    // Read from appsettings.json
    .ReadFrom.Configuration(configuration)
    // Create the actual logger
    .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = configuration.GetAWSOptions();
options.Credentials = new BasicAWSCredentials(configuration.GetSection("DynamoDb:AccessKey").Value, configuration.GetSection("DynamoDb:SecretKey").Value);
builder.Services.AddAWSService<IAmazonDynamoDB>(options);

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IKafkaProducerClient, KafkaProducerClient>();

builder.Services.AddDbContext<SalesOrderDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();
