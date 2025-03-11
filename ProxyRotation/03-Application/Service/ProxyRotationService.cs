using ProxyRotation.Application.Interface;

namespace ProxyRotation.Application.Service
{
    public class ProxyRotationService (
        IProxyRotationManager _proxyRotationManager
    
        ) : IProxyRotationService
    {
        public string Rotate(string url)
        {
           return _proxyRotationManager.Rotate(url);
        }
    }
}
