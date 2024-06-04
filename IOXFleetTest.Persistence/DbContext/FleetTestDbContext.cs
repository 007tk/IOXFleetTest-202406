using IOXFleetTest.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace IOXFleetTest.Persistence;

public class FleetTestDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Quote> Quotes { get; set; }
    
    
    public FleetTestDbContext(DbContextOptions<FleetTestDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    //    modelBuilder.Entity<User>()
    //        .HasOne(e => e.Account)
   //         .WithOne(e => e.User)
     //       .HasForeignKey<Account>(e => e.UserIDNumber)
     //       .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
}