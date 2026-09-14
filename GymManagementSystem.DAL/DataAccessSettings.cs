using System.Configuration;
using System.Data.SqlClient;

namespace GymManagementSystem.DAL
{
    public static class DataAccessSettings
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}