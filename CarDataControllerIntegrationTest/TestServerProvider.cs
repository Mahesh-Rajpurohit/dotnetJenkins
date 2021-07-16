using System;
using System.Net.Http;
using CarDataAPI.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDataControllerIntegrationTest
{
   public class TestServerProvider
   {
       private readonly TestServer _server;
        public HttpClient Client { get; set; }
       public TestServerProvider(Action<IServiceCollection> testServciesAction =null)
       {
           var webHostBuilder = new WebHostBuilder()
               .UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
               .UseStartup<Startup>()
               .ConfigureTestServices(testServciesAction ?? (collection => { }));

           _server = new TestServer(webHostBuilder);

           Client = _server.CreateClient();
       }

       public void Dispose()
       {
           _server?.Dispose();
           Client?.Dispose();
       }
   }
}
