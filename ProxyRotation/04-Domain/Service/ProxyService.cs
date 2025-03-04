using ProxyRotation.Domain.Interface;
using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Service
{
    public class ProxyService (
        IProxyManager _proxyManager
        ): IProxyService
    {
        public bool Validate(Proxy proxy)
        {
            return _proxyManager.Validate(proxy);
        }

        public void Rotate(Proxy proxy, string url)
        {
            _proxyManager.Rotate(proxy, url);
        }
    }
}
