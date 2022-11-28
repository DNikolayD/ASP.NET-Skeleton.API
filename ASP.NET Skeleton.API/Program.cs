using ASP.NET_Skeleton.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.ConfigureServices(configuration);

var app = builder.Build();

app.ConfigureWebSettings();

app.Run();
