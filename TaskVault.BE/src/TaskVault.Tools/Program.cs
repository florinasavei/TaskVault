using DotNetCore.Security;

IHashService hashService = new HashService();

Console.WriteLine("Please enter your SALT: ");
string salt = Console.ReadLine();

Console.WriteLine("Please enter your value: ");
string value = Console.ReadLine();


var hashedString = hashService.Create(value, salt);

Console.WriteLine("Hashed value: {0}", hashedString);

Console.ReadLine();
