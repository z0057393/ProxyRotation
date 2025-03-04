using Newtonsoft.Json;

namespace ProxyRotation.Application.Dtos.Proxies;

public class ProxyCollection 
{
    [JsonProperty("proxies")]
    public List<Proxy> Proxies { get; set; } = new();

    public Proxy Next()
    {
        return Proxies.FirstOrDefault();
    }

    public void Remove(Proxy proxy)
    {
        Proxies.Remove(proxy);
    }
}