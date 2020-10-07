using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Routing;
using Portfolio.Shared;

namespace Portfolio.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = builder.Configuration["HttpClientBaseAddress"];
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddHttpClient<ProjectApiService>(hc => hc.BaseAddress = new Uri(baseAddress));
            //builder.Services.AddScoped<ProjectApiService>();
            builder.Services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
            });

            await builder.Build().RunAsync();
        }
    }
}
