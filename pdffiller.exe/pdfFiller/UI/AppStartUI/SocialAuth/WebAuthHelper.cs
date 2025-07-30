// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.WebAuthHelper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Win32;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public class WebAuthHelper
{
  public const string GOOGLE_AUTH_ID = "735856531380-e58q5u16nrjapqs4ehl27gfru18h7dd4.apps.googleusercontent.com";

  private static string ParseToken(string url) => url;

  public static void RegisterUriScheme()
  {
    using (RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\pdfFiller"))
    {
      string location = typeof (App).Assembly.Location;
      subKey1.SetValue("", (object) "URL:pdfFiller Protocol");
      subKey1.SetValue("URL Protocol", (object) "");
      using (RegistryKey subKey2 = subKey1.CreateSubKey("DefaultIcon"))
        subKey2.SetValue("", (object) (location + ",1"));
      using (RegistryKey subKey3 = subKey1.CreateSubKey("shell\\open\\command"))
        subKey3.SetValue("", (object) $"\"{location}\" \"%1\"");
    }
  }
}
