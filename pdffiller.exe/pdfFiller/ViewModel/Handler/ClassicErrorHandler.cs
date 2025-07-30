// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.Handler.ClassicErrorHandler
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json.Linq;
using pdfFiller.Exceptions;
using pdfFiller.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Model.Api.Handler;

public class ClassicErrorHandler : ErrorHandler
{
  public async Task<Exception> Handle(HttpResponseMessage response)
  {
    JObject jObject = JObject.Parse(this.TransformResponse(await response.Content.ReadAsStringAsync()));
    if (response.StatusCode == HttpStatusCode.OK)
      return !jObject.ContainsKey("result") || bool.Parse(jObject["result"].ToString()) ? (Exception) null : (Exception) new FillerRestException(this.GetMessage(jObject));
    if (response.StatusCode == HttpStatusCode.Unauthorized)
      return (Exception) new UnauthorizedException("");
    if (response.RequestMessage.RequestUri.ToString().Contains("login"))
      return (Exception) new FillerRestException(ResourcesUtils.GetStringResource("login_error_message"), ResourcesUtils.GetStringResource("login_error_title"));
    if (response.RequestMessage.RequestUri.ToString().Contains("forgotPassword"))
      return (Exception) new FillerRestException(ResourcesUtils.GetStringResource("forgot_password_error_message"), ResourcesUtils.GetStringResource("login_error_title"));
    string message = this.GetMessage(jObject);
    return message == null ? (Exception) new FillerRestException(ResourcesUtils.GetStringResource("default_error_message")) : (Exception) new FillerRestException(message);
  }

  private string TransformResponse(string response)
  {
    if (response == null)
      return "";
    try
    {
      string json = response;
      if (json.StartsWith("["))
      {
        JArray jarray = JArray.Parse(json);
        if (jarray.Count > 0)
        {
          JObject jobject = JObject.Parse(jarray[0].ToString());
          return jobject.ContainsKey("data") ? jobject["data"].ToString() : jobject.ToString();
        }
      }
    }
    catch (Exception ex)
    {
    }
    return response;
  }

  private string GetMessage(JObject jObject)
  {
    return !jObject.ContainsKey("message") ? (string) null : jObject["message"].ToString();
  }
}
