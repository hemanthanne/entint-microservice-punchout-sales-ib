using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lakeshore.SendSalesOrder.Domain.Models;

namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class OrderPaymentEntityConfiguration : IEntityTypeConfiguration<OrderPayment>
{
    public void Configure(EntityTypeBuilder<OrderPayment> entity)
    {
        entity.HasKey(e => new { e.OrderNo, e.OrderShippingSequenceNo, e.SequenceNo });
        entity.ToTable("order_payment");

        entity.Property(e => e.OrderNo)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("order_no");
        entity.Property(e => e.OrderShippingSequenceNo).HasColumnName("order_shipping_sequence_no");
        entity.Property(e => e.SequenceNo).HasColumnName("sequence_no");
        entity.Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("amount");
        entity.Property(e => e.AuthCode)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("auth_code");
        entity.Property(e => e.BartCreate).HasColumnName("bart_create");
        entity.Property(e => e.CreatedDatetime)
            .HasColumnType("datetime")
            .HasColumnName("created_datetime");
        entity.Property(e => e.CsAvsCode)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("cs_avs_code");
        entity.Property(e => e.Deleted).HasColumnName("deleted");
        entity.Property(e => e.EntryDatetime)
            .HasColumnType("datetime")
            .HasColumnName("entry_datetime");
        entity.Property(e => e.ExpirationDate)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("expiration_date");
        entity.Property(e => e.GsaCc)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("gsa_cc");
        entity.Property(e => e.Name)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("name");
        entity.Property(e => e.OfferAppliedTime)
            .HasColumnType("datetime")
            .HasColumnName("offer_applied_time");
        entity.Property(e => e.PaymentNote)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("payment_note");
        entity.Property(e => e.PaymentProvider)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("payment_provider");
        entity.Property(e => e.PaymentSubtype)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("payment_subtype");
        entity.Property(e => e.PaymentType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("payment_type");
        entity.Property(e => e.ReferenceNo)
            .HasMaxLength(256)
            .IsUnicode(false)
            .HasColumnName("reference_no");
        entity.Property(e => e.Requisition)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("requisition");
        entity.Property(e => e.StackOrder).HasColumnName("stack_order");
        entity.Property(e => e.TaxAmount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("tax_amount");
        entity.Property(e => e.Token)
            .IsUnicode(false)
            .HasColumnName("token");
        entity.Property(e => e.TransactionId)
            .HasMaxLength(128)
            .IsUnicode(false)
            .HasColumnName("transaction_id");
        entity.Property(e => e.TroutId)
            .HasMaxLength(50)
            .IsUnicode(false)
        .HasColumnName("trout_id");

        entity.HasOne(d => d.Order).WithMany(p => p.OrderPayments)
            .HasForeignKey(d => new { d.OrderNo, d.OrderShippingSequenceNo })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_order_payment_shipping_order_no_sequence_no");
    }
}
