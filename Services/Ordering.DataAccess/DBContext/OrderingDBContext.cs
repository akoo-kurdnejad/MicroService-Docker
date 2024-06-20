using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Aggregates.OrderAggregate;

namespace Ordering.DataAccess.EF.DBContext;

public partial class OrderingDBContext : DbContext
{
    public OrderingDBContext()
    {
        
    }
    public OrderingDBContext(DbContextOptions<OrderingDBContext> options) : base(options)
    {
    }

    #region DbSet

    public virtual DbSet<Order> Orders { get; set; }

    #endregion DbSet

    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    //foreach (var entry in ChangeTracker.Entries<BaseEntity>())
    //    //{
    //    //    switch (entry.State)
    //    //    {
    //    //        case EntityState.Added:
    //    //            entry.Entity.CreateDate = DateTime.Now;
    //    //            entry.Entity.CreatedBy = "mohammad";
    //    //            break;
    //    //        case EntityState.Modified:
    //    //            entry.Entity.ModifiedDate = DateTime.Now;
    //    //            entry.Entity.LastModifiedBy = "mohammad";
    //    //            break;
    //    //    }
    //    //}

    //    return base.SaveChangesAsync(cancellationToken);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("Orders");
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
