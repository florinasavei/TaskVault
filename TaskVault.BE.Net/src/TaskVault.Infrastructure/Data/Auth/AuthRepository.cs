namespace TaskVault.Infrastructure.Data;

public sealed class AuthRepository : EFRepository<Auth>, IAuthRepository
{
    public AuthRepository(Context context) : base(context) { }

    public System.Threading.Tasks.Task DeleteByUserIdAsync(long userId) => DeleteAsync(entity => entity.User.Id == userId);

    public Task<Auth> GetByLoginAsync(string username) => Queryable.SingleOrDefaultAsync(entity => entity.Username == username);
}
