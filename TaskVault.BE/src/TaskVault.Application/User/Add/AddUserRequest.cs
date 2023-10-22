namespace TaskVault.Application;

public sealed record AddUserRequest(string Name, string Email, string Username, string Password);
