// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.Login.LoginViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Dialogs.ForgotPassword;
using pdfFiller.UI.AppStartUI.SignUp;
using pdfFiller.UI.Main;
using pdfFiller.Utils.Biometric;
using System;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.AppStartUI.Login;

public class LoginViewModel : UserStartFlowViewModel
{
  public SimpleCommand RouteToSignUpCommand { get; }

  public SimpleCommand RouteToForgotPasswordCommand { get; }

  public string Email => this.dataManager.GetLoginEmail();

  public LoginViewModel()
  {
    this.analyticsManager.TrackPage("authorization_login_screen");
    this.RouteToSignUpCommand = new SimpleCommand(new Action(this.GetStartedCommand));
    this.RouteToForgotPasswordCommand = new SimpleCommand(new Action(this.ForgotPasswordCommand));
  }

  public void GetStartedCommand()
  {
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new SignUpControl(), true);
  }

  public void ForgotPasswordCommand()
  {
    DIManager.AmplitudeManager.AddEvent("Forgot Password Flow Launched");
    DialogFactory.ShowDialog((UserControl) new ForgotPasswordDialog());
  }

  public async void LoadData()
  {
    LoginViewModel loginViewModel = this;
    try
    {
      DialogFactory.ShowLoader();
      BiometricState biometricState = await loginViewModel.dataManager.TryLoginViaBiometric();
      DialogFactory.DissmisLoader();
      if (biometricState.state == 2)
      {
        LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new MainControl(), true);
      }
      else
      {
        if (biometricState.state != 3)
          return;
        LifecycleEventDispatcherControl.GetInstance().ShowSnackbar(biometricState.message);
      }
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      loginViewModel.HandleError(ex);
    }
  }

  protected override async void OnCredentialsCorerct(string email, string password)
  {
    LoginViewModel loginViewModel = this;
    DialogFactory.ShowLoader();
    try
    {
      int num = await loginViewModel.dataManager.Login(email, password) ? 1 : 0;
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new MainControl(), true);
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      loginViewModel.HandleError(ex);
    }
  }

  protected override string GetMode() => "login";

  protected override int GetPassLengthAvailable() => 3;
}
