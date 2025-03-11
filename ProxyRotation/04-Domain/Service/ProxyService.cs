using ProxyRotation.Domain.Interface;
using ProxyRotation.Application.Dtos.Proxies;
using ProxyRotation.Domain.Manager;

namespace ProxyRotation.Domain.Service
{
    public class ProxyService (
        ProxyManager _proxyManager
        ): IProxyService
    {
        public bool Validate(Proxy proxy)
        {
            return _proxyManager.Validate(proxy);
        }

        public string Rotate(Proxy proxy, string url)
        {
            return _proxyManager.Rotate(proxy, url).GetAwaiter().GetResult();
        }
    }
}
