using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomHealthChecks
{
    public class CustomUrlHealthCheck : IHealthCheck
    {
        private string EndpointUrl { get; set; }

        public CustomUrlHealthCheck(string endpointUrl)
        {
            this.EndpointUrl = endpointUrl;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(EndpointUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return await Task.FromResult(HealthCheckResult.Healthy("Url is valid...!"));
                        }
                        else
                        {
                            return await Task.FromResult(HealthCheckResult.Unhealthy("Url is invalid!"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");

                return await Task.FromResult(HealthCheckResult.Unhealthy("Url is invalid!"));
            }
        }
    }
}
