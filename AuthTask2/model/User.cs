using Newtonsoft.Json;

namespace AuthTask2.model;

public class User
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("username")]
    public string? Username { get; set; } = null!;
    [JsonProperty("password")]
    public string? Password { get; set; } = null!;
}
