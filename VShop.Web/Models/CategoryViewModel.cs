using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VShop.Web.Models;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
