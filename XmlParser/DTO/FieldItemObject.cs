using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public class FieldItemObject : Field
    {
        private new string? item;
        [JsonProperty("Item")]
        public new object Item
        {
            get { return item?.ToString(); }
            set
            {
                if (value?.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                {
                    item = string.Join(", ", value);

                }
                else
                {
                    item = value?.ToString();
                }
            }
        }
    }
}