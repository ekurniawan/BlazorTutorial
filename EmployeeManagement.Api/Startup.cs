using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace EmployeeManagement.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddControllers ();
            services.AddDbContext<AppDbContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                    
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "EmployeeManagement.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

            app.UseDeveloperExceptionPage ();
            app.UseSwagger ();
            app.UseSwaggerUI (c => c.SwaggerEndpoint ("/swagger/v1/swagger.json", "EmployeeManagement.Api v1"));

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors (policy =>
                policy.WithOrigins("http://localhost:7000", "https://localhost:7001", "http://localhost:52192", "https://localhost:44313")
                .AllowAnyMethod()
                .WithHeaders (HeaderNames.ContentType));

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}