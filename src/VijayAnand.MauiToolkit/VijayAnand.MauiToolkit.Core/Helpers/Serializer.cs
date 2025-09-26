namespace VijayAnand.MauiToolkit.Core.Helpers;

using System.Text.Json;

public static class Serializer
{
    public static string ToJson<T>(this T obj, JsonSerializerOptions? options = default)
        => JsonSerializer.Serialize(obj, options);

    public static T? ToObject<T>(this string json, JsonSerializerOptions? options = default)
        => string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, options);
}
