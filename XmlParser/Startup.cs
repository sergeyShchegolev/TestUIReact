using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringName = "SBMContext";

            var connectionString =
                    System.Configuration.ConfigurationManager.
                    ConnectionStrings[connectionStringName].ConnectionString;
            services.AddDbContext<SBMContext>(options => options.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {

        }
    }
}
