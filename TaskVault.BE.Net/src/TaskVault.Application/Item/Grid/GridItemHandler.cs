using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record GridItemHandler : IHandler<GridItemRequest, Grid<ItemModel>>
{
    private readonly IItemRepository _ItemRepository;

    public GridItemHandler(IItemRepository ItemRepository) => _ItemRepository = ItemRepository;

    public async Task<Result<Grid<ItemModel>>> HandleAsync(GridItemRequest request)
    {
        var grid = await _ItemRepository.GridAsync(request);

        return new Result<Grid<ItemModel>>(grid is null ? NotFound : OK, grid);
    }
}
