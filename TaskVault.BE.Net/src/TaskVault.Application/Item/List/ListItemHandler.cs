using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record ListItemHandler : IHandler<ListItemRequest, IEnumerable<ItemModel>>
{
    private readonly IItemRepository _ItemRepository;

    public ListItemHandler(IItemRepository ItemRepository) => _ItemRepository = ItemRepository;

    public async Task<Result<IEnumerable<ItemModel>>> HandleAsync(ListItemRequest request)
    {
        var list = await _ItemRepository.ListModelAsync();

        return new Result<IEnumerable<ItemModel>>(list is null ? NotFound : OK, list);
    }
}
