using BuyNow.Services.ProductAPI.Models;
using BuyNow.Services.ProductAPI.Models.Dto;

namespace BuyNow.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int productId);
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int productId);
    Task<IEnumerable<ProductDto>> GetProductByType(string productType);
}