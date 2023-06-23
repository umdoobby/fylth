using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using Fylth.Models.Settings;
using Fylth.Models.E621;
using Fylth.Models;

namespace Fylth.Services;

public class E621Service
{
    private HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    private const string Url = "https://e621.net/{0}";

    public E621Service()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.UserAgent.Clear();
        _client.DefaultRequestHeaders.UserAgent.ParseAdd("Fylth/0.1 (by technobear on e621)");
        
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<bool> Login()
    {
        var user = "";
        var pass = "";
        if (SettingsService.Read(SettingsKeys.UseSecureStore))
        {
            user = await SettingsService.ReadSecure(SettingsKeys.E621Username);
            pass = await SettingsService.ReadSecure(SettingsKeys.E621ApiKey);
        }
        else
        {
            user = SettingsService.Read(SettingsKeys.E621Username);
            pass = SettingsService.Read(SettingsKeys.E621ApiKey);
        }

        if (string.IsNullOrWhiteSpace(user) && string.IsNullOrWhiteSpace(pass))
        {
            return false;
        }

        var tempClient = _client;
        tempClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", SettingsService.Base64Encode($"{user}:{pass}"));
        _client = tempClient;
        return true;
    }

    public void Logout()
    {
        var tempClient = _client;
        tempClient.DefaultRequestHeaders.Authorization = null;
        _client = tempClient;
    }

    public async Task<GetLoginResponse> TestLoginInfo(string username, string apiKey)
    {
        var tempClient = _client;
        tempClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", SettingsService.Base64Encode($"{username}:{apiKey}"));
        
        Uri uri = new Uri(string.Format(Url, "posts.json"));
        HttpResponseMessage response = await tempClient.GetAsync(uri);

        return new GetLoginResponse()
        {
            WasSuccessful = response.IsSuccessStatusCode,
            StatusCode = response.StatusCode,
            Response = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<List<Post>> GetPosts()
    {
        Uri uri = new Uri(string.Format(Url, "posts.json"));
        HttpResponseMessage response = await _client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var postsReply = await response.Content.ReadFromJsonAsync<GetPostsResponse>(_serializerOptions);
            return postsReply.Posts;
        }

        return new List<Post>();
    }
    
    public async Task<List<Post>> GetPostsPage(int page)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            { "page", $"{page}" }
        };

        Uri uri = new Uri(QueryHelpers.AddQueryString(string.Format(Url, "posts.json"), parameters));
        HttpResponseMessage response = await _client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var postsReply = await response.Content.ReadFromJsonAsync<GetPostsResponse>(_serializerOptions);
            return postsReply.Posts;
        }

        return new List<Post>();
    }
    
    public async Task<List<Post>> GetPostsAfterId(int id)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            { "page", $"a{id}" }
        };

        Uri uri = new Uri(QueryHelpers.AddQueryString(string.Format(Url, "posts.json"), parameters));
        HttpResponseMessage response = await _client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var postsReply = await response.Content.ReadFromJsonAsync<GetPostsResponse>(_serializerOptions);
            return postsReply.Posts;
        }

        return new List<Post>();
    }
    
    public async Task<List<Post>> GetPostsBeforeId(int id)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            { "page", $"b{id}" }
        };

        Uri uri = new Uri(QueryHelpers.AddQueryString(string.Format(Url, "posts.json"), parameters));
        HttpResponseMessage response = await _client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var postsReply = await response.Content.ReadFromJsonAsync<GetPostsResponse>(_serializerOptions);
            return postsReply.Posts;
        }

        return new List<Post>();
    }
}