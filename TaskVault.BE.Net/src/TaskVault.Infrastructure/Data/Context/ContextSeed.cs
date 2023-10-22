namespace TaskVault.Infrastructure.Data;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder) => builder.SeedUsers();

    private static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<User>(entity => entity.HasData(new
        {
            Id = 1L,
            Name = "Administrator",
            Email = "administrator@administrator.com",
            Status = UserStatus.Active
        }));

        builder.Entity<Auth>(entity => entity.HasData(new
        {
            Id = 1L,
            Username = "admin",
            // Admin123!
            Password = "L4DYwGl7p4dvA4xKMRrhE1aMywSN0LYEOJ0jd5nelZzf/PZjfVVg607JRjDgQjFmkF9gGR7Zsc7LUNaaHMplDne351ErT/EJZn6/KcVEbOUXb9qY+SOgs34HT6zTKs3jj4siCZkpOqY5VE5O+SFMSNbAp2iZK1L9xX5ER6Ibs1CgWCgsQghTdjAtF9JjFO8FhXfDMeLdwLz3TSlsKEwNaMdp5s6gzYoxbHrq33SVLD/pOy7OxsjlNCKXK3LqzaICYppNKq8y5Pgu0RI/lGFIezV0hTkY/np6+VzAimSsUUgbZiNez7ook9FSyGZwW4NEfYERMe0O5amb2jiDV9G0cAUhMuQdRJj5rDgTo55WEwSb9r9h99q323GVVLg8zjfj0acThxIK/ZHSocpc/NgoIGEksR1TMEOXZNr6O79C9/FPNi6HME44MI1+dGYKXqnYc6DpccrATtcNuTJ/B5Ouowh25ZmKZuupmPuVTU+dbZmEcGPuaITUD5Fd2k4sVISOy2HhlyK9vv4q/LsCZqa1OP9fEalWBx/1uuUMY0lG39gG4JVgoWKWAvcINDaEmUbhINqKCLkj8353Z7wdI1PHILP4Yqj6H27S2c1eB7NfAIpakaG72wBPGNzXG9XpAJBz622JBCrP2wxTDERUKe9/y512DMpfvbg9xJKNWFq3Bkw=",
            Salt = new Guid("3340f9d5-cba1-4fa8-b0ea-a28c4f974ae7"),
            Roles = Roles.User | Roles.Admin,
            UserId = 1L
        }));
    }
}
