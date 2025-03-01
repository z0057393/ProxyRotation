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
        return CheckProxyCollection(proxyCollection);
    }

    #endregion


    #region PRIVATE METHOD

    //Super lent, surement un pb
    private ProxyCollection CheckProxyCollection(ProxyCollection proxyCollection)
    {
        ProxyCollection proxyCollectionFiltered = new();
        foreach (Proxy proxy in proxyCollection.Proxies)
        {
            if (IsProxyWorking(proxy))
            {
                AddProxyInCollection(proxyCollectionFiltered, proxy);
            }
        }
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