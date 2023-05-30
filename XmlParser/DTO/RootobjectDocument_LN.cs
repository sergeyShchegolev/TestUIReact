using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public class RootobjectDocument_LN
    {
        [JsonProperty("document_LN")]
        public Document_LN document_LN { get; set; }
    }
}