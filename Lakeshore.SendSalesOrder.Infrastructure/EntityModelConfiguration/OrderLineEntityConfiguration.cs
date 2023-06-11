using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderLineEntityConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> entity)
    {
        entity.HasKey(e => new { e.OrderNo, e.OrderShippingSequenceNo, e.LineNo });
        entity.ToTable("order_line");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.OrderShippingSequenceNo).HasColumnName("order_shipping_sequence_no");
        entity.Property(e => e.LineNo).HasColumnName("line_no");
        entity.Property(e => e.BackorderDate)
            .HasColumnType("datetime")
            .HasColumnName("backorder_date");
        entity.Property(e => e.BartCreate).HasColumnName("bart_create");
        entity.Property(e => e.CreatedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("created_datetime");
        entity.Property(e => e.DescX)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("desc_x");
        entity.Property(e => e.DiscountReference)
            .HasMaxLength(1024)
            .IsUnicode(false)
            .HasColumnName("discount_reference");
        entity.Property(e => e.DiscountType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("discount_type");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
            .HasColumnName("entry_datetime");
        entity.Property(e => e.GiftCardItemFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("gift_card_item_flag");
        entity.Property(e => e.GiftCardMessage)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("gift_card_message");
        entity.Property(e => e.GiftCardNumber)
            .HasMaxLength(16)
            .IsUnicode(false)
            .HasColumnName("gift_card_number");
        entity.Property(e => e.GiftCardRecipientEmail)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("gift_card_recipient_email");
        entity.Property(e => e.GiftCardSenderEmail)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("gift_card_sender_email");
        entity.Property(e => e.ItemCustomDropdown1)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("item_custom_dropdown_1");
        entity.Property(e => e.ItemCustomDropdown2)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("item_custom_dropdown_2");
        entity.Property(e => e.ItemNo)
            .HasMaxLength(18)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("item_no");
        entity.Property(e => e.ListPrice)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("list_price");
        entity.Property(e => e.LoyaltyDiscountedFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("loyalty_discounted_flag");
        entity.Property(e => e.NonShippableItemFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("non_shippable_item_flag");
        entity.Property(e => e.Qty).HasColumnName("qty");
        entity.Property(e => e.RegistryFirstName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("registry_first_name");
        entity.Property(e => e.RegistryId)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("registry_id");
        entity.Property(e => e.RegistryLastName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("registry_last_name");
        entity.Property(e => e.RegistryLineItemId)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("registry_line_item_id");
        entity.Property(e => e.RegistryName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("registry_name");
        entity.Property(e => e.SaleItemFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("sale_item_flag");
        entity.Property(e => e.SoldPrice)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("sold_price");
        entity.Property(e => e.TaxAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("tax_amount");
        entity.Property(e => e.TaxCategory)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("tax_category");
        entity.Property(e => e.TaxHolidayItemFlag)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("tax_holiday_item_flag");

        entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
            .HasForeignKey(d => new { d.OrderNo, d.OrderShippingSequenceNo })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_order_line_shipping_order_no_sequence_no");
    }
}
