using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace UseModels.Data
{
    public class DBHelperDapper(IConfiguration config)
    {
        private readonly string _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database connection string can't be found");

        //Using using (IDbConnection dbConnection = new SqlConnection(connectionString)) ensures that the database connection is properly opened and closed automatically. This approach follows best practices for resource management in C#. Main reasons - Automatic Resource Cleanup; Prevents Connection Leaks; Cleaner & Safer Code

        //  // ExecuteQuery method to handle UPDATE, INSERT, DELETE
        public void ExecuteQuery(string sqlCMD, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            dbConnection.Execute(sqlCMD, parameters);
        }

        public IEnumerable<T> QueryData<T>(string sqlCMD, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return dbConnection.Query<T>(sqlCMD, parameters);
        }

        public T QuerySingleData<T>(string sqlCMD, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return dbConnection.QuerySingle<T>(sqlCMD, parameters);

        }
    }

}