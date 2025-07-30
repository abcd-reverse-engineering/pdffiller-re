// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.SocialAuthManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public class SocialAuthManager
{
  public const string TYPE_CONST = "type";
  public const string MODE_CONST = "mode";
  public const string FB_TYPE = "Facebook";
  public const string GOOGLE_TYPE = "Google";
  public const string GOOGLE_AUTH_START_URL_PART = "accounts/SetSID";
  public const string FB_AUTH_START_URL_PART = "en/login/close_and_redirect.htm";
  public const string LOGIN_MODE = "login";
  public const string REGISTR_MODE = "register";
  public const string REDIRECT_URL_PART = "/en/account/account_information/";
  public static string AUTH_URL = ApiConstants.BASE_URL + "/en/login.htm?auth=type&mode=mode&ref=/en/account/account_information/";
  public string type;
  public string mode;

  public SocialAuthManager(string type, string mode)
  {
    this.type = type;
    this.mode = mode;
  }

  public string GetTitle() => this.type;

  public string GetAuthUrl()
  {
    return SocialAuthManager.AUTH_URL.Replace("type", this.type).Replace("mode", this.mode);
  }
}
