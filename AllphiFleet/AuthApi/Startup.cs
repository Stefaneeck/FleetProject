using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ReadApi;

namespace AuthApi
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
            //db config support identity
            //inform EF Core that our project will contain the migration code

            //overzetten naar ef core project? (readapi)
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //var migrationAssembly = AssemblyInfoUtil.GetAssembly().GetName().Name;

            services.AddIdentityServer()/*
            .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
            .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
            .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
            .AddInMemoryClients(InMemoryConfig.GetClients())
                */
            .AddTestUsers(InMemoryConfig.GetUsers())
            .AddDeveloperSigningCredential()
            .AddProfileService<CustomProfileService>()
            .AddConfigurationStore(opt =>
                {
                    opt.ConfigureDbContext = c => c.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"],
                        sql => sql.MigrationsAssembly(migrationAssembly));
                })
            .AddOperationalStore(opt =>
                {
                    opt.ConfigureDbContext = o => o.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"],
                        sql => sql.MigrationsAssembly(migrationAssembly));
                });

                services.AddControllersWithViews();
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
