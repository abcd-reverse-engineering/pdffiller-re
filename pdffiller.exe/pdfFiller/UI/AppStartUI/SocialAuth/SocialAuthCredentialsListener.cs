// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.SocialAuthCredentialsListener
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public interface SocialAuthCredentialsListener
{
  void OnCredentials(string userId, string token);

  string GetRedirectUrl();
}
