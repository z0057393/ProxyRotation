using ProxyRotation.Application.Interface;
using ProxyRotation.Application.Manager;

namespace ProxyRotation.Application.Service
{
    public class ProxyRotationService (
        ProxyRotationManager _proxyRotationManager
    
        ) : IProxyRotationService
    {
        public string Rotate(string url)
        {
           return _proxyRotationManager.Rotate(url);
        }
    }
}
