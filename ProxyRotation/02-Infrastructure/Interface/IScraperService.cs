using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Infrastructure.Interface
{
    public interface IScraperService
    {
        ProxyCollection Scrape();
    }
}
