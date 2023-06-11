using Lakeshore.SendSalesOrder.Domain.SendSalesOrder;
using Lakeshore.SendSalesOrder.Domain;
using MediatR;
using Lakeshore.SendSalesOrder.Dto.SendSalesOrder;

namespace Lakeshore.SendSalesOrder.Application.SendSalesOrder.Command.UpdateOrder;

public class ExtractSalesOrderCommandHandler : IRequestHandler<ExtractSalesOrderCommand, bool>
{
    private readonly ISalesOrderCommandRepository _commandRepository;
    private readonly ISalesOrderQueryRepository _queryRepository;
    private readonly ICommandUnitOfWork _unitWork;
    private readonly Serilog.ILogger _logger;

    public ExtractSalesOrderCommandHandler(ISalesOrderCommandRepository commandRepository, 
        ISalesOrderQueryRepository queryRepository,
        ICommandUnitOfWork unitWork,
        Serilog.ILogger logger)
    {
        _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        _queryRepository = queryRepository;
        _unitWork = unitWork ?? throw new ArgumentNullException(nameof(unitWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(ExtractSalesOrderCommand request, CancellationToken cancellationToken)
    {
        var orders = await _queryRepository.GetAll(cancellationToken);

        foreach (var order in orders)
        {
            foreach (var orderShipping in order.OrderShippings)
            {
                try
                {
                    var orderExtract = new SalesOrderDto();

                    #region A_SalesOrderType
                    orderExtract.A_SalesOrder.A_SalesOrderType = new ASalesOrderType
                    {
                        SalesOrderType = "ZB2B",
                        SalesOrganization = 1710,
                        DistributionChannel = 10,
                        OrganizationDivision = 10,
                        CustomerPurchaseOrderType = order.OrderType,
                        SoldToParty = order.CustomerNo,
                        CustomerType = "Both",
                        Coupon = orderShipping.OrderPromotions.FirstOrDefault()?.PromotionNo ?? "",
                        MustShipDate = orderShipping.ShipDate,
                        ShippingCondition = "01",
                        CustomerPurchaseOrderDate = order.EntryDatetime,
                        PurchaseOrderByCustomer = order.Po,
                        OrderNumber = orderShipping.OrderNo,
                        OrderGSA = orderShipping.GsaOrderFlag != null  
                        && orderShipping.GsaOrderFlag.Equals("Y",StringComparison.OrdinalIgnoreCase) ? "G1" : string.Empty
                    };
                    #endregion

                    #region ToText
                    orderExtract.A_SalesOrder.A_SalesOrderType.to_Text.A_SalesOrderTextType = new ASalesOrderTextType
                    {
                        //TODO: what if there are multiple line 0 with sequence no
                        LongText = $"Comtype: {orderShipping.OrderComments.FirstOrDefault(x => x.LineNo == 0)?.CommentType} - {orderShipping.OrderComments.FirstOrDefault(x => x.LineNo == 0)?.Comment}",
                        Language = "EN",
                        LongTextID = "ZT02"
                    };
                    #endregion

                    #region ToPricingElement
                    if (orderShipping.FreightAmount != null && orderShipping.FreightAmount > 0)
                    {
                        orderExtract.A_SalesOrder.A_SalesOrderType.to_PricingElement.
                            A_SalesOrderHeaderPrElement.Add(new ASalesOrderHeaderPrElement()
                            {
                                ConditionType = "ZF00",
                                ShipAmt = orderShipping.FreightAmount,
                                ConditionQuantity = 1,
                                PricingProcedureStep = 20,
                                PricingProcedureCounter = 1
                            });
                    }
                    if (orderShipping.DiscountAmount != null && orderShipping.DiscountAmount > 0)
                    {
                        orderExtract.A_SalesOrder.A_SalesOrderType.to_PricingElement.
                            A_SalesOrderHeaderPrElement.Add(new ASalesOrderHeaderPrElement()
                            {
                                ConditionType = "ZHD0",
                                DiscountAmt = orderShipping.DiscountAmount,
                                ConditionQuantity = 1,
                                PricingProcedureStep = 20,
                                PricingProcedureCounter = 1
                            });
                    }
                    #endregion

                    #region ToItem
                    int i = 0;
                    foreach (var orderLine in orderShipping.OrderLines)
                    {
                        var salesOrderItemType = new ASalesOrderItemType
                        {
                            LineSeq = orderLine.OrderNo,
                            SalesOrderItem = 100 + (i * 100),
                            Material = orderLine.ItemNo,
                            SalesOrderItemText = orderLine.DescX,
                            RequestedQuantity = orderLine.Qty
                        };
                        salesOrderItemType.to_PricingElement.A_SalesOrderItemPrElementType = new ASalesOrderItemPrElementType
                        {
                            SalesOrderItem = 10,
                            ConditionType = "ZPR0",
                            ConditionQuantity = 1,
                            PricingProcedureStep = 20,
                            PricingProcedureCounter = 1,
                            SoldPrice = orderLine.SoldPrice,
                            Sale = "FALSE"
                        };
                        foreach (var orderComment in orderShipping.OrderComments.Where(x => x.LineNo == orderLine.LineNo))
                        {
                            salesOrderItemType.to_Text.A_SalesOrderItemTextType.Add(new ASalesOrderItemTextType
                            {
                                SalesOrderItem = salesOrderItemType.SalesOrderItem,
                                LongText = orderComment.Comment,
                                Language = "EN",
                                LongTextID = orderComment.CommentType.Equals("PER",StringComparison.OrdinalIgnoreCase) 
                                ? "ZT26" : "ZT19"
                            });
                        }

                        orderExtract.A_SalesOrder.A_SalesOrderType.to_Item.A_SalesOrderItemType.Add(salesOrderItemType);
                        i++;
                    }
                    #endregion

                    #region Payment
                    foreach (var orderPayment in orderShipping.OrderPayments)
                    {
                        if (orderPayment.PaymentType.Equals("CREDIT CARD", StringComparison.OrdinalIgnoreCase))
                        {
                            orderExtract.A_SalesOrder.A_SalesOrderType.Payment.PaymentType.Add(new PaymentType
                            {
                                Method = "CREDIT CARD",
                                CardType = orderPayment.PaymentSubtype ?? string.Empty,
                                CreditCardToken = orderPayment.Token ?? string.Empty,
                                ExpDate = orderPayment.ExpirationDate ?? string.Empty,
                                NameOnCard = orderPayment.Name ?? string.Empty,
                                Amount = orderPayment.Amount
                            });
                        }
                        else if (orderPayment.PaymentType.Equals("GIFT CARD", StringComparison.OrdinalIgnoreCase))
                        {
                            orderExtract.A_SalesOrder.A_SalesOrderType.Payment.PaymentType.Add(new PaymentType
                            {
                                Method = "GIFT",
                                CardType = "GIFT",
                                GiftCardNumber = orderPayment.ReferenceNo,
                                Amount = orderPayment.Amount
                            });
                        }
                    }
                    #endregion

                    #region Address
                    orderExtract.A_SalesOrder.A_SalesOrderType.to_HeaderPartnerAddr
                       .PartnerAddresses.Add(new PartnerAddress
                       {
                           PatnerFunction = "SP",
                           Customer = order.CustomerNo,
                           CompanyName = order.CompanyName,
                           Name = order.Name,
                           Address1 = order.Address1,
                           Address2 = order.Address2,
                           City = order.City,
                           State = order.StateX,
                           Zip = order.Zip,
                           Country = order.Country,
                           PhoneNumber = order.Phone,
                           EmailAddress = order.Email
                       });
                    orderExtract.A_SalesOrder.A_SalesOrderType.to_HeaderPartnerAddr
                        .PartnerAddresses.Add(new PartnerAddress
                        {
                            PatnerFunction = "SH",
                            Customer = orderShipping.CustomerNo,
                            CompanyName = orderShipping.CompanyName,
                            Name = orderShipping.Name,
                            Address1 = orderShipping.Address1,
                            Address2 = orderShipping.Address2,
                            City = orderShipping.City,
                            State = orderShipping.StateX,
                            Zip = orderShipping.Zip,
                            Country = orderShipping.Country,
                            PhoneNumber = orderShipping.Phone,
                            EmailAddress = orderShipping.Email,
                            Attention = orderShipping.Attention1 ?? string.Empty,
                            Attention2 = orderShipping.Attention2 ?? string.Empty,
                            Attention3 = orderShipping.Attention3 ?? string.Empty
                        });

                    #endregion

                    order.StatusUpdate(orderShipping.OrderShippingSequenceNo, "C", DateTime.Now, orderExtract);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message, ex);
                    order.StatusUpdate(orderShipping.OrderShippingSequenceNo, "E", DateTime.Now, null);
                }
            }

            await _commandRepository.Update(order,cancellationToken);
        }

        await _unitWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
