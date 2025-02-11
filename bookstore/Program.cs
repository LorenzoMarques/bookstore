using bookstore.Data;
using bookstore.Filters;
using bookstore.Repositories;
using bookstore.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using DotNetEnv;
using bookstore.Mappings;

var environmentFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");

Env.Load(environmentFilePath);

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
Console.WriteLine(connectionString);
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A connection string was not configured correctly.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAutoMapper(typeof(UserProfile));




builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Bookstore V1");
        options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
