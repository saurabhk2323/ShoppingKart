using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.DTOs
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Id is a required field.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price should be always a non zero positive number.")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "availableStocks")]
        [Range(0, int.MaxValue, ErrorMessage = "AvailableStocks cannot have a negative value.")]
        public int AvailableStocks { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; } = string.Empty;

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;
    }
}
