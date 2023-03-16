using BuyNow.Services.ProductAPI.Models.Dto;
using BuyNow.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyNow.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductAPIController : ControllerBase
{
    private IProductRepository _productRepository;
    protected ResponseDto _responseDto;

    public ProductAPIController(IProductRepository productRepository)
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

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try 
        {
            ProductDto productDto = await _productRepository.GetProductById(id);
            _responseDto.Result = productDto;
        }
        catch (Exception ex)
        {
            _responseDto.IsSucess = false;
            _responseDto.ErrorMessages = new List<string>() {ex.ToString()};
        }

        return _responseDto;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _responseDto.Result = model;
        }
        catch (Exception ex)
        {
            _responseDto.IsSucess = false;
            _responseDto.ErrorMessages = new List<string>() {ex.ToString()};
        }

        return _responseDto;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _responseDto.Result = model;
        }
        catch (Exception ex)
        {
            _responseDto.IsSucess = false;
            _responseDto.ErrorMessages = new List<string>() {ex.ToString()};
        }

        return _responseDto;
    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSucess = await _productRepository.DeleteProduct(id);
            _responseDto.Result = isSucess;
        }
        catch (Exception ex)
        {
            _responseDto.IsSucess = false;
            _responseDto.ErrorMessages = new List<string>() {ex.ToString()};
        }

        return _responseDto;
    }
}