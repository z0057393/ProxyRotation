using ProxyRotation.Application.Dtos.Proxies;
using ProxyRotation.Infrastructure.Interface;
using Newtonsoft.Json;

namespace ProxyRotation.Infrastructure.Manager;

public class ScraperManager 
{
    public async Task<ProxyCollection> ScrapeIpProxy()
    {
        return await GetAsync();
    }

    private async Task<ProxyCollection> GetAsync()
    {
        // string url = "https://proxylist.geonode.com/api/proxy-list?limit=500&page=1&sort_by=lastChecked&sort_type=desc";
        string url = "https://api.proxyscrape.com/v4/free-proxy-list/get?request=display_proxies&proxy_format=protocolipport&format=json";
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(url);
        
        response.EnsureSuccessStatusCode();

        return DeserializeResponse(await response.Content.ReadAsStringAsync());
    }

    private ProxyCollection DeserializeResponse(string json)
    {
       return JsonConvert.DeserializeObject<ProxyCollection>(json);
    }
}