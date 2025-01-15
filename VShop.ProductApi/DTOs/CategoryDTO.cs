using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="the name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
