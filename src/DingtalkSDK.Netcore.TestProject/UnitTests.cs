using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DingtalkSDK.Netcore.TestProject
{
    [TestClass]
    public class UnitTests
    {
        // IOC
        private ServiceCollection _services;
        private string _accessToken, _secret;
        private IConfigurationRoot _configuration;

        public UnitTests()
        {
            // 依赖注入
            _services = new ServiceCollection();
            _services.AddScoped<IDingtalkService, DingtalkService>();

            // Read Secret
            _configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets<UnitTests>()
               .Build();

            _accessToken = _configuration["DingDing:accessToken"];
            _secret = _configuration["DingDing:secret"];
        }

        [TestMethod]
        public async Task TestMethod()
        {
            using (var sp = _services.BuildServiceProvider())
            {
                var dingtalkService = sp.GetRequiredService<IDingtalkService>();
                var response = await dingtalkService.SendNotificationAsync("test123",_accessToken,_secret);
                Console.WriteLine(response.Content);
                Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            }
        }
    }
}