using TaskVault.Domain;
using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record CountItemsHandler : IHandler<CountItemsRequest, int>
{
    private readonly IItemRepository _ItemRepository;

    public CountItemsHandler(IItemRepository ItemRepository) => _ItemRepository = ItemRepository;

    public async Task<Result<int>> HandleAsync(CountItemsRequest request)
    {
        var Count = _ItemRepository.CountModel();

        return new Result<int>(OK, Count);
    }
}
