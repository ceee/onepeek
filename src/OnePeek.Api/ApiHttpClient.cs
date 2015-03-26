using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnePeek.Api
{
  /// <summary>
  /// Wrapper for the HttpClient
  /// </summary>
  internal class ApiHttpClient : IDisposable
  {
    private static ApiHttpClient instance = null;

    /// <summary>
    /// Get Singleton of ApiHttpCient
    /// </summary>
    internal static ApiHttpClient Instance { get { return instance ?? (instance = new ApiHttpClient()); } }

    /// <summary>
    /// Client for HTTP communication
    /// </summary>
    private readonly HttpClient httpClient;


    public ApiHttpClient()
    {
      httpClient = new HttpClient(new HttpClientHandler()
      {
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
      });
      httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2327.5 Safari/537.36 OPR/30.0.1812.0 (Edition developer)");
    }


    /// <summary>
    /// HTTP GET request to the specified uri
    /// </summary>
    public async Task<string> Get(Uri uri)
    {
      HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);
      return await responseMessage.Content.ReadAsStringAsync();
    }


    public void Dispose()
    {
      httpClient.Dispose();
    }
  }
}