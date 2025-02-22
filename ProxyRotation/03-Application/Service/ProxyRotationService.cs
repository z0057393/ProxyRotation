using ProxyRotation.Application.Interface;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Infrastructure.Interface;

namespace ProxyRotation.Application.Service
{
    public class ProxyRotationService (
        
        IScraperService _scraperService,
        IProxyService _proxyService
        
        ) : IProxyRotationService
    {
        public void Rotate()
        {
            _scraperService.Scrape();
            _proxyService.Validate();
            _proxyService.Rotate();
        }
    }
}
