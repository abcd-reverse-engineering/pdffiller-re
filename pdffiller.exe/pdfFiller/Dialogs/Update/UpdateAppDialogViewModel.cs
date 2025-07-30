// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Update.UpdateAppDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using AutoUpdaterDotNET;
using pdfFiller.Commnands;
using pdfFiller.Properties;
using pdfFiller.Utils;
using System;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.Update;

public class UpdateAppDialogViewModel
{
  private UpdateInfoEventArgs args;

  public string Message { get; }

  public ICommand UpdateCommand { get; }

  public ICommand SkipCommand { get; }

  public ICommand RemindLaterCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DialogFactory.HideDialog("UpdateRootDialog")));

  public UpdateAppDialogViewModel(UpdateInfoEventArgs args)
  {
    this.args = args;
    this.Message = string.Format(ResourcesUtils.GetStringResource("update_dialog_message"), (object) args.CurrentVersion, (object) args.InstalledVersion);
    this.SkipCommand = (ICommand) new SimpleCommand(new Action(this.OnSkip));
    this.UpdateCommand = (ICommand) new SimpleCommand(new Action(this.OnUpdate));
  }

  private void OnSkip()
  {
    // ISSUE: variable of a compiler-generated type
    Settings settings = Settings.Default;
    settings.SKIP_VERSION = this.args.CurrentVersion;
    settings.Save();
    DialogFactory.HideDialog("UpdateRootDialog");
  }

  private void OnUpdate()
  {
    if (!AutoUpdater.DownloadUpdate(this.args))
      return;
    Application.Current.Shutdown();
  }
}
