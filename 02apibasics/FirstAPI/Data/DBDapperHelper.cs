using System.Transactions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FirstAPI.Data
{

    public class DBHelperDapper(IConfiguration config)
    {
        private readonly string _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database connection string can't be found");

        public int ExecuteQuery(string sql, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return dbConnection.Execute(sql, parameters);
        }

        public IEnumerable<T> QueryData<T>(string sql, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return dbConnection.Query<T>(sql, parameters);
        }

        public T QuerySingleData<T>(string sql, object? parameters = null)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return dbConnection.QuerySingle<T>(sql, parameters);
        }
    }

}