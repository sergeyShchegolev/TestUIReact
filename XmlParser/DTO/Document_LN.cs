using Newtonsoft.Json;

namespace XmlParser.DTO
{

    public class Rootobject
    {
        [JsonProperty("?xml")]
        public Xml xml { get; set; }
        [JsonProperty("Document_LN")]
        public Document_LN document_LN { get; set; }

        public class Xml
        {
            [JsonProperty("@version")]
            public string version { get; set; }
            [JsonProperty("@encoding")]
            public string encoding { get; set; }
            [JsonProperty("@standalone")]
            public string standalone { get; set; }
        }

        public class Document_LN
        {
            public int Id { get; set; }
            [JsonProperty("@DB_name")]
            public string DB_name { get; set; }
            [JsonProperty("@Problem")]
            public string Problem { get; set; }
            [JsonProperty("@FilePath")]
            public string FilePath { get; set; }
            [JsonProperty("@DbReplicaID")]
            public string DbReplicaID { get; set; }
            [JsonProperty("@Server_name")]
            public string Server_name { get; set; }
            [JsonProperty("Document")]
            public Document[] document { get; set; }

            public class Document
            {
                public int Id { get; set; }
                [JsonProperty("@Form")]
                public string Form { get; set; }
                [JsonProperty("@UNID")]
                public string UNID { get; set; }
                [JsonProperty("@Schema")]
                public string Schema { get; set; }
                [JsonProperty("@DB_name")]
                public string DB_name { get; set; }
                [JsonProperty("@FilePath")]
                public string FilePath { get; set; }
                [JsonProperty("@DbReplicaID")]
                public string DbReplicaID { get; set; }
                [JsonProperty("@Server_name")]
                public string Server_name { get; set; }
                [JsonProperty("@ModifiedDateTime")]
                public DateTime ModifiedDateTime { get; set; }
                [JsonProperty("Field")]
                public Field[] field { get; set; }


                public class Field
                {
                    public int Id { get; set; }
                    [JsonProperty("@Name")]
                    public string Name { get; set; }
                    [JsonProperty("@Type")]
                    public string Type { get; set; }
                    [JsonProperty("@Alias")]
                    public string Alias { get; set; }
                    [JsonProperty("@Item")]
                    public string Item { get; set; }
                }
            }
        }
    }

}