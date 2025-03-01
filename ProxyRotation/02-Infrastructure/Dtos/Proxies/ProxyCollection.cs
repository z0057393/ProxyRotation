using Newtonsoft.Json;

namespace ProxyRotation.Infrastructure.Dtos.Proxies;

public class ProxyCollection 
{
    [JsonProperty("proxies")]
    public List<Proxy> Proxies { get; set; } = new();
}