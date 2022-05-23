﻿using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace GeekShop.Web.Utils;

public static class HttpClientExtensions
{
    private static MediaTypeHeaderValue _contentType = new MediaTypeHeaderValue("application/json");
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

    public static Task<HttpResponseMessage> PostAsJson<T>(
        this HttpClient httpClient,
        string url,
        T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = _contentType;
        return httpClient.PostAsync(url, content);
        
    }public static Task<HttpResponseMessage> PutAsJson<T>(
        this HttpClient httpClient,
        string url,
        T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = _contentType;
        return httpClient.PutAsync(url, content);
    }
}