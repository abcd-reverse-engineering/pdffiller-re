// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TOS.TOSViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.Dialogs;
using pdfFiller.ViewModel;
using System;

#nullable disable
namespace pdfFiller.UI.TOS;

public class TOSViewModel : BaseViewModel
{
  public SimpleCommand OnAccept { get; }

  public TOSViewModel() => this.OnAccept = new SimpleCommand(new Action(this.Accept));

  private async void Accept()
  {
    TOSViewModel tosViewModel = this;
    DialogFactory.ShowLoader();
    try
    {
      if (await tosViewModel.dataManager.AcceptTos())
      {
        DialogFactory.DissmisLoader();
        LifecycleEventDispatcherControl.GetInstance().BackPress();
      }
      else
        DialogFactory.DissmisLoader();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      tosViewModel.HandleError(ex);
    }
  }
}
