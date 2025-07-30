// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.PrivacyNotice.PrivacyDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.ViewModel;
using System;

#nullable disable
namespace pdfFiller.Dialogs.PrivacyNotice;

public class PrivacyDialogViewModel : BaseViewModel
{
  public string htmlContent;

  public SimpleCommand OnAccept { get; }

  public Action OnAccepted { get; set; }

  public PrivacyDialogViewModel() => this.OnAccept = new SimpleCommand(new Action(this.Accept));

  private void Accept()
  {
    DialogFactory.HideDialog();
    Action onAccepted = this.OnAccepted;
    if (onAccepted == null)
      return;
    onAccepted();
  }
}
