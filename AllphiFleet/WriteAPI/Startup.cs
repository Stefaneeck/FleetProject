using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WriteAPI.DataLayer.Repositories;
using WriteAPI.PipelineBehaviours;

namespace WriteAPI
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
            //nhibernate
            //var connectionString = Configuration.GetConnectionString("AllphiFleetDB");
            var connectionString = Configuration["ConnectionString:AllphiFleetDB"];
            services.AddNHibernate(connectionString);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //register all validators in the assembly that also contains startup
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            //Since we need to validate each and every request, we add it with a Transient Scope to the container
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

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
