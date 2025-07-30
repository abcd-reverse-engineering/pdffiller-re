// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Error.ErrorDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using MaterialDesignThemes.Wpf;
using pdfFiller.Commnands;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.Error;

public class ErrorDialogViewModel : BaseViewModel
{
  private string _header = ResourcesUtils.GetStringResource("default_error_title");
  private string _message;

  public string Header
  {
    get => this._header;
    set
    {
      this._header = value;
      this.NotifyProperty(nameof (Header));
    }
  }

  public string Message
  {
    get => this._message;
    set
    {
      this._message = value;
      this.NotifyProperty(nameof (Message));
    }
  }

  public ICommand CloseCommand { get; }

  public DialogFactory.ClosingEventHandler ClosingEvent { get; set; }

  public ErrorDialogViewModel()
  {
    this.CloseCommand = (ICommand) new SimpleCommand(new Action(this.CloseDialogAndHost));
  }

  private void CloseDialogAndHost()
  {
    DialogHost.CloseDialogCommand.Execute((object) null, (IInputElement) null);
    DialogFactory.ClosingEventHandler closingEvent = this.ClosingEvent;
    if (closingEvent == null)
      return;
    closingEvent();
  }
}
