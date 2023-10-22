namespace TaskVault.Infrastructure.Services
{
    public class MyHttpClientService : IMyHttpClientService
    {
        private readonly HttpClient _httpClient;

        public MyHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetApiResponseAsync(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
