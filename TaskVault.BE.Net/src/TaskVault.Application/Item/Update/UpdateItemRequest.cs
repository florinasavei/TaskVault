using System.Text.Json.Serialization;
using Priority = TaskVault.Domain.Priority;

namespace TaskVault.Application;

public sealed record UpdateItemRequest(string Name, Priority Priority, ushort Progress)
{
    [JsonIgnore]
    public long Id { get; set; }
}
