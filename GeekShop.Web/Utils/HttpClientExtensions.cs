using System.Text.Json;

namespace GeekShop.Web.Utils;

public static class HttpClientExtensions
{
    public static async Task<T?> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Oopsie! Something went wrong! [{response.ReasonPhrase}]");
        
        var dataAsString = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}