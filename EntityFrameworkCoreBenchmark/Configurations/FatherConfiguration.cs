namespace EntityFrameworkCoreBenchmark.Configurations;

internal sealed class FatherConfiguration : object, Microsoft
    .EntityFrameworkCore.IEntityTypeConfiguration<Model.Father>
{
    public FatherConfiguration() : base()
    {
    }

    public void Configure(Microsoft.EntityFrameworkCore.Metadata
        .Builders.EntityTypeBuilder<Model.Father> builder)
    {
        builder
            .Property(current => current.CarModel)
            .IsUnicode(unicode: false)
            ;

        builder
            .Property(current => current.City)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.Email)
            .IsUnicode(unicode: false)
            ;

        builder
            .Property(current => current.Name)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.City)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.Phone)
            .IsUnicode(unicode: false)
            ;

        builder
            .Property(current => current.State)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.Street)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.Website)
            .IsUnicode(unicode: false)
            ;

        builder
            .Property(current => current.ZipCode)
            .IsUnicode(unicode: false);
            ;

        builder
            .HasMany(current => current.Children)
            .WithOne(other => other.Father)
            .IsRequired(required: true)
            .HasForeignKey(other => other.FatherId)
            .OnDelete(deleteBehavior:
                Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
            ;
    }
}