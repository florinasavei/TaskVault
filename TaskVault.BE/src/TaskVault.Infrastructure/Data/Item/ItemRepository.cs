namespace TaskVault.Infrastructure.Data;

public sealed class ItemRepository : EFRepository<Item>, IItemRepository
{
    public ItemRepository(Context context) : base(context) { }

    public static Expression<Func<Item, ItemModel>> Model => entity => new ItemModel
    {
        Id = entity.Id,
        Name = entity.Name,
        Progress = entity.Progress,
        Priority = (Models.Priority)entity.Priority // TODO: add automapper
    };

    public Task<ItemModel> GetModelAsync(long id) => Queryable.Where(entity => entity.Id == id).Select(Model).SingleOrDefaultAsync();

    public Task<Grid<ItemModel>> GridAsync(GridParameters parameters) => Queryable.Select(Model).GridAsync(parameters);

    public async Task<IEnumerable<ItemModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();
}
