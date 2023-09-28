namespace EntityFrameworkCoreBenchmark.Configurations;

internal sealed class ChildConfiguration : object, Microsoft
    .EntityFrameworkCore.IEntityTypeConfiguration<Model.Child>
{
    public ChildConfiguration() : base()
    {
    }

    public void Configure(Microsoft.EntityFrameworkCore.Metadata
        .Builders.EntityTypeBuilder<Model.Child> builder)
    {
        builder
            .Property(current => current.Name)
            .IsUnicode(unicode: true)
            ;

        builder
            .HasIndex(current => new { current.BirthDate })
            .IsUnique(unique: false)
            ;
    }
}
