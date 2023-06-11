using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;


namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderCommentEntityConfiguration : IEntityTypeConfiguration<OrderComment>
{
    public void Configure(EntityTypeBuilder<OrderComment> entity)
    {
        entity.HasKey(e => new { e.OrderNo, e.OrderShippingSequenceNo, e.LineNo, e.SequenceNo });
        entity.ToTable("order_comment");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.OrderShippingSequenceNo).HasColumnName("order_shipping_sequence_no");
        entity.Property(e => e.LineNo).HasColumnName("line_no");
        entity.Property(e => e.SequenceNo).HasColumnName("sequence_no");
        entity.Property(e => e.Comment)
            .HasMaxLength(4000)
            .IsUnicode(false)
            .HasColumnName("comment");
        entity.Property(e => e.CommentType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("comment_type");
        entity.Property(e => e.CreatedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("created_datetime");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
        .HasColumnName("entry_datetime");

        entity.HasOne(d => d.Order).WithMany(p => p.OrderComments)
            .HasForeignKey(d => new { d.OrderNo, d.OrderShippingSequenceNo })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_order_comment_shipping_order_no_sequence_no");
    }
}
