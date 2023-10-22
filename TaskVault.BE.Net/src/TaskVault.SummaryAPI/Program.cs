using Bogus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

var faker = new Faker();

app.MapGet("/", () =>
{
    return "it works";
})
.WithName("Test");

app.MapGet("/lorem/", () =>
{
    // Generate a random delay between 2 and 10 seconds (2000 to 10000 milliseconds)
    var randomDelay = new Random().Next(2000, 10001);
    Thread.Sleep(randomDelay);
    return faker.Lorem.Paragraphs(3);
})
.WithName("LoremIpsum");

app.Run();
