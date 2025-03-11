using ProxyRotation.Application.Dtos.Proxies;
using ProxyRotation.Infrastructure.Interface;
using ProxyRotation.Infrastructure.Manager;

namespace ProxyRotation.Infrastructure.Service
{
    public class ScraperService (
        ScraperManager _scraperManager
        ): IScraperService
    {
        public ProxyCollection Scrape()
        {
             return _scraperManager.ScrapeIpProxy().GetAwaiter().GetResult();
        }
    }
}
