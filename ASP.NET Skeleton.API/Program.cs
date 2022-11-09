using ASP.NET_Skeleton.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureWebSettings();

app.Run();
