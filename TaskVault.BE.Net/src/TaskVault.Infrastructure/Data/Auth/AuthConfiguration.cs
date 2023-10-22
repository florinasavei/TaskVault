namespace TaskVault.Infrastructure.Data;

public sealed class AuthConfiguration : IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.ToTable(nameof(Auth), nameof(Auth));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Username).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Password).HasMaxLength(1000).IsRequired();

        builder.Property(entity => entity.Salt).HasMaxLength(1000).IsRequired();

        builder.Property(entity => entity.Roles).IsRequired();

        builder.HasOne(entity => entity.User).WithOne().HasForeignKey<Auth>("UserId").IsRequired();

        builder.HasIndex(entity => entity.Username).IsUnique();

        builder.HasIndex(entity => entity.Salt).IsUnique();

        builder.HasIndex("UserId").IsUnique();
    }
}
