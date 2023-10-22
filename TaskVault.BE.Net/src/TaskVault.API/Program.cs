var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddResponseCompression();
builder.Services.AddJsonStringLocalizer();
builder.Services.AddHashService();
builder.Services.AddJwtService();
builder.Services.AddAuthorization().AddAuthentication().AddJwtBearer();
builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(Context))));
builder.Services.AddClassesMatchingInterfaces(nameof(TaskVault));
builder.Services.AddMediator(nameof(TaskVault));

// this is just for demo purposes, allowed origins should be configurabe via appsettings
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Allow requests from this origin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


builder.Services.AddHttpClient<IMyHttpClientService, MyHttpClientService>(client =>
{
    client.BaseAddress = new Uri("http://taskvault.summaryapi:80");
});


builder.Services.AddSwaggerGen(c =>
{
    var apiInfo = new OpenApiInfo { Title = "TaskVault.API", Version = "v1" };
    c.SwaggerDoc("v1", apiInfo);

    var filePath = Path.Combine(System.AppContext.BaseDirectory, $"{apiInfo.Title}.xml");
    c.IncludeXmlComments(filePath);

    // Define the security scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br/>
                      Enter 'Bearer' [space] and then your token in the text input below. <br/>
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Define the security requirements
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
});

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ItemModel>("Items");

builder.Services.AddControllers()
    .AddOData(
        options => options.Select().Filter().Count().OrderBy().Expand()
        )
    .AddJsonOptions()
    .AddAuthorizationPolicy();


var app = builder.Build();

app.UseCors();
app.UseException();
app.UseHsts().UseHttpsRedirection();
app.UseLocalization("en", "ro");
app.UseResponseCompression();
app.UseStaticFiles();
app.UseSwagger().UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskVault.API");
        c.RoutePrefix = "";

    });
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
