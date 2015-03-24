using System;
using System.Net;
using System.Net.Http;

namespace OnePeek.Api
{
  /// <summary>
  /// Wrapper for the HttpClient
  /// </summary>
  internal class ApiHttpClient : IDisposable
  {
    internal static ApiHttpClient instance = null;

    /// <summary>
    /// Get Singleton of ApiHttpCient
    /// </summary>
    internal static ApiHttpClient Instance { get { return instance ?? (instance = new ApiHttpClient()); } }

    /// <summary>
    /// Client for HTTP communication
    /// </summary>
    protected readonly HttpClient httpClient;


    public ApiHttpClient()
    {
      httpClient = new HttpClient(new HttpClientHandler()
      {
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
      });
    }


    public void Dispose()
    {
      httpClient.Dispose();
    }
  }
}