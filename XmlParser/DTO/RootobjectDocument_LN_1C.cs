using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public class RootobjectDocument_LN_1C
    {
        [JsonProperty("document_LN_1C")]
        public Document_LN document_LN { get; set; }
    }
}