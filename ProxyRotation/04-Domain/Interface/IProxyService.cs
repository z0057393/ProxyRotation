using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Domain.Interface
{
    public interface IProxyService
    {
        void Validate(ProxyCollection proxyCollection);
        void Rotate();
    }
}
