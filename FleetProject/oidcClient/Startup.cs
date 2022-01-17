using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace oidcClient
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
            /*
             * This tells your application to use cookie authentication for everything (the DefaultScheme).
             * So, if you call sign in, sign out, challenge, etc. then this is the scheme that will be used. 
             * This local cookie is necessary because even though you’ll be using IdentityServer to authenticate the user and create a Single Sign-On (SSO) session,
             * every individual client application will maintain its own, shorter-lived session. 
             * */

            /* hybrid flow
             * The Hybrid flow has several steps. Our client sends a request for the code and id_token to the /authorization endpoint. 
             * IdentityServer returns them to the client. Then the client validates the id_token and if it’s valid it sends another request with the code to the /token endpoint. 
             * IdentityServer issues the access_token and id_token.
                So, the client has the access_token, but it must provide that token as a Bearer token in the Authorization header
             * */

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "https://localhost:44372";
                options.ClientId = "oidcClient";
                options.ClientSecret = "mvcsecret";

                options.ResponseType = "code id_token";
                //options.UsePkce = true;
                //options.ResponseMode = "query";

                // options.CallbackPath = "/signin-oidc"; // default redirect URI

                options.Scope.Add("api1.read");
                options.SaveTokens = true;
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
