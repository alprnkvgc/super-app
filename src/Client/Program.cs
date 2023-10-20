
using Client.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder
                          .CreateDefault(args)
                          .AddRootComponents()
                          .AddClientServices();

            await builder.Build().RunAsync();
        }
    }
}