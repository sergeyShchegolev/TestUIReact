using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XmlParser.DTO.Rootobject;

namespace XmlParser
{

    public class SBMContext : DbContext
    {
        public SBMContext(DbContextOptions<SBMContext> options)
        : base(options)
        {
            //Database.SetInitializer<SBMContext>(null);
        }
        public class SBMContextFactory : IDesignTimeDbContextFactory<SBMContext>
        {
            public SBMContext CreateDbContext(string[] args)
            {
                var connectionStringName = "SBMContext";

                var connectionString =
                        System.Configuration.ConfigurationManager.
                        ConnectionStrings[connectionStringName].ConnectionString;

                var optionsBuilder = new DbContextOptionsBuilder<SBMContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new SBMContext(optionsBuilder.Options);
            }
        }

        public DbSet<Document_LN> Documents_LN { get; set; }

    }
}
