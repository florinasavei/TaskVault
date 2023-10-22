namespace TaskVault.Infrastructure.Data;

public interface IAuthRepository : IRepository<Auth>
{
    System.Threading.Tasks.Task DeleteByUserIdAsync(long userId);

    Task<Auth> GetByLoginAsync(string username);
}
