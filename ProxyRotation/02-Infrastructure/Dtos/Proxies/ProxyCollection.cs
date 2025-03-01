using Newtonsoft.Json;

namespace ProxyRotation.Infrastructure.Dtos.Proxies;

public class ProxyCollection 
{
    [JsonProperty("data")]
    public List<Proxy> Proxies { get; set; } = new();
}