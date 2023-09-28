using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreBenchmark;

public class DatabaseContext :
    Microsoft.EntityFrameworkCore.DbContext
{
    public DatabaseContext() : base()
    {
        Database.EnsureCreated();
    }

    public Microsoft.EntityFrameworkCore.DbSet<Model.Couple> Couples { get; set; }

    public Microsoft.EntityFrameworkCore.DbSet<Model.Child> Children { get; set; }

    protected override void OnConfiguring
        (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
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
