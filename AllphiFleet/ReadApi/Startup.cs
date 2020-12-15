using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.Auth;
using NLog;
using ReadApi.CustomExceptionMiddleware;
using ReadApi.Extensions;
using ReadApi.Logging;
using ReadRepositories;
using ReadServices;
using ReadServices.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Identity;
using ReadApi.Settings;

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
                //,
                //builder => builder.MigrationsAssembly(Assembly.GetAssembly(typeof(AllphiFleetContext)).FullName)
                );
            });


            //voorbeeld identity met meer configuratie
            /*
            services.AddIdentity<User, IdentityRole>(configuration =>
            { 
                //hier kan je wachtwoord vereisten etc instellen
                configuration.User.RequireUniqueEmail = true;
                configuration.Password.RequiredLength = 10;
            })
            */

            //identity(user is onze eigen child klasse van identityuser, identityrole is de default klasse van identity zelf
            services.AddIdentity<User, IdentityRole>()
            //zeggen waar onze entity data opgeslagen zal worden
            .AddEntityFrameworkStores<AllphiFleetContext>()
            .AddDefaultTokenProviders();

            //jwt settings van in appsettings.json beschikbaar maken in onze applicatie
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            //ophalen uit appsettings.json
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            //extension method aanroepen in Extensions/AuthExtensions
            services.AddAuth(jwtSettings);

            //added stefan (addscoped voor DI van IDataRepository)
            //hier bepalen welke concrete interface hij zal gebruiken
            //services.AddScoped<IDataReadRepository<Chauffeur>, ChauffeurRepository>();

            //services.AddScoped<IDataReadRepository<Chauffeur>, DataReadRepository<Chauffeur>>();

            //als je dit gebruikt ipv addscoped voor elke entity, hoef je maar 1 lijn te typen
            //anders moet je bovenstaande addscoped voor elke entiteit gebruiken
            services.AddTransient(typeof(IDataReadRepository<>), typeof(DataReadRepository<>));

            services.AddScoped<IChauffeurService, ChauffeurService>();
            services.AddScoped<IAanvraagService, AanvraagService>();
            services.AddScoped<IAdresService, AdresService>();
            services.AddScoped<IFactuurService, FactuurService>();
            services.AddScoped<ITankkaartService, TankkaartService>();

            //Nlog
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //added Stefan (automapper toevoegen)
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); werkte niet, daarom static klasse gemaakt waarin assembly kan worden opgehaald
            //werkte niet omdat het in een ander project staat (?)

            //eerste deze manier geprobeerd, maar niet dynamisch genoeg (klassenaam veranderen bvb dan werkt het niet meer)
            //assembly van klasse chauffeurprofile ophalen
            //services.AddAutoMapper(typeof(ChauffeurProfile)); 

            //moet de assembly zijn uit het project dat profile bevat
            //moet dus assembly van services project zijn
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            //extension method uit ExceptionMiddlewareExtensions klasse
            services.ConfigureLoggerService();

            //cross origin requests enablen voor angular project
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllReadApi",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
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
            //app.ConfigureExceptionHandler(logger);

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            /*
             * identity, vervangen door onze extension method UseAuth
              enable authentication and authorization middlewares

            app.UseAuthentication();

            app.UseAuthorization();
            */

            //identity configuratie uit onze extension method
            app.UseAuth();

            //om uit angular project data te kunnen ophalen
            app.UseCors("AllowAllReadApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
