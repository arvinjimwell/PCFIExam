using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PCFI;

public class EquityDbContext : DbContext
{
    public EquityDbContext()
    {
    }

    public EquityDbContext(DbContextOptions<EquityDbContext> options) : base(options) { }

    public DbSet<Equity> Equities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = "StudentJimwell",
                InitialCatalog = "EquityDatabase",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                TrustServerCertificate = true,
                ConnectTimeout = 30
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equity>(model =>
        {
            model.HasKey(m => m.Id);

            model.HasMany<EquitySchedule>(m => m.Schedules)
                .WithOne(s => s.Equity)
                .HasForeignKey(s => s.EquityId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Property(m => m.SellingPrice)
                .HasPrecision(18, 2);

            model.Property(m => m.MonthlyAmount)
                .HasPrecision(18, 2);
        });

        modelBuilder.Entity<EquitySchedule>(model =>
        {
            model.HasKey(m => m.Id);

            model.Property(m => m.Balance)
                .HasPrecision(18, 2);
        });

        base.OnModelCreating(modelBuilder);
    }
}
