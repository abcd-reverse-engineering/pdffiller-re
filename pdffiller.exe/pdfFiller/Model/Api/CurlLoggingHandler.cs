// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.CurlLoggingHandler
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Model.Api;

public class CurlLoggingHandler : DelegatingHandler
{
  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    string str = await this.BuildCurlCommand(request);
    Console.WriteLine("=== CURL ===");
    Console.WriteLine(str);
    Console.WriteLine("============");
    return await base.SendAsync(request, cancellationToken);
  }

  private async Task<string> BuildCurlCommand(HttpRequestMessage request)
  {
    StringBuilder curl = new StringBuilder();
    curl.Append("curl");
    if (request.Method != HttpMethod.Get)
      curl.Append(" -X " + request.Method.Method);
    foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) request.Headers)
    {
      foreach (string str in header.Value)
        curl.Append($" -H \"{header.Key}: {str}\"");
    }
    if (request.Content != null)
    {
      foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) request.Content.Headers)
      {
        foreach (string str in header.Value)
          curl.Append($" -H \"{header.Key}: {str}\"");
      }
      string str1 = await request.Content.ReadAsStringAsync();
      if (!string.IsNullOrWhiteSpace(str1))
      {
        curl.Append(" --data ");
        curl.Append($"'{str1.Replace("'", "'\"'\"'")}'");
      }
    }
    curl.Append($" \"{request.RequestUri}\"");
    string str2 = curl.ToString();
    curl = (StringBuilder) null;
    return str2;
  }
}
