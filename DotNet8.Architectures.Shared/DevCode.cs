using Newtonsoft.Json;

namespace DotNet8.Architectures.Shared;

public static class DevCode
{
    public static string ToJson(this string str) =>
        JsonConvert.SerializeObject(str, Formatting.Indented);
}
