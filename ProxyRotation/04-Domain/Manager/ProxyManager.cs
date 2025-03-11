using System.Net;
using System.Net.NetworkInformation;
using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Manager;

public class ProxyManager
{
    #region PUBLIC METHOD

    public bool Validate(Proxy proxy)
    {
        return CheckProxy(proxy);
    }

    public Task<string> Rotate(Proxy proxyInfo, string url)
    {
       return ExecuteHttpRequest(proxyInfo, url);
    }

    #endregion


    #region PRIVATE METHOD

    private async Task<string> ExecuteHttpRequest(Proxy proxyInfo, string url)
    {
        using (var client = new HttpClient(GetHttpClientHandler(proxyInfo)))
        {
            client.Timeout = TimeSpan.FromSeconds(2);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
    private HttpClientHandler GetHttpClientHandler(Proxy proxyInfo)
    {
        return new HttpClientHandler
        {
            Proxy = GetWebProxy(proxyInfo),
            UseProxy = true
        };
    }

    private WebProxy GetWebProxy(Proxy proxyInfo)
    {
        return new WebProxy(proxyInfo.Protocol + "://" + proxyInfo.Ip + ":" + proxyInfo.Port);
    }

    private bool CheckProxy(Proxy proxy)
    {
        return IsProxyWorking(proxy);
    }

    private bool IsProxyWorking(Proxy proxy)
    {
        Ping ping = new Ping();
        try
        {
            PingReply reply = ping.Send(BuildProxyAddress(proxy), 2000);
            if (reply == null) return false;
            return true;
        }
        catch (PingException e)
        {
            return false;
        }
    }

    private string BuildProxyAddress(Proxy proxy)
    {
        return proxy.Ip;
    }

    #endregion
}