
using System.Text;
using career_service.Src.Consumers;
using career_service.Src.Data;
using career_service.Src.Helpers;
using career_service.Src.Repsositories;
using career_service.Src.Repsositories.Interface;
using career_service.Src.Services;
using career_service.Src.Services.Interface;
using DotNetEnv;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Configurar MongoDB
string mongoConnectionString = Env.GetString("MONGO_CONNECTION_STRING");
string mongoDatabaseName = Env.GetString("MONGO_DATABASE");

if (string.IsNullOrEmpty(mongoConnectionString) || string.IsNullOrEmpty(mongoDatabaseName))
{
    throw new Exception("La cadena de conexión o el nombre de la base de datos no están configurados.");
}

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoConnectionString));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoDatabaseName);
}); 


builder.Services.AddScoped<ICareersRepository, CareerRepository>();
builder.Services.AddScoped<ICareersService, CareersService>();
builder.Services.AddScoped<ISubjectsRepository, SubjectsRepository>();
builder.Services.AddScoped<ISubjectsService, SubjectsService>();
builder.Services.AddScoped<IBlackListService, BlackListService>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<BlacklistInterceptor>();
});  // Esta línea es importante
builder.Services.AddTransient<Seed>();

var secret = Env.GetString("JWT_SECRET");

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            secret
        ))
    };
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TokenToBlacklistConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        
        cfg.ReceiveEndpoint("token-blacklist-queue", ep =>
        {
            ep.ConfigureConsumer<TokenToBlacklistConsumer>(context);
        });
    });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var seed = scope.ServiceProvider.GetRequiredService<Seed>();
    seed.SeedData();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGrpcService<SubjectsGrpcService>();
app.MapGrpcService<CareersGrpcService>();

app.MapGet("/", () => "Hello World!");



app.Run();

