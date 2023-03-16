using System.ComponentModel.DataAnnotations;

namespace BuyNow.Services.ProductAPI.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string ImageUrl { get; set; }
}