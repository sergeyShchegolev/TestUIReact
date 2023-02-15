using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace XmlParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            BuildWebHost(args).Run();

            parser.Parse();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}