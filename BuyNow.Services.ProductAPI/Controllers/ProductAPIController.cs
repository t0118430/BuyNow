using BuyNow.Services.ProductAPI.Models.Dto;
using BuyNow.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BuyNow.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductAPIController : ControllerBase
{
    private IProductRepository _productRepository;
    protected ResponseDto _responseDto;

    public ProductAPIController(IProductRepository productRepository,ResponseDto responseDto)
    {
        _productRepository = productRepository;
        _responseDto = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _responseDto.Result = _responseDto;
        }
        catch (Exception ex)
        {
            _responseDto.IsSucess = false;
            _responseDto.ErrorMessages
                = new List<string>() {ex.ToString()};
        }
        return _responseDto;
    }
    
    
}