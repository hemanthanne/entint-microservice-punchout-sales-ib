using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;


namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderShippingEntityConfiguration : IEntityTypeConfiguration<OrderShipping>
{
    public void Configure(EntityTypeBuilder<OrderShipping> entity)
    {
        entity.HasKey(e => new { e.OrderNo, e.OrderShippingSequenceNo });

        entity.ToTable("order_shipping");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.OrderShippingSequenceNo).HasColumnName("order_shipping_sequence_no");
        entity.Property(e => e.Address1)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("address_1");
        entity.Property(e => e.Address2)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("address_2");
        entity.Property(e => e.AddressType)
            .HasMaxLength(15)
            .IsUnicode(false)
            .HasColumnName("address_type");
        entity.Property(e => e.Attention1)
            .HasMaxLength(80)
            .IsUnicode(false)
            .HasColumnName("attention1");
        entity.Property(e => e.Attention2)
            .HasMaxLength(80)
            .IsUnicode(false)
            .HasColumnName("attention2");
        entity.Property(e => e.Attention3)
            .HasMaxLength(80)
            .IsUnicode(false)
            .HasColumnName("attention3");
        entity.Property(e => e.AutoReleaseFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("auto_release_flag");
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
        entity.Property(e => e.CustomerNo).HasColumnName("customer_no");
        entity.Property(e => e.DiscountAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("discount_amount");
        entity.Property(e => e.Email)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("email");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
            .HasColumnName("entry_datetime");
        entity.Property(e => e.ExportMessage)
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasColumnName("export_message");
        entity.Property(e => e.ExportProcessedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("export_processed_datetime");
        entity.Property(e => e.ExportStatus)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("export_status");
        entity.Property(e => e.ExpressShippingFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("express_shipping_flag");
        entity.Property(e => e.FreeFreightFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("free_freight_flag");
        entity.Property(e => e.FreightAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("freight_amount");
        entity.Property(e => e.FreightTaxAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("freight_tax_amount");
        entity.Property(e => e.GsaOrderFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("gsa_order_flag");
        entity.Property(e => e.HoldCode)
            .HasMaxLength(4)
            .IsUnicode(false)
            .HasColumnName("hold_code");
        entity.Property(e => e.Name)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("name");
        entity.Property(e => e.Phone)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("phone");
        entity.Property(e => e.PossibleFraudFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("possible_fraud_flag");
        entity.Property(e => e.ShipDate)
            .HasColumnType("datetime")
            .HasColumnName("ship_date");
        entity.Property(e => e.ShipVia)
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("ship_via");
        entity.Property(e => e.StateX)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("state_x");
        entity.Property(e => e.Subtotal)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("subtotal");
        entity.Property(e => e.TaxAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("tax_amount");
        entity.Property(e => e.TaxExemptFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("tax_exempt_flag");
        entity.Property(e => e.Under13)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("under_13");
        entity.Property(e => e.Zip)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("zip");

        entity.HasOne(d => d.OrderNoNavigation).WithMany(p => p.OrderShippings)
            .HasForeignKey(d => d.OrderNo)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_order_shipping_header_order_no");
    }
}
