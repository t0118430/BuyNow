using AutoMapper;
using BuyNow.Services.ProductAPI;
using BuyNow.Services.ProductAPI.DbContexts;
using BuyNow.Services.ProductAPI.Models;
using BuyNow.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "BuyNow.Services.ProductAPI", Version = "v1"});
});
var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuyNow.Services.ProductAPI v1");
    c.RoutePrefix = "";
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();