using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Interface
{
    public interface IProxyService
    {
        bool Validate(Proxy proxy);
        public void Rotate(Proxy proxy, string url);
    }
}
