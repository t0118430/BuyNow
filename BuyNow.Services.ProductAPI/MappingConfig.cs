using AutoMapper;
using BuyNow.Services.ProductAPI.Models;
using BuyNow.Services.ProductAPI.Models.Dto;

namespace BuyNow.Services.ProductAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>().ReverseMap();
        });

        return mappingConfig;
    }
}