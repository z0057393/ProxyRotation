using ProxyRotation.Domain.Interface;
using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Domain.Service
{
    public class ProxyService (IProxyManager _proxyManager): IProxyService
    {
        public void Validate(ProxyCollection proxyCollection)
        {
            _proxyManager.Validate(proxyCollection);
        }
        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}
