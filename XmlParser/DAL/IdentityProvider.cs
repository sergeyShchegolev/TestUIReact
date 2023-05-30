using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace XmlParser.DAL
{
    public static class IdentityProvider
    {
        public static long PopIdentity()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SBMContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                return con.QuerySingle<long>($"SELECT NEXT VALUE FOR dbo.sq_Dictionary_LN_Versions;");
            }

        }
    }
}