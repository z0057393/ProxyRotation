using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Domain.Manager;

public class ProxyManager : IProxyManager
{
    #region PUBLIC METHOD

    public ProxyCollection Validate(ProxyCollection proxyCollection)
    {
        return CheckProxyCollection(proxyCollection).GetAwaiter().GetResult();
    }

    #endregion


    #region PRIVATE METHOD

    //Super lent, surement un pb
    private async Task<ProxyCollection> CheckProxyCollection(ProxyCollection proxyCollection)
    {
        ProxyCollection proxyCollectionFiltered = new();
        const int parallelism = 100; 
        await Parallel.ForEachAsync(
            proxyCollection.Proxies, 
            new ParallelOptions { MaxDegreeOfParallelism = parallelism }, 
            async (proxy, _) =>
        {
            if (IsProxyWorking(proxy))
            {
                AddProxyInCollection(proxyCollectionFiltered, proxy);
            }
        });
        return proxyCollectionFiltered;
    }

    private  bool IsProxyWorking(Proxy proxy)
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
        return proxy.Ip ;
    }

    private void AddProxyInCollection(ProxyCollection proxyCollection, Proxy proxy)
    {
        proxyCollection.Proxies.Add(proxy);
    }

    #endregion
}