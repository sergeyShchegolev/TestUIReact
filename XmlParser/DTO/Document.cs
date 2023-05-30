using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public class Document
    {
        public int Id { get; set; }
        [JsonProperty("@Form")]
        public string? Form { get; set; }
        [JsonProperty("@UNID")]
        public string? UNID { get; set; }
        [JsonProperty("@Schema")]
        public string? Schema { get; set; }
        [JsonProperty("@DB_name")]
        public string? DB_name { get; set; }
        [JsonProperty("@FilePath")]
        public string? FilePath { get; set; }
        [JsonProperty("@DbReplicaID")]
        public string? DbReplicaID { get; set; }
        [JsonProperty("@Server_name")]
        public string? Server_name { get; set; }
        [JsonProperty("@ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; }
        [JsonProperty("Field")]
        public ICollection<FieldItemObject> Fields { get; set; }
    }

}