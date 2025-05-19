using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class DbConnection
    {
        //global::PedidosApp1.Properties.Settings.Default.DbventasConnectionString;
        public static string cn = "Data Source=(local);Initial Catalog=Dbventas;Integrated Security=True;TrustServerCertificate=True";
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = cn;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}