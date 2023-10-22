using System.Text.Json.Serialization;

namespace TaskVault.Application;

public sealed record UpdateUserRequest(string Name, string Email)
{
    [JsonIgnore]
    public long Id { get; set; }
}
