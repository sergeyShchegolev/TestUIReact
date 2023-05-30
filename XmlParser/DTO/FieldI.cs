using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public abstract class Field
    {
        public int Id { get; set; }
        [JsonProperty("@Name")]
        public string? Name { get; set; }
        [JsonProperty("@Type")]
        public string? Type { get; set; }
        [JsonProperty("@Alias")]
        public string? Alias { get; set; }
        [JsonProperty("Item")]
        public string? Item { get; set; }
    }
}