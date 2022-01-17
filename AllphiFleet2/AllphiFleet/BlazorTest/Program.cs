using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorTest.Services;

namespace BlazorTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //DI, httpclient inject
            //would also be working, but we will be using the httpclientfactory way
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<IDriverDataReadService, DriverDataReadService>(client => client.BaseAddress = new Uri("https://localhost:44334/"));
            builder.Services.AddHttpClient<IDriverDataWriteService, DriverDataWriteService>(client => client.BaseAddress = new Uri("https://localhost:44358/"));

            await builder.Build().RunAsync();
        }
    }
}
