// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.SocialAuthViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Properties;
using pdfFiller.UI.Main;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public class SocialAuthViewModel : BaseViewModel
{
  private SocialAuthManager authManager;
  private bool isProcessStart;

  public string Title => this.authManager.GetTitle();

  public string Address => this.authManager.GetAuthUrl();

  public ICommand BackCommand { get; } = (ICommand) new SimpleCommand((Action) (() => LifecycleEventDispatcherControl.GetInstance().BackPress()));

  public SocialAuthViewModel(string type, string mode)
  {
    this.authManager = new SocialAuthManager(type, mode);
  }

  public async void OnCredentials(string userId, string token)
  {
    SocialAuthViewModel socialAuthViewModel = this;
    try
    {
      if (socialAuthViewModel.isProcessStart)
        return;
      socialAuthViewModel.isProcessStart = !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(token);
      DialogFactory.ShowLoader();
      int num = await socialAuthViewModel.dataManager.SocialAuth(userId, token) ? 1 : 0;
      DIManager.AmplitudeManager.Configure(userId);
      DIManager.AmplitudeManager.configureUserProperties(new Dictionary<string, object>()
      {
        {
          "Localisation",
          (object) "en"
        },
        {
          "Biometric",
          Settings.Default.IS_BIOMETRIC_ENABLED_BY_USER ? (object) "on" : (object) "off"
        }
      });
      Dictionary<string, object> eventProperties = new Dictionary<string, object>()
      {
        {
          "auth_type",
          (object) "FB"
        }
      };
      string action;
      string name;
      if (socialAuthViewModel.authManager.mode == "login")
      {
        action = "login";
        name = "User Logged In";
      }
      else
      {
        action = "sign-up";
        name = "User Registered";
      }
      socialAuthViewModel.analyticsManager.TrackLoginSignUp(action, socialAuthViewModel.authManager.type.ToLower());
      DIManager.AmplitudeManager.AddEvent(name, eventProperties);
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().OnNewPageAndClearStack((UserControl) new MainControl());
      socialAuthViewModel.isProcessStart = false;
    }
    catch (Exception ex)
    {
      socialAuthViewModel.IsLoading = false;
      DialogFactory.DissmisLoader();
      socialAuthViewModel.HandleError(ex);
    }
  }
}
