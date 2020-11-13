using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Services;

namespace ReadApi
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

            //added Stefan (automapper toevoegen)
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); werkte niet, daarom static klasse gemaakt waarin assembly kan worden opgehaald
            //werkte niet omdat het in een ander project staat (?)

            //eerste deze manier geprobeerd, maar niet dynamisch genoeg (klassenaam veranderen bvb dan werkt het niet meer)
            //assembly van klasse chauffeurprofile ophalen
            //services.AddAutoMapper(typeof(ChauffeurProfile)); 
            
            //moet de assembly zijn uit het project dat profile bevat
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
