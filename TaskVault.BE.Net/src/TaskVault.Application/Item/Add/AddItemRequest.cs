using Priority = TaskVault.Domain.Priority;

namespace TaskVault.Application;

public sealed record AddItemRequest(string Name, Priority Priority);
