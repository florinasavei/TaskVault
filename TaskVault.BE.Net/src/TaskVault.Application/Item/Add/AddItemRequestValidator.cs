namespace TaskVault.Application;

public sealed class AddItemRequestValidator : AbstractValidator<AddItemRequest>
{
    public AddItemRequestValidator() => RuleFor(request => request.Name).Name();
}
