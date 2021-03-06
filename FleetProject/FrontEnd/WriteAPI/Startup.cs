using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WriteRepositories;
using Validation.PipelineBehaviours;
using MailingService;
using ReadServices;
using ReadServices.Interfaces;
using AutoMapper;
using ReadRepositories;
using Microsoft.EntityFrameworkCore;

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

            var connectionString = Configuration["ConnectionString:AllphiFleetDB"];
            services.AddNHibernate(connectionString);
            services.AddMediatR(WriteServices.AssemblyInfoUtil.GetAssembly());

            #region commentmailingservice
            //register here, not in writeservices project (writeservices project does not have a startup 
            //and it can only be used from within an other project which has a startup (in our case it is running via writeapi project), so register there (=here))
            #endregion
            services.AddMailingService();

            //register all validators in the assembly that also contains startup
            services.AddValidatorsFromAssembly(Validation.AssemblyInfoUtil.GetAssembly());

            //Since we need to validate each and every request, we add it with a Transient Scope to the container
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            #region addedForDriverServiceInjection
            //our migrations assembly is in the readrepositories project
            services.AddDbContext<AllphiFleetContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"]
                );
            });
            services.AddScoped<IDriverService, DriverService>();
            services.AddTransient(typeof(IDataReadRepository<>), typeof(DataReadRepository<>));
            //must be the assembly from the project that contains automapper profiles, in our case this is the services project
            services.AddAutoMapper(AssemblyInfoUtil.GetAssembly());
            #endregion

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
            app.UseCors("AllowAllWriteApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
