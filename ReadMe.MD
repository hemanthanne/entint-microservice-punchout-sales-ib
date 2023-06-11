## App Settings
```json
{
  "ConnectionStrings": {
    "DbConnection": <Connection String>
  },

  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "[{Timestamp:HH:mm:ss}] [{SourceContext}] [{Level}] {Message}{NewLine}{Exception}"
        }
      }
    ],
    "Enrich": [
      "FromLogContext",
      "WithMachineName",
      "WithThreadId"
    ],
    "Properties": {
      "Application": "sap-sales-order-microservice"
    }
  },
  "AllowedHosts": "*",
  "ServiceConfiguration": {
    "VendorSettings": {
      "VendorName": "SalesOrder"
    },
    "ValidationSettings": {
      "InBoundSchema": "http://localhost:8081/schemas/ids/12"
    }
  },
  "KafkaSettings": {
    "ProducerSettings": {
      "Topic": "sap_sales_order",
      "producerConfig": {
        "GroupId": "sap_sales_order_group1",
        "BootstrapServers": <server name>,
        "AutoOffsetReset": 1,
        "SecurityProtocol": "SaslSsl",
        "SaslMechanism": "Plain",
        "SaslUsername": <User name>,
        "SaslPassword": <Password>,
        "ClientId": "sap_sales_order",
        "AppName": "sap_sales_order"
      }
    }
  },
  "AWS": {
    "Region": "us-west-2",
    "Profile": "default",
    "AccessKey": <Access Key>,
    "SecretKey": <Secret Key>
  },
  "DynamoDb": {
    "AccessKey": <Access Key>,
    "SecretKey": <Secret Key>
  }
}


```


## Service Description
This microservice is reponsible to read order records from hqt-integration.sap database and create JSON file and put on SAP_Sales_Order topic.

## Revision History

| DeveloperName | Change Summary | ChangeDate | JiraCard# |
|:----|:---|:---|:---|
| Shivam Tiwari | Created base code with clean architure approach | 04/03/2023 | ITINT-347 |
