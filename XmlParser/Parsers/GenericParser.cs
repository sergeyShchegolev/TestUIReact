
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlParser.DTO;
using XmlParser.DAL;

namespace XmlParser.Parsers
{
    public class GenericParser
    {
        SBMContext _context;

        public GenericParser(SBMContext context)
        {
            _context = context;
        }

        public void Parse()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string[] files = Directory.GetFiles("C:\\Work\\XMLs", "*.xml");
            long versionId = IdentityProvider.PopIdentity();

            foreach (var file in files)
            {
                string xml = file;
                var xmldoc = new XmlDocument();
                xmldoc.Load(xml);
                var fromXml = JsonConvert.SerializeXmlNode(xmldoc, Newtonsoft.Json.Formatting.Indented);

                try
                {
                    var document_LN = JsonConvert.DeserializeObject<RootobjectDocument_LN>(fromXml).document_LN
                        ?? JsonConvert.DeserializeObject<RootobjectDocument_LN_1C>(fromXml).document_LN;

                    document_LN.VersionId = versionId;
                    _context.Add(document_LN);
                }
                catch (Exception ex) 
                {
                }

            }

            _context.SaveChanges();
        }
    }
}
