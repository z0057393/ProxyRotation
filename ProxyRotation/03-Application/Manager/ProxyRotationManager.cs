using ProxyRotation.Application.Dtos.Proxies;
using ProxyRotation.Application.Interface;
using ProxyRotation.Domain.Interface;
using ProxyRotation.Infrastructure.Interface;

namespace ProxyRotation.Application.Manager;

public class ProxyRotationManager(
    IScraperService _scraperService,
    IProxyService _proxyService
) : IProxyRotationManager
{
    ProxyCollection proxyCollection { get; set; }

    #region PUBLIC METHODS

    public void Rotate(string url)
    {
        ExecuteWithProxy(url);
    }

    #endregion

    #region PRIVATE METHODS

    private void ExecuteWithProxy(string url)
    {
        ValidateProxyCollection();
        Proxy proxy = proxyCollection.Next();
        Validate(proxy, url);
        _proxyService.Rotate(proxy, url);
    }

    private void Validate(Proxy proxy, string url)
    {
        if (!_proxyService.Validate(proxy))
        {
            proxyCollection.Remove(proxy);
            ExecuteWithProxy(url);
        }
    }

    private void ValidateProxyCollection()
    {
        if (ProxyCollectionIsNullOrEmpty())
        {
            proxyCollection = _scraperService.Scrape();
        }
    }

    private bool ProxyCollectionIsNullOrEmpty()
    {
        if (proxyCollection is null || proxyCollection.Proxies.Count == 0)
        {
            return true;
        }

        return false;
    }

    #endregion
}