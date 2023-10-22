namespace TaskVault.Infrastructure.Data;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        ContextSeed.Seed(builder); // Call the Seed method separately

    }
}
