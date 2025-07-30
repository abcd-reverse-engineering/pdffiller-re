// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Logout.LogoutDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.Dialogs.YesNo;
using pdfFiller.UI.AppStartUI.Login;
using pdfFiller.Utils;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Dialogs.Logout;

public class LogoutDialogViewModel : YesNoDialogViewModel
{
  protected override string GetMessage() => ResourcesUtils.GetStringResource("logout_message");

  protected override string GetTitle() => ResourcesUtils.GetStringResource("logout_title");

  protected override string GetYesButtonText() => ResourcesUtils.GetStringResource("logout_title");

  protected override void OnConfirmCommand()
  {
    this.dataManager.Logout();
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new LoginControl(), true);
    DialogFactory.HideDialog();
  }
}
