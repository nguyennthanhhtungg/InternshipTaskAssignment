using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskAssignment2.Models;
using TaskAssignment2.Repositories;
using TaskAssignment2.Services;
using System.Configuration;
using System.Threading.Tasks;

namespace TaskAssignment2
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Server is running...!");

            RegisterServices();
            IServiceScope scope = serviceProvider.CreateScope();
            if (args.Length == 0)
            {
                await scope.ServiceProvider.GetRequiredService<IEmployeeService>().ExportEmployeesWithIsActivedFalseToCSVFile();
            }
            else
            {
                Console.WriteLine($"Uri: {args[0]}");
                await scope.ServiceProvider.GetRequiredService<ITaskAssignment1API>().DisplayEmployeeListOnConsole(args[0]);
            }

            DisposeServices();
        }

        //Register Services
        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Employee Service
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Task Assignment 1 Service
            services.AddScoped<ITaskAssignment1API, TaskAssignment1API>();

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
