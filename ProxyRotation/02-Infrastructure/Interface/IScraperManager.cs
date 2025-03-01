using ProxyRotation.Infrastructure.Dtos.Proxies;

namespace ProxyRotation.Infrastructure.Interface;

public interface IScraperManager
{
    public Task<ProxyCollection> ScrapeIpProxy();
}