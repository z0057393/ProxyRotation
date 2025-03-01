using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Domain.Interface;

public interface IProxyManager
{
    public ProxyCollection Validate(ProxyCollection proxyCollection);
}