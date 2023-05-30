using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using XmlParser.DTO;

namespace XmlParser
{

    public class SBMContext : DbContext
    {
        public SBMContext(DbContextOptions<SBMContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionStringName = "SBMContext";

                var connectionString =
                        System.Configuration.ConfigurationManager.
                        ConnectionStrings[connectionStringName].ConnectionString;

                optionsBuilder.UseSqlServer(connectionString);
            }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldItemObject>()
                .Property(x => x.Item)
                .HasConversion(new ValueConverter<object, string?>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<string?>(v)));
        }

        public DbSet<Document_LN> Documents_LN { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FieldItemObject> Fields { get; set; }
    }
}
