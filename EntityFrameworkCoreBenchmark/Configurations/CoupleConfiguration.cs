namespace EntityFrameworkCoreBenchmark.Configurations;

internal sealed class CoupleConfiguration : object, Microsoft
    .EntityFrameworkCore.IEntityTypeConfiguration<Model.Couple>
{
    public CoupleConfiguration() : base()
    {
    }

    public void Configure(Microsoft.EntityFrameworkCore.Metadata
        .Builders.EntityTypeBuilder<Model.Couple> builder)
    {
        builder
            .Property(current => current.FatherName)
            .IsUnicode(unicode: true)
            ;

        builder
            .Property(current => current.MotherName)
            .IsUnicode(unicode: true)
            ;

        builder
            .HasIndex(current => new { current.MarriageDate })
            .IsUnique(unique: false)
            ;
        
        builder
            .HasMany(current => current.Children)
            .WithOne(other => other.Parrent)
            .IsRequired(required: true)
            .HasForeignKey(other => other.ParrentId)
            .OnDelete(deleteBehavior:
                Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
            ;
    }
}