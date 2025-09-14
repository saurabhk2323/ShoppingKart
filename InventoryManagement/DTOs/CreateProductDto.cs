using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace InventoryManagement.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price should be always a non zero positive number.")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "stockAvailable")]
        [Range(0, int.MaxValue, ErrorMessage = "StockAvailable cannot have a negative value.")]
        public int AvailableStocks { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; } = string.Empty;
    }
}
