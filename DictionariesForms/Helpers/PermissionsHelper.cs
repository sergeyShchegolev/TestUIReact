using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;

namespace DictionariesForms.Helpers
{
    public interface IPermissionsHelper
    {
        public void PopulateUserObjectPermissions(string userName, string objectName);
        public List<UOP> GetUserObjectPermissions(string userName);

        public bool HasCreatePermission();
        public bool HasReadPermission();
        public bool HasUpdatePermission();
        public bool HasDeletePermission();
        public bool HasCreateVersionPermission();
    }

    public class PermissionsHelper : IPermissionsHelper
    {
        public List<UOP> Permissions { get; private set; } = new List<UOP>();

        private const string UserObjectPermissionsSql = @"
                    	select 
                            u.""Name"" UserName
                            ,o.""Name"" ObjectName
                            ,p.""Name"" PermissionName
                        from app.""UserObjectPermissions"" uop
                        inner join app.""Users"" u on u.""Id"" = uop.""UserId""
                        inner join app.""Objects"" o on o.""Id"" = uop.""ObjectId""
                        inner join app.""Permissions"" p on p.""Id"" = uop.""PermissionId""
                        WHERE uop.""IsActive"" = true ";

        private readonly IConfiguration _configuration;

        public PermissionsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PopulateUserObjectPermissions(string userName, string objectName)
        {
            using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("SBMContext")))
            {
                string sql = UserObjectPermissionsSql +
                        @" and u.""Name"" = @userName" +
                        @" and o.""Name"" = @objectName";
                Permissions = db.Query<UOP>(sql,
                      new { userName, objectName }).ToList();
            }
        }

        public List<UOP> GetUserObjectPermissions(string userName)
        {
            using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("SBMContext")))
            {
                return db.Query<UOP>(UserObjectPermissionsSql +
                        @" and u.""Name"" = @userName",
                      new { userName }).ToList();
            }
        }

        public bool HasCreatePermission() => Permissions.Any(x => x.PermissionName == "All" || x.PermissionName == "Create");
        public bool HasReadPermission() => Permissions.Any(x => x.PermissionName == "All" || x.PermissionName == "Read");
        public bool HasUpdatePermission() => Permissions.Any(x => x.PermissionName == "All" || x.PermissionName == "Update");
        public bool HasDeletePermission() => Permissions.Any(x => x.PermissionName == "All" || x.PermissionName == "Delete");
        public bool HasCreateVersionPermission() => Permissions.Any(x => x.PermissionName == "All" || x.PermissionName == "CreateVersion");
    }

    public class UOP
    {
        public string UserName { get; set; }
        public string ObjectName { get; set; }
        public string PermissionName { get; set; }
    }
}
