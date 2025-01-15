using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "the name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The price is required")]
    public decimal Price { get; set; }
    public string? Description { get; set; }

    [Required(ErrorMessage = "The stocl is required")]
    [Range(1, 9999)]
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
