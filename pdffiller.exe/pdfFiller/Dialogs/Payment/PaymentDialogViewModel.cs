// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Payment.PaymentDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using pdfFiller.Dialogs.YesNo;
using pdfFiller.Utils;
using System;

#nullable disable
namespace pdfFiller.Dialogs.Payment;

public class PaymentDialogViewModel : YesNoDialogViewModel
{
  protected override string GetMessage()
  {
    return ResourcesUtils.GetStringResource("payment_dialog_message");
  }

  protected override string GetTitle() => ResourcesUtils.GetStringResource("payment_dialog_title");

  protected override string GetYesButtonText()
  {
    return ResourcesUtils.GetStringResource("payment_dialog_yes_button");
  }

  protected override async void OnConfirmCommand()
  {
    PaymentDialogViewModel paymentDialogViewModel = this;
    DIManager.AnalyticsManager.TrackEvent("subscribe_click");
    DialogFactory.HideDialog();
    DialogFactory.ShowLoader();
    try
    {
      string url = await paymentDialogViewModel.dataManager.GetModuleV2("services") + "&utm_source=pf_win&utm_medium=desktop_app";
      paymentDialogViewModel.analyticsManager.TrackTraffic(url);
      DIManager.AmplitudeManager.AddEvent("Flow Paywall Shown");
      DialogFactory.DissmisLoader();
      WebWindow.Show(url, (WebWindow.DidCloseDelegate) (() => DIManager.AmplitudeManager.AddEvent("close_pricing_screen")));
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      paymentDialogViewModel.HandleError(ex);
    }
  }
}
