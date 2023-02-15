using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlParser.DTO;

namespace XmlParser
{
    internal class Parser
    {
        public void Parse()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string xml = "C:\\Users\\beeli\\Downloads\\LNDE-CNVGJB-58E9C842D3AFDC354325895100440056.002.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(xml);
            var fromXml = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.Indented);

            var fromJson = JsonConvert.DeserializeObject<Rootobject>(fromXml);
        }
    }
}



