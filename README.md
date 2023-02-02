# DingtalkRobetSDK.Netcore
一款使用C#/.NETCORE的钉钉sdk

## 1 配置群
电脑安装登录钉钉,随便找两个朋友,新建一个群(不用经过他们允许),然后新建一个
群机器人,再删除你的两个朋友就可以了,取得 webhook 和 secret.
 
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/1.png?raw=true)
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/2.png?raw=true)
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/3.png?raw=true)
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/4.png?raw=true)
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/5.png?raw=true)
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/6.png?raw=true)



成功获得AccessToken和UserSecret。

## 2 配置与使用
配置AccessToken和UserSecret到下图指定位置
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/7.png?raw=true)
根据单元测试配置代码

'''
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
'''


## 3 使用结果
![image](https://github.com/memoryfraction/DingtalkSDK.Netcore/blob/main/resources/images/8.png?raw=true)


