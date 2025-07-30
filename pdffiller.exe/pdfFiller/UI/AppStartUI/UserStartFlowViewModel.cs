// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.UserStartFlowViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.Dialogs;
using pdfFiller.Exceptions;
using pdfFiller.UI.AppStartUI.SocialAuth;
using pdfFiller.UI.Onboarding;
using pdfFiller.Utils.Validators;
using pdfFiller.Utils.Validators.Base;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.AppStartUI;

public abstract class UserStartFlowViewModel : BaseViewModel
{
  private Validator EmailValidator;
  private Validator PasswordValidator;

  public RestApiLoginCommand ButtonCommand { get; set; }

  public SimpleCommand RouteToSupportPage { get; }

  public SimpleCommand RouteToOnboardingPage { get; }

  public SimpleCommand FacebookAuth { get; }

  public SimpleCommand GoogleAuth { get; }

  public SimpleCommand TermsOfServiceCommand { get; }

  public SimpleCommand PrivacyPolicyCommand { get; }

  public UserStartFlowViewModel()
  {
    this.ButtonCommand = new RestApiLoginCommand(new Action<string[]>(this.OnButtonClicked));
    this.EmailValidator = new Validator(new List<IValidationRule>()
    {
      (IValidationRule) new ValidationRulesCollection.EmailFieldValidationRule()
    });
    this.PasswordValidator = new Validator(new List<IValidationRule>()
    {
      (IValidationRule) new ValidationRulesCollection.PasswordFieldValidationRule(this.GetPassLengthAvailable())
    });
    this.RouteToSupportPage = new SimpleCommand(new Action(this.OpenSupportPage));
    this.RouteToOnboardingPage = new SimpleCommand(new Action(this.OpenOnboardingPage));
    this.FacebookAuth = new SimpleCommand((Action) (() => LifecycleEventDispatcherControl.GetInstance().OnNewPage(SocialAuthControlFactory.Create("Facebook", this.GetMode()))));
    this.GoogleAuth = new SimpleCommand(new Action(this.Google));
    this.TermsOfServiceCommand = new SimpleCommand((Action) (() => WebWindow.Show("https://www.pdffiller.com/en/terms_of_services.htm", (WebWindow.DidCloseDelegate) null)));
    this.PrivacyPolicyCommand = new SimpleCommand((Action) (() => WebWindow.Show("https://www.pdffiller.com/en/privacy_policy.htm", (WebWindow.DidCloseDelegate) null)));
  }

  private void OpenSupportPage()
  {
  }

  private async void Google()
  {
  }

  private void OpenOnboardingPage()
  {
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new OnBoardingControl());
  }

  protected virtual async void OnCredentialsCorerct(string email, string password)
  {
  }

  protected abstract string GetMode();

  protected abstract int GetPassLengthAvailable();

  private void OnButtonClicked(string[] credentials)
  {
    string credential1 = credentials[0];
    string credential2 = credentials[1];
    this.dataManager.StoreEmail(credential1);
    try
    {
      this.EmailValidator.validate(credential1);
      this.PasswordValidator.validate(credential2);
      this.OnCredentialsCorerct(credential1, credential2);
    }
    catch (ValidationException ex)
    {
      DialogFactory.ShowAlertMessageBox(ex.Message);
    }
  }
}
