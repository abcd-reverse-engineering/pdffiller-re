// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.EditorConfigs
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Api;

public class EditorConfigs
{
  public const string TOKEN_KEY = "token";
  public const string DEVICE_KEY = "device";
  public const string USER_ID_KEY = "userId";
  public const string APP_KEY_KEY = "appKey";

  public EditorConfigs(string url, Dictionary<string, object> headers, string projectName)
  {
    this.Url = url;
    this.Headers = headers;
    this.ProjectName = projectName;
  }

  public string Url { get; }

  public Dictionary<string, object> Headers { get; }

  public string ProjectName { get; }
}
