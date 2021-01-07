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
            //Nlog config
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //zeggen dat onze migrations assembly in het readrepositories project zit
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

            //Nlog
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); werkte niet omdat het in een ander project staat, 
            //daarom static klasse gemaakt waarin assembly kan worden opgehaald.

            //moet de assembly zijn uit het project dat profile bevat, moet dus assembly van services project zijn
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            //extension method uit ExceptionMiddlewareExtensions klasse

            services.ConfigureLoggerService();
            //cross origin requests enablen voor angular project
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllReadApi",
                    builder => builder.WithOrigins("https://localhost:44329")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());

                //Blazor app
                options.AddPolicy("AllowAllReadApi",
                    builder => builder.WithOrigins("https://localhost:44338")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

            services.AddAuthentication("Bearer").
                AddIdentityServerAuthentication("Bearer", opt =>
               {
                   //opt.RequireHttpsMetadata = false;
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

            //voor global exceptions
            //vervangen door custom exception middleware

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //om uit angular project data te kunnen ophalen
            app.UseCors("AllowAllReadApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
