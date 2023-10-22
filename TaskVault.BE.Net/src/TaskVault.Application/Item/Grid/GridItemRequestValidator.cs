namespace TaskVault.Application;

public sealed class GridItemRequestValidator : AbstractValidator<GridItemRequest>
{
    public GridItemRequestValidator() => RuleFor(request => request).Grid();
}
