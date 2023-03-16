using AutoMapper;
using BuyNow.Services.ProductAPI;
using BuyNow.Services.ProductAPI.DbContexts;
using BuyNow.Services.ProductAPI.Models;
using BuyNow.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IProductRepository,ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();