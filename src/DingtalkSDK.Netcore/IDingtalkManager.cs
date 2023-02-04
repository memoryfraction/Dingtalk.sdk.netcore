using RestSharp;

namespace DingtalkSDK.Netcore
{
    public interface IDingtalkManager
    {
        Task<RestResponse> SendNotificationAsync(string content, string accessToken, string secret);
    }
}
