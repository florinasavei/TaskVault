namespace TaskVault.Infrastructure.Data;

public interface IItemRepository : IRepository<Item>
{
    Task<ItemModel> GetModelAsync(long id);

    Task<Grid<ItemModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<ItemModel>> ListModelAsync();
}
