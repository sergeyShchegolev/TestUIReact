using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class SBMContext : DbContext
    {
        public SBMContext(DbContextOptions<SBMContext> options)
        : base(options)
        {
        }
        public SBMContext(string connectionString)
            : base()
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

        public DbSet<Phase> Phases { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
