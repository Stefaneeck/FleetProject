using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WriteRepositories;
using Validation.PipelineBehaviours;

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
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //op deze manier niet afhankelijk van classenaamveranderingen zoals bij typeof manier
            services.AddMediatR(WriteServices.AssemblyInfoUtil.GetAssembly());

            //register all validators in the assembly that also contains startup
            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            //is naar andere assembly verhuist, daarom type of validationbehaviour
            //services.AddValidatorsFromAssembly(typeof(ValidationBehaviour<,>).Assembly);
            services.AddValidatorsFromAssembly(Validation.AssemblyInfoUtil.GetAssembly());

            //Since we need to validate each and every request, we add it with a Transient Scope to the container
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            //services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());

            //cross origin requests enablen voor angular project
            /*
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            */

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllWriteApi",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

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

            //cors (angular)
            //app.UseCors(options => options.AllowAnyOrigin());
            app.UseCors("AllowAllWriteApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
