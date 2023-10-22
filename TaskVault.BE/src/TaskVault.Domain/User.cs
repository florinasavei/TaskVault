namespace TaskVault.Domain;

public sealed class User : Entity
{
    public User
    (
        string name,
        string email
    )
    {
        Name = name;
        Email = email;
        Activate();
    }

    public User(long id) => Id = id;

    public string Name { get; private set; }

    public string Email { get; private set; }

    public UserStatus Status { get; private set; }

    public void UpdateName(string name) => Name = name;

    public void UpdateEmail(string email) => Email = email;

    public void Activate() => Status = UserStatus.Active;

    public void Inactivate() => Status = UserStatus.Inactive;
}
