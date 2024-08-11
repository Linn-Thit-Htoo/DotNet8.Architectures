using Newtonsoft.Json;

namespace DotNet8.Architectures.Shared;

public static class DevCode
{
    public static string ToJson(this object obj) =>
        JsonConvert.SerializeObject(obj, Formatting.Indented);

    public static T ToObject<T>(this string jsonStr) => JsonConvert.DeserializeObject<T>(jsonStr)!;
}
