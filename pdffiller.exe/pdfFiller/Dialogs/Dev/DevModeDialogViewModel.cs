// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Dev.DevModeDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.Commnands;
using pdfFiller.ViewModel;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.Dev;

public class DevModeDialogViewModel : BaseViewModel
{
  public string URL { get; set; }

  public ICommand ConfirmCommand { get; set; }

  public ICommand EraseTokenCommand { get; set; }

  public bool IsEraseTokenChecked { get; set; }

  public DevModeDialogViewModel()
  {
    this.URL = ApiConstants.BASE_URL;
    this.ConfirmCommand = (ICommand) new SimpleCommand(new Action(this.Confirm));
    this.EraseTokenCommand = (ICommand) new SimpleCommand((Action) (() => this.dataManager.EraseToken()));
  }

  private void Confirm()
  {
    ApiConstants.BASE_URL = this.URL;
    System.Windows.Forms.Application.Restart();
    System.Windows.Application.Current.Shutdown();
  }
}
