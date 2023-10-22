namespace TaskVault.Domain;

public sealed class Auth : Entity
{
    public Auth
    (
        string usrname,
        string password,
        User user
    )
    {
        Username = usrname;
        Password = password;
        User = user;
        Salt = Guid.NewGuid();
        Roles = Roles.User;
    }

    public Auth() { }

    public string Username { get; }

    public string Password { get; private set; }

    public Guid Salt { get; }

    public Roles Roles { get; }

    public User User { get; }

    public void UpdatePassword(string password) => Password = password;
}
