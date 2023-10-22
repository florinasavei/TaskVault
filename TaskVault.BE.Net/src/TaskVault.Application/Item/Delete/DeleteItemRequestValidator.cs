namespace TaskVault.Application;

public sealed class DeleteItemRequestValidator : AbstractValidator<DeleteItemRequest>
{
    public DeleteItemRequestValidator() => RuleFor(request => request.Id).Id();
}
