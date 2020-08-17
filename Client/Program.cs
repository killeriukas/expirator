using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Client {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44331/"/*builder.HostEnvironment.BaseAddress*/) });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            await builder.Build().RunAsync();
        }
    }
}
