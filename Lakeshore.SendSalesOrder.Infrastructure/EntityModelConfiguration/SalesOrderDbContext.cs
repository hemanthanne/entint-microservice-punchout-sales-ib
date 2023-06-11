using Lakeshore.SendSalesOrder.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Lakeshore.SendSalesOrder.Infrastructure.EntityModelConfiguration;

public class SalesOrderDbContext : DbContext
{
    public SalesOrderDbContext(DbContextOptions<SalesOrderDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    public virtual DbSet<OrderHeader> OrderComments { get; set; }

    public virtual DbSet<OrderHeader> OrderHeaders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderPayment> OrderPayments { get; set; }

    public virtual DbSet<OrderPromotion> OrderPromotions { get; set; }

    public virtual DbSet<OrderShipping> OrderShippings { get; set; }

}
