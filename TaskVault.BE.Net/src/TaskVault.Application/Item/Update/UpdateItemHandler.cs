using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record UpdateItemHandler : IHandler<UpdateItemRequest>
{
    private readonly IItemRepository _ItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemHandler
    (
        IItemRepository ItemRepository,
        IUnitOfWork unitOfWork
    )
    {
        _ItemRepository = ItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(UpdateItemRequest request)
    {
        var entity = new Item(request.Id, request.Name, request.Progress, request.Priority);

        await _ItemRepository.UpdateAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
