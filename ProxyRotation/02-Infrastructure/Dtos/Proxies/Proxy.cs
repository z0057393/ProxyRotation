using Newtonsoft.Json;

namespace ProxyRotation.Infrastructure.Dtos.Proxies;

public class Proxy
{
    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("port")]
    public int Port { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("protocols")]
    public List<string> Protocols { get; set; }
}