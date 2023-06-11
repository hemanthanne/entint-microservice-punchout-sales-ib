
namespace Lakeshore.SendSalesOrder.Dto.SendSalesOrder;

public class SalesOrderDto
{
    public ASalesOrder A_SalesOrder { get; set; } = new ASalesOrder();
}

public class ASalesOrder
{
    public ASalesOrderType? A_SalesOrderType { get; set; }
}

public class ASalesOrderType
{
    public string SalesOrder { get; set; } = string.Empty;
    public string? SalesOrderType { get; set; }
    public int SalesOrganization { get; set; }
    public int DistributionChannel { get; set; }
    public int OrganizationDivision { get; set; }
    public string? CustomerPurchaseOrderType { get; set; }
    public int? SoldToParty { get; set; }
    public string? CustomerType { get; set; }
    public string? Coupon { get; set; }
    public string LoyaltyId { get; set; } = string.Empty;
    public DateTime? MustShipDate { get; set; }
    public string? ShippingCondition { get; set; }
    public DateTime CustomerPurchaseOrderDate { get; set; }
    public string? PurchaseOrderByCustomer { get; set; }
    public string GuestOrder { get; set; } = string.Empty;
    public string FromApp { get; set; } = string.Empty;
    public string MerchantIdSource { get; set; } = string.Empty;
    public string RegistryGiftFrom { get; set; } = string.Empty;
    public string SFContractKey { get; set; } = string.Empty;
    public string SFContractID { get; set; } = string.Empty;
    public string SFDeviceID { get; set; } = string.Empty;
    public string? OrderNumber { get; set; }
    public string? OrderGSA { get; set; }
    public ToText to_Text { get; set; } = new ToText();
    public ToPricingElement to_PricingElement { get; set; } = new ToPricingElement();
    public ToItem to_Item { get; set; } = new ToItem();
    public Payment Payment { get; set; } = new Payment();
    public ToHeaderPartnerAddr to_HeaderPartnerAddr { get; set; } = new ToHeaderPartnerAddr();
}

public class ToText
{
    public ASalesOrderTextType? A_SalesOrderTextType { get; set; }
    public List<ASalesOrderItemTextType> A_SalesOrderItemTextType { get; set; } = new List<ASalesOrderItemTextType>();
}
public class ASalesOrderTextType
{
    public string? LongText { get; set; }
    public string SalesOrder { get; set; } = string.Empty;
    public string? Language { get; set; }
    public string? LongTextID { get; set; }
}
public class ASalesOrderItemTextType
{
    public string SalesOrder { get; set; } = string.Empty;
    public int SalesOrderItem { get; set; }
    public string? LongText { get; set; }
    public string? Language { get; set; }
    public string? LongTextID { get; set; }
}

public class ToPricingElement
{
    public List<ASalesOrderHeaderPrElement> A_SalesOrderHeaderPrElement { get; set; } = new List<ASalesOrderHeaderPrElement>();
    public ASalesOrderItemPrElementType A_SalesOrderItemPrElementType { get; set; } = new ASalesOrderItemPrElementType();
}
public class ASalesOrderHeaderPrElement
{
    public string? ConditionType { get; set; }
    public decimal? ShipAmt { get; set; }
    public int ConditionQuantity { get; set; }
    public int PricingProcedureStep { get; set; }
    public int PricingProcedureCounter { get; set; }
    public decimal? DiscountAmt { get; set; }
}
public class ASalesOrderItemPrElementType
{
    public string SalesOrder { get; set; } = string.Empty;
    public int SalesOrderItem { get; set; }
    public string? ConditionType { get; set; }
    public int ConditionQuantity { get; set; }
    public int PricingProcedureStep { get; set; }
    public int PricingProcedureCounter { get; set; }
    public decimal SoldPrice { get; set; }
    public string? Sale { get; set; }
}

public class ToItem
{
    public List<ASalesOrderItemType> A_SalesOrderItemType { get; set; } = new List<ASalesOrderItemType>();
}
public class ASalesOrderItemType
{
    public string? LineSeq { get; set; }
    public int SalesOrderItem { get; set; }
    public string? SalesOrder { get; set; }
    public string ContractID { get; set; } = string.Empty;
    public string? Material { get; set; }
    public string? SalesOrderItemText { get; set; }
    public int RequestedQuantity { get; set; }
    public string RegistryID { get; set; } = string.Empty;
    public string RegistryLineItemId { get; set; } = string.Empty;
    public ToPricingElement to_PricingElement { get; set; } = new ToPricingElement();
    public ToText to_Text { get; set; } = new ToText();
}

public class Payment
{
    public List<PaymentType> PaymentType { get; set; } = new List<PaymentType>();
}
public class PaymentType
{
    public string? Method { get; set; }
    public string PaymentProvider { get; set; } = string.Empty;
    public string CardType { get; set; } = string.Empty;
    public string CreditCardToken { get; set; } = string.Empty;
    public string CreditCardNumber { get; set; } = string.Empty;
    public string ExpDate { get; set; } = string.Empty;
    public string Po { get; set; } = string.Empty;
    public string NameOnCard { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string GiftCardNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string TroutId { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public string GsaCc { get; set; } = string.Empty;
    public string TransactionId { get; set; } = string.Empty;
    public string PoRequired { get; set; } = string.Empty;
    public string PoHardcopyRequired { get; set; } = string.Empty;
    public string UserOfferId { get; set; } = string.Empty;
    public string OfferDisplayName { get; set; } = string.Empty;
    public string OfferAppliedTime { get; set; } = string.Empty;
    public string StackOrder { get; set; } = string.Empty;
    public string ContractID { get; set; } = string.Empty;
}

public class ToHeaderPartnerAddr
{
    public List<PartnerAddress> PartnerAddresses { get; set; } = new List<PartnerAddress>();
}
public class PartnerAddress
{
    public string? PatnerFunction { get; set; }
    public int? Customer { get; set; }
    public string? CompanyName { get; set; }
    public string? Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? PhoneNumber { get; set; }
    public string AddressType { get; set; } = string.Empty;
    public string? EmailAddress { get; set; }
    public string Institution { get; set; } = string.Empty;
    public string Attention { get; set; } = string.Empty;
    public string Attention2 { get; set; } = string.Empty;
    public string Attention3 { get; set; } = string.Empty;
}

