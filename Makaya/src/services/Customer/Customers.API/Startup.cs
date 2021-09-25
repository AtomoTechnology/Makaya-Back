using Customer.services.queries.Interface;
using Customer.services.queries.Queries;
using Customers.Persistence.DataBase;
using HealthChecks.UI.Client;
using Makaya.Resolver.IExceptions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace Customers.API
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
            services.AddDbContext<ApplicationDbContext>(
                cnn => cnn.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("_EFMigrationsHistory","Makaya")
                )    
            );

            //Check DataBase
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDbContextCheck<ApplicationDbContext>(typeof(ApplicationDbContext).Name);
            //services.AddHealthChecksUI();

            // Event handlers
            services.AddMediatR(Assembly.Load("Customer.Service.EventHandlers"));

            services.AddTransient<ICountryQueryService, CountryQueryService>();
            services.AddTransient<IProvinceQueryService, ProvinceQueryService>();
            services.AddTransient<ICityQueryService, CityQueryService>();
            services.AddTransient<IUserQueryService, UserQueryService>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(excpt => {
                    excpt.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                var err = (IApiExceptions)ex.Error;
                                var result = JsonConvert.SerializeObject(new { 
                                   ErrorCode = err.ErrorCode,
                                    MessageError = err.MessageError,
                                    HttpStatus = err.HttpStatus,
                                    ReferenceLink = err.ReferenceLink
                                });
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync(result);
                            }
                        }    
                    );
                });
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI();
            });
        }
    }
}
