namespace BuyNow.Services.ProductAPI.Models.Dto;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string ImageUrl { get; set; }
}