using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Infrastructure.Interface
{
    public interface IScraperService
    {
        ProxyCollection Scrape();
    }
}
