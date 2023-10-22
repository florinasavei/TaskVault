using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record GetItemHandler : IHandler<GetItemRequest, ItemModel>
{
    private readonly IItemRepository _ItemRepository;

    public GetItemHandler(IItemRepository ItemRepository) => _ItemRepository = ItemRepository;

    public async Task<Result<ItemModel>> HandleAsync(GetItemRequest request)
    {
        var model = await _ItemRepository.GetModelAsync(request.Id);

        return new Result<ItemModel>(model is null ? NotFound : OK, model);
    }
}
