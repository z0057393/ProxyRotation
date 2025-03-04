using ProxyRotation.Application.Dtos.Proxies;

namespace ProxyRotation.Infrastructure.Interface;

public interface IScraperManager
{
    public Task<ProxyCollection> ScrapeIpProxy();
}