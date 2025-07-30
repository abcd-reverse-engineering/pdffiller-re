// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.YesNo.YesNoDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.YesNo;

public abstract class YesNoDialogViewModel : BaseViewModel
{
  public ICommand YesCommand { get; }

  public ICommand NoCommand { get; }

  public string Title => this.GetTitle();

  public string Message => this.GetMessage();

  public string YesButtonText => this.GetYesButtonText();

  public string NoButtonText => this.GetNoButtonText();

  protected virtual string GetYesButtonText() => ResourcesUtils.GetStringResource("confirm");

  protected virtual string GetNoButtonText() => ResourcesUtils.GetStringResource("cancel");

  public YesNoDialogViewModel()
  {
    this.YesCommand = (ICommand) new SimpleCommand(new Action(this.OnConfirmCommand));
    this.NoCommand = (ICommand) new SimpleCommand(new Action(this.OnCancelCommand));
  }

  protected virtual void OnCancelCommand() => DialogFactory.HideDialog();

  protected abstract void OnConfirmCommand();

  protected abstract string GetTitle();

  protected abstract string GetMessage();
}
