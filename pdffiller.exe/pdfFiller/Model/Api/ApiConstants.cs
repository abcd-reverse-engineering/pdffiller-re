// Decompiled with JetBrains decompiler
// Type: pdfFiller.api.ApiConstants
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Properties;

#nullable disable
namespace pdfFiller.api;

public static class ApiConstants
{
  public const string LOGIN_PATH_SEGMENT = "login";
  public const string SIGN_UP_PATH_SEGMENT = "add";
  public const string EDITOR_LINK = "/api_v3/editor/editorProjectUrl?projectId={projectId}";
  public const string DEVICE = "windows";
  public const string APP_KEY = "vWindowsApp_v1_2";

  public static string BASE_URL
  {
    get => Settings.Default.BASE_URL;
    set
    {
      Settings.Default.BASE_URL = value;
      Settings.Default.Save();
    }
  }
}
