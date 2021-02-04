using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using ReadApi.CustomExceptionMiddleware;
using ReadApi.Extensions;
using ReadApi.Logging;
using ReadRepositories;
using ReadServices;
using ReadServices.Interfaces;
using System.IO;

namespace ReadApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //our migrations assembly is in the readrepositories project
            services.AddDbContext<AllphiFleetContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"]
                );
            });

            services.AddTransient(typeof(IDataReadRepository<>), typeof(DataReadRepository<>));

            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IFuelCardService, FuelCardService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ILicensePlateService, LicensePlateService>();

            //Nlog
            services.AddSingleton<ILoggerManager, LoggerManager>();

            #region commentAutomapper
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); not working because it is in another project.
            //workaround: static class from which the assembly can be retrieved.
            #endregion

            //must be the assembly from the project that contains automapper profiles, in our case this is the services project
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            services.ConfigureLoggerService();
            //enable cross origin requests for apps (44329 = angular app, 44338 = blazor app)
            services.AddCors(options =>
            {
                //angular app
                options.AddPolicy("AllowAllReadApi",
                    builder => builder.WithOrigins("https://localhost:44329", "https://localhost:44338")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

            services.AddAuthentication("Bearer").
                AddIdentityServerAuthentication("Bearer", opt =>
               {
                   opt.Authority = "https://localhost:44372"; // base-address of your identityserver
                   opt.ApiName = "api1"; // if you are using API resources, you can specify the name here
               });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //for global exceptions, replaced by custom exception middleware

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("AllowAllReadApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
