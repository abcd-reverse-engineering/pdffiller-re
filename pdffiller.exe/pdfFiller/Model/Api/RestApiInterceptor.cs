// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.RestApiInterceptor
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Model.Api;

public class RestApiInterceptor : DelegatingHandler
{
  private readonly string[] types;

  public RestApiInterceptor(HttpMessageHandler innerHandler = null)
  {
    HttpMessageHandler innerHandler1 = innerHandler;
    if (innerHandler1 == null)
      innerHandler1 = (HttpMessageHandler) new HttpClientHandler()
      {
        AutomaticDecompression = DecompressionMethods.GZip
      };
    // ISSUE: explicit constructor call
    base.\u002Ector(innerHandler1);
  }

  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    HttpRequestMessage httpRequestMessage = request;
    string variant = Settings.Default.VARIANT;
    if (!string.IsNullOrEmpty(variant))
    {
      string str = "Forward-Variant-pdffiller=" + variant;
      if (request.Headers.Contains("Cookie"))
      {
        List<string> list = request.Headers.GetValues("Cookie").ToList<string>();
        list.Add(str);
        request.Headers.Remove("Cookie");
        request.Headers.Add("Cookie", string.Join("; ", (IEnumerable<string>) list));
      }
      else
        request.Headers.Add("Cookie", str);
    }
    string id = Guid.NewGuid().ToString();
    string str1 = $"[{id} -   Request]";
    foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) httpRequestMessage.Headers)
      ;
    if (httpRequestMessage.Content != null)
    {
      foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) httpRequestMessage.Content.Headers)
        ;
      if (httpRequestMessage.Content is StringContent || this.IsTextBasedContentType((HttpHeaders) httpRequestMessage.Headers) || this.IsTextBasedContentType((HttpHeaders) httpRequestMessage.Content.Headers))
      {
        string str2 = await httpRequestMessage.Content.ReadAsStringAsync();
      }
    }
    DateTime now1 = DateTime.Now;
    HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    DateTime now2 = DateTime.Now;
    string str3 = $"[{id} - Response]";
    HttpResponseMessage httpResponseMessage1 = response;
    foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) httpResponseMessage1.Headers)
      ;
    if (httpResponseMessage1.Content != null)
    {
      foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) httpResponseMessage1.Content.Headers)
        ;
      if (httpResponseMessage1.Content is StringContent || httpResponseMessage1.Content is StreamContent || this.IsTextBasedContentType((HttpHeaders) httpResponseMessage1.Headers) || this.IsTextBasedContentType((HttpHeaders) httpResponseMessage1.Content.Headers))
      {
        DateTime now3 = DateTime.Now;
        string str4 = await httpResponseMessage1.Content.ReadAsStringAsync();
        DateTime now4 = DateTime.Now;
      }
    }
    HttpResponseMessage httpResponseMessage2 = response;
    id = (string) null;
    response = (HttpResponseMessage) null;
    return httpResponseMessage2;
  }

  private bool IsTextBasedContentType(HttpHeaders headers)
  {
    IEnumerable<string> values;
    if (!headers.TryGetValues("Content-Type", out values))
      return false;
    string header = string.Join(" ", values).ToLowerInvariant();
    return ((IEnumerable<string>) this.types).Any<string>((Func<string, bool>) (t => header.Contains(t)));
  }
}
