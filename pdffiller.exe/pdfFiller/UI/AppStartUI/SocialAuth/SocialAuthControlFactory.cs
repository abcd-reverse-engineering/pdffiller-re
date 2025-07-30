// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.SocialAuthControlFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public class SocialAuthControlFactory
{
  public static UserControl Create(string type, string mode)
  {
    SocialAuthViewModel socialAuthViewModel = new SocialAuthViewModel(type, mode);
    SocialAuthControl socialAuthControl = new SocialAuthControl();
    socialAuthControl.DataContext = (object) socialAuthViewModel;
    return (UserControl) socialAuthControl;
  }
}
