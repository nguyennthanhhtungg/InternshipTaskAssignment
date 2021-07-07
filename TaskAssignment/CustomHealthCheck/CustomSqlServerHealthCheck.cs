using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace CustomHealthCheck
{
    public class CustomSqlServerHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isDBConnection = IsDBConnection();

            if (isDBConnection)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Database is running...!"));
            }
            return Task.FromResult(HealthCheckResult.Unhealthy("Database is closed!"));
        }

        private bool IsDBConnection()
        {
            string connectionString = "Data Source=DESKTOP-401OUEF\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                }
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return false;
            }
        }
    }
}
