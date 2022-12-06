using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace WSEvaluacion01.TestIntegracion
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            // ... Configure test services
        });

            var client = application.CreateClient();
            builder.ConfigureAppConfiguration(configurationBuider =>
            {
                var integrationConfiguracion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build;
                
                configurationBuider.AddConfiguration(integrationConfiguracion);
            });
        }

    }
}
