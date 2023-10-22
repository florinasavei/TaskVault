using static System.Net.HttpStatusCode;

namespace TaskVault.Application;

public sealed record DeleteItemHandler : IHandler<DeleteItemRequest>
{
    private readonly IItemRepository _ItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemHandler
    (
        IItemRepository ItemRepository,
        IUnitOfWork unitOfWork
    )
    {
        _ItemRepository = ItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(DeleteItemRequest request)
    {
        await _ItemRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
