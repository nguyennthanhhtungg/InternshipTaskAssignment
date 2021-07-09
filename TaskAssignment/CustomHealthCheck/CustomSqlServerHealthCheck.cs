using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace CustomHealthChecks
{
    public class CustomSqlServerHealthCheck : IHealthCheck
    {
        private string connectionString { get; set; }

        public CustomSqlServerHealthCheck(string connectionString)
        {
            this.connectionString = connectionString;
        }

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
