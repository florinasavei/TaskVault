namespace TaskVault.Infrastructure.Data;

public sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable(nameof(Item), nameof(Item));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Name).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Progress);

        builder.Property(entity => entity.Priority);
    }
}
