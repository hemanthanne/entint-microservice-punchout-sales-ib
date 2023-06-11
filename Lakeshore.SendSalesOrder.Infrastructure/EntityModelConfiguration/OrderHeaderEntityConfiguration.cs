using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderHeaderEntityConfiguration : IEntityTypeConfiguration<OrderHeader>
{
    public void Configure(EntityTypeBuilder<OrderHeader> entity)
    {
        entity.HasKey(e => e.OrderNo);
        entity.ToTable("order_header");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.Address1)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("address_1");
        entity.Property(e => e.Address2)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("address_2");
        entity.Property(e => e.ApprovedByName)
            .HasMaxLength(80)
            .IsUnicode(false)
            .HasColumnName("approved_by_name");
        entity.Property(e => e.City)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("city");
        entity.Property(e => e.CompanyName)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("company_name");
        entity.Property(e => e.Country)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("country");
        entity.Property(e => e.CreatedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("created_datetime");
        entity.Property(e => e.CsDecision)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("cs_decision");
        entity.Property(e => e.CustomOrderDropdown)
            .HasMaxLength(1000)
            .IsUnicode(false)
            .HasColumnName("custom_order_dropdown");
        entity.Property(e => e.CustomerNo).HasColumnName("customer_no");
        entity.Property(e => e.Email)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("email");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
            .HasColumnName("entry_datetime");
        entity.Property(e => e.Fax)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("fax");
        entity.Property(e => e.FromApp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("from_app");
        entity.Property(e => e.GuestOrder)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("guest_order");
        entity.Property(e => e.LakeshoreDecision)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("lakeshore_decision");
        entity.Property(e => e.LakeshoreHoldCode)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("lakeshore_hold_code");
        entity.Property(e => e.LoyaltyClubNumber)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("loyalty_club_number");
        entity.Property(e => e.MerchantIdSource)
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("merchant_id_source");
        entity.Property(e => e.Name)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("name");
        entity.Property(e => e.OrderShipType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_ship_type");
        entity.Property(e => e.OrderType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_type");
        entity.Property(e => e.Phone)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("phone");
        entity.Property(e => e.Po)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("po");
        entity.Property(e => e.ProviderNumber)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("provider_number");
        entity.Property(e => e.QueueNo).HasColumnName("queue_no");
        entity.Property(e => e.SessionmUserId)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("sessionm_user_id");
        entity.Property(e => e.ShoppingAs)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("shopping_as");
        entity.Property(e => e.SiteNumber)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("site_number");
        entity.Property(e => e.StateX)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("state_x");
        entity.Property(e => e.TaxExemptNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("tax_exempt_no");
        entity.Property(e => e.TaxExemptOrganization)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("tax_exempt_organization");
        entity.Property(e => e.WebEnv)
            .HasMaxLength(250)
            .IsUnicode(false)
            .HasColumnName("web_env");
        entity.Property(e => e.WebQuoteId)
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("web_quote_id");
        entity.Property(e => e.Zip)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("zip");
    }
}
