using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using ReadApi.CustomExceptionMiddleware;
using ReadApi.Extensions;
using Repositories;
using Services;
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
            //added stefan
            services.AddDbContext<AllphiFleetContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"]));

            //added stefan (addscoped voor DI van IDataRepository)
            //hier bepalen welke concrete interface hij zal gebruiken
            //services.AddScoped<IDataReadRepository<Chauffeur>, ChauffeurRepository>();

            //services.AddScoped<IDataReadRepository<Chauffeur>, DataReadRepository<Chauffeur>>();

            //als je dit gebruikt ipv addscoped voor elke entity, hoef je maar 1 lijn te typen
            //anders moet je bovenstaande addscoped voor elke entiteit gebruiken
            services.AddTransient(typeof(IDataReadRepository<>), typeof(DataReadRepository<>));

            services.AddScoped<IChauffeurService, ChauffeurService>();

            //Nlog
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //added Stefan (automapper toevoegen)
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); werkte niet, daarom static klasse gemaakt waarin assembly kan worden opgehaald
            //werkte niet omdat het in een ander project staat (?)

            //eerste deze manier geprobeerd, maar niet dynamisch genoeg (klassenaam veranderen bvb dan werkt het niet meer)
            //assembly van klasse chauffeurprofile ophalen
            //services.AddAutoMapper(typeof(ChauffeurProfile)); 
            
            //moet de assembly zijn uit het project dat profile bevat
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            //extension method uit ExceptionMiddlewareExtensions klasse
            services.ConfigureLoggerService();

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
            //app.ConfigureExceptionHandler(logger);

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
