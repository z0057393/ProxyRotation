using ProxyRotation.Infrastructure.Dtos.Proxies;
using ProxyRotation.Infrastructure.Interface;

namespace ProxyRotation.Infrastructure.Service
{
    public class ScraperService (
        IScraperManager _scraperManager
        ): IScraperService
    {
        public ProxyCollection Scrape()
        {
             return _scraperManager.ScrapeIpProxy().GetAwaiter().GetResult();
        }
    }
}
