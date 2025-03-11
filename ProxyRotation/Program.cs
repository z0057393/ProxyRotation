using ProxyRotation.Application.Manager;
using ProxyRotation.Application.Interface;
using ProxyRotation.Application.Service;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Domain.Manager;
using ProxyRotation.Domain.Service;
using ProxyRotation.Infrastructure.Interface;
using ProxyRotation.Infrastructure.Manager;
using ProxyRotation.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IProxyRotationService, ProxyRotationService>();
builder.Services.AddTransient<ProxyRotationManager>();
builder.Services.AddTransient<IProxyService, ProxyService>();
builder.Services.AddTransient<ProxyManager>();
builder.Services.AddTransient<IScraperService, ScraperService>();
builder.Services.AddTransient<ScraperManager>();
builder.Services.AddSingleton<ILoadConfigurationService, LoadConfigurationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
