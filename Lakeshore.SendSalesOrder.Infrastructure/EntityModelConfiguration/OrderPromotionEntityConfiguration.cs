using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderPromotionEntityConfiguration : IEntityTypeConfiguration<OrderPromotion>
{
    public void Configure(EntityTypeBuilder<OrderPromotion> entity)
    {
        entity.HasKey(e => new { e.OrderNo, e.OrderShippingSequenceNo, e.SequenceNo }).HasName("pk_order_promotion");

        entity.ToTable("order_promotion");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.OrderShippingSequenceNo).HasColumnName("order_shipping_sequence_no");
        entity.Property(e => e.SequenceNo).HasColumnName("sequence_no");        
        entity.Property(e => e.CreatedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("created_datetime");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
            .HasColumnName("entry_datetime");
        entity.Property(e => e.McertNo)
            .HasColumnType("decimal(18, 0)")
            .HasColumnName("mcert_no");
        entity.Property(e => e.PromotionNo)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("promotion_no");
        entity.Property(e => e.PromotionNote)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("promotion_note");
        entity.Property(e => e.PromotionSubtype)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("promotion_subtype");

        entity.HasOne(d => d.Order).WithMany(p => p.OrderPromotions)
            .HasForeignKey(d => new { d.OrderNo, d.OrderShippingSequenceNo })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_order_promotion_shipping_order_no_sequence_no");
    }
}
