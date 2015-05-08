namespace OnePeek.Api
{
  /// <summary>
  /// Coniguration options for the API
  /// </summary>
  public static class Configuration
  {
    /// <summary>
    /// Ratings are returned on a 1-10 scale by default.
    /// This changes it to a 1-5 scale, which is more suited for displaying it as stars.
    /// </summary>
    public static bool UseFiveStarSystem = false;

    /// <summary>
    /// Timeout for API requests in seconds.
    /// </summary>
    public static double TimeoutInSeconds = 60;
  }
}
