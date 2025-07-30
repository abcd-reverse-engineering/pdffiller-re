// Decompiled with JetBrains decompiler
// Type: pdfFiller.ViewModel.Handler.ErrorDelegate
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Exceptions;
using pdfFiller.UI.AppStartUI.Login;
using pdfFiller.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.ViewModel.Handler;

public class ErrorDelegate
{
  public static void Handle(
    Exception e,
    DialogFactory.ClosingEventHandler closingEventHandler = null)
  {
    switch (e)
    {
      case TaskCanceledException _:
        break;
      case UnauthorizedException _:
        DIManager.DataProvider.Logout();
        DIManager.AmplitudeManager.deleteUserId();
        LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new LoginControl());
        LifecycleEventDispatcherControl.GetInstance().ShowSnackbar("Your current session has been expired");
        break;
      case FillerRestException _:
        if ((e as FillerRestException).ErrorTitle != null)
        {
          DialogFactory.ShowAlertMessageBox((e as FillerRestException).ErrorTitle, (e as FillerRestException).ErrorMessage, closingEventHandler);
          break;
        }
        DialogFactory.ShowAlertMessageBox((e as FillerRestException).ErrorMessage, closingEventHandler);
        break;
      case HttpRequestException _:
        DialogFactory.ShowAlertMessageBox(ResourcesUtils.GetStringResource("connection_error_title"), ResourcesUtils.GetStringResource("connection_error_message"), closingEventHandler);
        break;
      case FileUploadError _:
        DialogFactory.ShowAlertMessageBox(e.Message, closingEventHandler);
        break;
      default:
        int num = (int) MessageBox.Show(e.ToString());
        if (closingEventHandler == null)
          break;
        closingEventHandler();
        break;
    }
  }
}
