// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SignUp.SignUpViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.Dialogs;
using pdfFiller.UI.AppStartUI.Login;
using pdfFiller.UI.Main;
using System;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SignUp;

public class SignUpViewModel : UserStartFlowViewModel
{
  public SimpleCommand RouteToLoginCommand { get; }

  public SignUpViewModel()
  {
    this.analyticsManager.TrackPage("authorization_create_screen");
    this.RouteToLoginCommand = new SimpleCommand(new Action(this.RouteToLogin));
  }

  private void RouteToLogin()
  {
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new LoginControl(), true);
  }

  protected override string GetMode() => "register";

  protected override async void OnCredentialsCorerct(string email, string password)
  {
    SignUpViewModel signUpViewModel = this;
    DialogFactory.ShowLoader();
    try
    {
      int num = await signUpViewModel.dataManager.Registr(email, password) ? 1 : 0;
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new MainControl(), true);
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      signUpViewModel.HandleError(ex);
    }
  }

  protected override int GetPassLengthAvailable() => 6;
}
