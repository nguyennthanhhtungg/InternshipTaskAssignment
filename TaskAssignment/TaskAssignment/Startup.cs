using CustomHealthChecks;
using CustomHealthChecks.ConfigureExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.Services;

namespace TaskAssignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


            //Add Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();

            //Add Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Health Checks
            services.AddHealthChecks()
                .AddTypeActivatedCheck<CustomSqlServerHealthCheck>(name: "Customn Sql Server Health Check", args: new object[] { Configuration["ConnectionStrings:DefaultConnection"] })
                .AddTypeActivatedCheck<CustomUrlHealthCheck>(name: "Custom Url Health Check", args: "http://localhost:57622/Swagger/index.html");

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Task Assignment 1",
                    Version = "v1.1",
                    Description = "API to request and response Employee CRUD!"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Health Checks
            app.UseCustomHealthChecks();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Assignment 1");
            });
        }
    }
}
