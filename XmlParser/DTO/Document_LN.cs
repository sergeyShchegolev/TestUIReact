﻿using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.DTO
{
    public class Document_LN
    {
        public int Id { get; set; }
        [JsonProperty("@DB_name")]
        public string? DB_name { get; set; }
        [JsonProperty("@Problem")]
        public string? Problem { get; set; }
        [JsonProperty("@FilePath")]
        public string? FilePath { get; set; }
        [JsonProperty("@DbReplicaID")]
        public string? DbReplicaID { get; set; }
        [JsonProperty("@Server_name")]
        public string? Server_name { get; set; }
        [JsonProperty("Document")]
        public ICollection<Document> Documents { get; set; }

        public long VersionId { get; set; }

    }
}