using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using static XmlParser.SBMContext;
using XmlParser.Parsers;

namespace XmlParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sbmContext = new SBMContext(new DbContextOptions<SBMContext>());

            var parser = new GenericParser(sbmContext);

            parser.Parse();
        }
    }
}