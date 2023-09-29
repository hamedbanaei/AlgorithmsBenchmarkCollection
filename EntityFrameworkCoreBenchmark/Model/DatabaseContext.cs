using Microsoft.EntityFrameworkCore;

namespace Model;

public class DatabaseContext :
    DbContext
{
    public DatabaseContext() : base()
    {
        Database.EnsureCreated();
    }

    public DbSet<Model.Father> Fathers { get; set; }

    public DbSet<Model.Child> Children { get; set; }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=.;User ID=sa;Password=1234512345;Database=EFCoreBenchmark;MultipleActiveResultSets=true;TrustServerCertificate=True;";

        // using Microsoft.EntityFrameworkCore;
        optionsBuilder.UseSqlServer
            (connectionString: connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(DatabaseContext).Assembly);
    }
}
