using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using XmlParser;
using static XmlParser.DTO.Rootobject;

namespace DataAccess
{
    public class Document_LNRepository : IDocument_LNRepository, IDisposable
    {
        private SBMContext context;

        public Document_LNRepository(SBMContext context)
        {
            this.context = context;
        }

        public IEnumerable<Document_LN> GetDocuments_LN()
        {
            return context.Documents_LN.ToList();
        }

        public Document_LN GetDocument_LNByID(int id)
        {
            return context.Documents_LN.Find(id);
        }

        public void InsertDocument_LN(Document_LN student)
        {
            context.Documents_LN.Add(student);
        }

        public void DeleteDocument_LN(int studentID)
        {
            Document_LN student = context.Documents_LN.Find(studentID);
            context.Documents_LN.Remove(student);
        }

        public void UpdateDocument_LN(Document_LN student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}