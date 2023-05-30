using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser.DTO;

namespace XmlParser.Interfaces
{
    public interface IDocument_LNRepository : IDisposable
    {
        IEnumerable<Document_LN> GetDocuments_LN();
        Document_LN GetDocument_LNByID(int document_LNId);
        void InsertDocument_LN(Document_LN document_LN);
        void DeleteDocument_LN(int document_LNiD);
        void UpdateDocument_LN(Document_LN document_LN);
        void Save();
    }
}
