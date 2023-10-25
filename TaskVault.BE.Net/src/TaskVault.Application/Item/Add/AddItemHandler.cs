using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record AddItemHandler : IHandler<AddItemRequest, long>
{
    private readonly IItemRepository _ItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddItemHandler
    (
        IItemRepository ItemRepository,
        IUnitOfWork unitOfWork
    )
    {
        _ItemRepository = ItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<long>> HandleAsync(AddItemRequest request)
    {
        var entity = new Item(request.Name, request.Priority);

        await _ItemRepository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, entity.Id);
    }
}
