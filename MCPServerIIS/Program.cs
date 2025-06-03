using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MCPServerIIS
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var builder = WebApplication
               .CreateBuilder(args);
            builder
             .Services
                .AddMcpServer()
                .WithHttpTransport()
                .WithToolsFromAssembly();
            var webApp = builder.Build();
            webApp.MapMcp();
            await webApp.RunAsync();
        }
    }
}