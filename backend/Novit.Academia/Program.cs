using Carter;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Repository;
using Novit.Academia.Service;

var builder = WebApplication.CreateBuilder(args);

TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

builder.Services.AddCarter();

builder.Services.AddCors(options =>
    options.AddPolicy("Academia2024", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(config.GetConnectionString("AppDb")));

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(options => options.EnableTryItOutByDefault());

app.UseCors("Academia2024");

app.MapCarter();

app.Run();
