using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ReadApi;
using Microsoft.AspNetCore.Identity;
using AuthApi.Configuration;
using Models.Auth;

namespace AuthApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //for seeding
            services.AddTransient<RoleConfiguration>();

            //db config support identity
            //inform EF Core that our project will contain the migration code
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //var migrationAssembly = AssemblyInfoUtil.GetAssembly().GetName().Name;

            services.AddDbContext<ApplicationDbContext>(builder =>
            builder.UseSqlServer(Configuration["ConnectionString:AllphiFleetDB"], sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()/*
             //moved to db

            .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
            .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
            .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
            .AddInMemoryClients(InMemoryConfig.GetClients())
                */

            //.AddTestUsers(InMemoryConfig.GetUsers())
            //.AddProfileService<CustomProfileService>()

            //Now using asp identity users instead of IdentityServer4 testusers
            //Calling AddIdentity will change your application’s default cookie scheme to IdentityConstants.ApplicationScheme. 
            //This configures IdentityServer to use the ASP.NET Identity implementations
            //If we are working with a custom IdentityUser class, change it here
            .AddAspNetIdentity<IdentityUser>()
            .AddDeveloperSigningCredential()
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

            SeedData.EnsureUsers(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleConfiguration seeder)
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
