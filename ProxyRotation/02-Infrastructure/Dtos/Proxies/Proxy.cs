using Newtonsoft.Json;

namespace ProxyRotation.Infrastructure.Dtos.Proxies;

public class Proxy
{
    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("port")]
    public string Port { get; set; }
    
    [JsonProperty("protocol")]
    public string Protocol { get; set; }
}