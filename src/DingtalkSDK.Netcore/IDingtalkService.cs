using RestSharp;

namespace DingtalkSDK.Netcore
{
    public interface IDingtalkService
    {
        Task<RestResponse> SendNotificationAsync(string content, string accessToken, string secret);
    }
}
