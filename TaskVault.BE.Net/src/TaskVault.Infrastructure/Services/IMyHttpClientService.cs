namespace TaskVault.Infrastructure.Services
{
    public interface IMyHttpClientService
    {
        Task<string> GetApiResponseAsync(string apiUrl);
    }
}
