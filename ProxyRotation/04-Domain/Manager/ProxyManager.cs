using System.Net.NetworkInformation;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Manager;

public class ProxyManager : IProxyManager
{
    #region PUBLIC METHOD

    public bool Validate(Proxy proxy)
    {
        return CheckProxy(proxy);
    }

    public void Rotate(Proxy proxy, string url)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region PRIVATE METHOD

    private bool CheckProxy(Proxy proxy)
    {
        return IsProxyWorking(proxy);
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

    #endregion
}