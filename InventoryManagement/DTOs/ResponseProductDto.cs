using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.DTOs
{
    public class ResponseProductDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "stockAvailable")]
        public int StockAvailable { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string? Category { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Timestamp]
        [JsonProperty(PropertyName = "rowVersion")]
        public byte[] RowVersion { get; set; } = null!;
    }
}
