using Microsoft.EntityFrameworkCore;
using Accountant.Domain.Entities;

namespace Accountant.Context;

public class MyDbContext: DbContext
{
    public DbSet<Province>       Provinces       { get; set; } = null!;
    public DbSet<Profile>        Profiles        { get; set; } = null!;
    public DbSet<Account>        Accounts        { get; set; } = null!;
    public DbSet<ProfileAccount> ProfileAccounts { get; set; } = null!;
    public DbSet<Transaction>    Transactions    { get; set; } = null!;
    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        
        // ────────────────────────────────────────────────
        // Province
        // ────────────────────────────────────────────────
        modelBuilder.Entity<Province>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Name)    .HasMaxLength(50).IsRequired().IsUnicode();
            e.Property(p => p.Capital) .HasMaxLength(50).IsRequired().IsUnicode();
        });

        // ────────────────────────────────────────────────
        // Profile
        // ────────────────────────────────────────────────
        modelBuilder.Entity<Profile>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.ProfileType).IsRequired();
            e.Property(p => p.Name)       .HasMaxLength(50).IsRequired().IsUnicode();

            e.HasOne(p => p.Province)
             .WithMany(prov => prov.Profiles)
             .HasForeignKey(p => p.ProvinceId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ────────────────────────────────────────────────
        // Account
        // ────────────────────────────────────────────────
        modelBuilder.Entity<Account>(e =>
        {
            e.HasKey(a => a.Id);
            e.Property(a => a.AccountType).IsRequired();
            e.Property(a => a.OpenedAt)   .IsRequired();
            e.Property(a => a.ActiveMode) .IsRequired();
            //e.Property(a => a.ClosedAt)   .IsRequired();
        });

        // ────────────────────────────────────────────────
        // ProfileAccount 
        // ────────────────────────────────────────────────
        modelBuilder.Entity<ProfileAccount>(e =>
        {
            e.HasKey(pa => pa.Id);          

            e.Property(pa => pa.ProfileId)   .IsRequired();
            e.Property(pa => pa.AccountId)   .IsRequired();
            e.Property(pa => pa.ShareOwned)  .IsRequired();

            e.HasOne(pa => pa.Profile)
             .WithMany(p => p.ProfileAccounts)
             .HasForeignKey(pa => pa.ProfileId)
             .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(pa => pa.Account)
             .WithMany(a => a.ProfileAccounts)
             .HasForeignKey(pa => pa.AccountId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ────────────────────────────────────────────────
        // Transaction
        // ────────────────────────────────────────────────
        modelBuilder.Entity<Transaction>(e =>
        {
            e.HasKey(t => t.Id);

            e.Property(t => t.ProfileAccountId)  .IsRequired();
            e.Property(t => t.TransactionDate)   .IsRequired();
            e.Property(t => t.Amount)            .IsRequired();

            e.HasOne(t => t.ProfileAccount)
             .WithMany(pa => pa.Transactions)
             .HasForeignKey(t => t.ProfileAccountId)
             .OnDelete(DeleteBehavior.Restrict);       
        });
    }
}