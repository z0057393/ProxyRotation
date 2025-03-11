using System.Net;
using System.Net.NetworkInformation;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Manager;

public class ProxyManager 
{
    #region PUBLIC METHOD

    public bool Validate(Proxy proxy)
    {
        return CheckProxy(proxy);
    }

    public async Task<string> Rotate(Proxy proxyInfo, string url)
    {
        var proxy = new WebProxy(proxyInfo.Protocol + "://" + proxyInfo.Ip + ":" + proxyInfo.Port);
        var handler = new HttpClientHandler
        {
            Proxy = proxy,
            UseProxy = true
        };

        try
        {
            using (var client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromSeconds(2);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
            
                return await response.Content.ReadAsStringAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    #endregion


    #region PRIVATE METHOD

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