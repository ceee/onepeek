using System;

namespace OnePeek.Api
{
  public class OnePeekApiException : Exception
  {
    public OnePeekApiException() : base() { }
    public OnePeekApiException(string message) : base(message) { }
    public OnePeekApiException(string message, Exception innerException) : base(message, innerException) { }
  }
}
