using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskAssignment2.Models;
using TaskAssignment2.Repositories;
using TaskAssignment2.Services;
using System.Configuration;

namespace TaskAssignment2
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            Console.WriteLine("Server is running...!");

            RegisterServices();

            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<IEmployeeService>().ExportEmployeesWithIsActivedFalseToCSVFile();

            DisposeServices();
        }

        //Register Services
        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            serviceProvider = services.BuildServiceProvider(true);
        }

        //Dispose Services
        private static void DisposeServices()
        {
            if(serviceProvider == null)
            {
                return;
            }

            if(serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
