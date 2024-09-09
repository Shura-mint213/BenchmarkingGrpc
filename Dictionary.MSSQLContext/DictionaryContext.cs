using Dictionary.Models.MSSQL;
using Microsoft.EntityFrameworkCore;
using Shared.Statics;

namespace Dictionary.MSSQLContext;

public partial class DictionaryContext : DbContext
{
    public DictionaryContext()  { }
    public DictionaryContext(DbContextOptions<DictionaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(DatabaseSettings.ConnectionStringMSSQL);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>()
            .HasNoKey()
            .Property(n => n.Name)
            .HasColumnName("Currency"); // Название столбца в таблице
        modelBuilder.Entity<Country>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}
