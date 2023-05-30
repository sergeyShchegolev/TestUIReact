using Audit.Core;
using DictionariesForms;
using DictionariesForms.Helpers;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Audit.PostgreSql.Configuration;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


Audit.Core.Configuration.Setup().UsePostgreSql(config => config
        .ConnectionString(configuration.GetConnectionString("SBMContext"))
        .Schema("app")
        .TableName("events")
        .IdColumnName("id")
        .DataColumn("data", DataType.JSONB)
        .CustomColumn("event_type", ev => ev.EventType)
        .CustomColumn("user", ev => ev.Environment.UserName)
        .CustomColumn("machine", ev => ev.Environment.MachineName));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SBMContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("SBMContext")));

builder.Services.AddScoped<IPermissionsHelper, PermissionsHelper>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("https://localhost:44443")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true));
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins("https://localhost:44443"));

//app.MapFallbackToFile("index.html");

app.Run();
