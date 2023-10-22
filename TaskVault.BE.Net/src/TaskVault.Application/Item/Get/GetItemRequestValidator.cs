namespace TaskVault.Application;

public sealed class GetItemRequestValidator : AbstractValidator<GetItemRequest>
{
    public GetItemRequestValidator() => RuleFor(request => request.Id).Id();
}
