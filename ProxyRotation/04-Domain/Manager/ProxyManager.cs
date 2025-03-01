using System.Text;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Domain.Manager;

public class ProxyManager : IProxyManager
{
    #region PUBLIC METHOD

    public ProxyCollection Validate(ProxyCollection proxyCollection)
    {
        return CheckProxyCollection(proxyCollection);
    } 

    #endregion
    

    #region PRIVATE METHOD
    
    private ProxyCollection CheckProxyCollection(ProxyCollection proxyCollection)
    {
        ProxyCollection proxyCollectionFiltered = new();
        foreach (Proxy proxy in proxyCollection.Proxies)
        {
            if (proxy.Protocols[0].Equals("http"))
            {
                if (IsProxyWorkingAsync(proxy).GetAwaiter().GetResult())
                {
                    AddProxyInCollection(proxyCollectionFiltered, proxy);
                }; 
            }
            
        }
        return proxyCollectionFiltered;
    }
    private async Task<bool> IsProxyWorkingAsync(Proxy proxy)
    {
        using (var client = new HttpClient(InitHandler(proxy)))
        {
            client.Timeout = TimeSpan.FromSeconds(1);
            try
            {
                var response = await client.GetAsync("https://www.google.com");
                return ControlResponse(response);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    private HttpClientHandler InitHandler(Proxy proxy)
    {
        return new HttpClientHandler
        {
            Proxy = new System.Net.WebProxy(BuildProxyAddress(proxy)),
            UseProxy = true
        };
    }

    private string BuildProxyAddress(Proxy proxy)
    {
        return proxy.Ip + ":" + proxy.Port;
    }

    private bool ControlResponse(HttpResponseMessage response)
    {
        return response.IsSuccessStatusCode ? true : false;
    }
    
    private void AddProxyInCollection(ProxyCollection proxyCollection, Proxy proxy)
    {
        proxyCollection.Proxies.Add(proxy);
    }
    
    #endregion
}