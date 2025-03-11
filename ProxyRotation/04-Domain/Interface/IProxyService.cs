using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Domain.Interface
{
    public interface IProxyService
    {
        bool Validate(Proxy proxy);
        public string Rotate(Proxy proxy, string url);
    }
}
