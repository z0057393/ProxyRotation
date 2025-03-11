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

    public string Rotate(string url)
    {
        return ExecuteWithProxy(url);
    }

    #endregion

    #region PRIVATE METHODS

    private string ExecuteWithProxy(string url)
    {
        string response = string.Empty;
        ValidateProxyCollection();
        Proxy proxy = proxyCollection.Next();
        Validate(proxy, url);
        try
        {
           response = _proxyService.Rotate(proxy, url);
           Remove(proxy);
        }
        catch (Exception e)
        {
            Remove(proxy);
            ExecuteWithProxy(url);

        }

        return response;
    }

    private void Validate(Proxy proxy, string url)
    {
        if (!_proxyService.Validate(proxy))
        {
           Remove(proxy);
           ExecuteWithProxy(url);

        }
    }

    private void Remove(Proxy proxy)
    {
        proxyCollection.Remove(proxy);
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