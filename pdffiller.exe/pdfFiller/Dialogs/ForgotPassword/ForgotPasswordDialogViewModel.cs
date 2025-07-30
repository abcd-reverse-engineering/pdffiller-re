// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.ForgotPassword.ForgotPasswordDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.Utils.Validators;
using pdfFiller.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.ForgotPassword;

public class ForgotPasswordDialogViewModel : BaseViewModel
{
  private ValidationRulesCollection.EmailFieldValidationRule _emailFieldValidationRule = new ValidationRulesCollection.EmailFieldValidationRule();
  private string _email;

  public string Email
  {
    get => this._email;
    set
    {
      this._email = value;
      this.NotifyProperty(nameof (Email));
    }
  }

  public bool IsEmaillCorrect { get; set; }

  public ICommand ContinueCommand { get; }

  public ICommand EmailChangedCommand { get; }

  public ForgotPasswordDialogViewModel()
  {
    this.ContinueCommand = (ICommand) new SimpleCommand(new Action(this.ForgotPassword));
    this.EmailChangedCommand = (ICommand) new RelayCommand(new Action<object>(this.OnEmailChanged));
    this._email = this.dataManager.GetLoginEmail();
    this.ValidateEmail(this.Email);
  }

  public void OnEmailChanged(object args)
  {
    this.ValidateEmail(((args as TextChangedEventArgs).Source as TextBox).Text);
  }

  private void ValidateEmail(string email)
  {
    this.IsEmaillCorrect = this._emailFieldValidationRule.checkRule(email);
    this.NotifyProperty("IsEmaillCorrect");
  }

  private async void ForgotPassword()
  {
    ForgotPasswordDialogViewModel passwordDialogViewModel = this;
    DialogFactory.HideDialog();
    DialogFactory.ShowLoader();
    try
    {
      string message = await passwordDialogViewModel.dataManager.ForgotPassword(passwordDialogViewModel.Email);
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar(message);
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      passwordDialogViewModel.HandleError(ex);
    }
  }
}
