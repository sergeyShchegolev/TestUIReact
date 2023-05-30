using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DictionariesForms
{

    public class SBMContext : DbContext
    {
        public SBMContext(DbContextOptions<SBMContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("SBMContext"));
        }

        public class SBMContextFactory : IDesignTimeDbContextFactory<SBMContext>
        {
            public SBMContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<SBMContext>();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("SBMContext"));

                return new SBMContext(optionsBuilder.Options);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
