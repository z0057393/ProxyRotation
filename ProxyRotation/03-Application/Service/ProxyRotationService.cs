using ProxyRotation.Application.Interface;

namespace ProxyRotation.Application.Service
{
    public class ProxyRotationService (
        IProxyRotationManager _proxyRotationManager
    
        ) : IProxyRotationService
    {
        public void Rotate(string url)
        {
            _proxyRotationManager.Rotate(url);
        }
    }
}
