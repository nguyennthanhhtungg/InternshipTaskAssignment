using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAssignment.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {

        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

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
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
