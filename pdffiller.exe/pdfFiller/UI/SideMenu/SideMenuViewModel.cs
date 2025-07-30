// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.SideMenu.SideMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.UI.Onboarding;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.SideMenu;

public class SideMenuViewModel : BaseViewModel
{
  private bool _isCollapsed;
  private bool _isSettingsButtonVisible;

  public bool IsCollapsed
  {
    get => this._isCollapsed;
    set
    {
      this._isCollapsed = value;
      this.NotifyProperty(nameof (IsCollapsed));
    }
  }

  public bool IsSettingsButtonVisible
  {
    get => this._isSettingsButtonVisible;
    set
    {
      if (this._isSettingsButtonVisible == value)
        return;
      this._isSettingsButtonVisible = value;
      this.NotifyProperty(nameof (IsSettingsButtonVisible));
    }
  }

  public string ImageUrl
  {
    get
    {
      string userImageUrl = this.dataManager.GetUserImageUrl();
      return userImageUrl.IsNullOrEmpty<char>() ? "/pdfFiller;component/Resources/Images/empty_avatar.png" : userImageUrl;
    }
  }

  public string AppVersion => "ver.\n1.3.130";

  public string Email => this.dataManager.GetUserEmail();

  public string User => this.dataManager.GetUserFullName();

  public SimpleCommand OpenCloseMenuCommand { get; }

  public ICommand MyAccountCommand { get; }

  public ICommand SupportCommand { get; }

  public ICommand PaymentCommand { get; }

  public ICommand HelpCommand { get; } = (ICommand) new SimpleCommand((Action) (() => LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new OnBoardingControl())));

  public ICommand LogoutCommand { get; }

  public SideMenuViewModel()
  {
    this.OpenCloseMenuCommand = new SimpleCommand((Action) (() => this.IsCollapsed = !this.IsCollapsed));
    this.MyAccountCommand = (ICommand) new SimpleCommand((Action) (() => this.OpenPage("account")));
    this.SupportCommand = (ICommand) new SimpleCommand((Action) (() => this.OpenPage("support")));
    this.PaymentCommand = (ICommand) new SimpleCommand((Action) (() => this.OpenPage("services")));
    this.LogoutCommand = (ICommand) new SimpleCommand(new Action(this.Logout));
    this.IsSettingsButtonVisible = this.dataManager.IsBiometricAvailabile();
  }

  private void Logout()
  {
    this.analyticsManager.TrackSideMenuEvent("logout");
    DialogFactory.ShowLogoutDialog();
  }

  private async void OpenPage(string pageType)
  {
    SideMenuViewModel sideMenuViewModel = this;
    try
    {
      if (pageType == "services")
      {
        sideMenuViewModel.analyticsManager.TrackSideMenuEvent("pricing");
        DIManager.AmplitudeManager.AddEvent("Flow Paywall Shown");
      }
      else
        sideMenuViewModel.analyticsManager.TrackSideMenuEvent(pageType);
      DialogFactory.ShowLoader();
      string url = await sideMenuViewModel.dataManager.GetModuleV2(pageType) + "&utm_source=pf_win&utm_medium=desktop_app";
      DialogFactory.DissmisLoader();
      sideMenuViewModel.analyticsManager.TrackTraffic(url);
      if (pageType == "services")
        WebWindow.Show(url, (WebWindow.DidCloseDelegate) (() => DIManager.AmplitudeManager.AddEvent("close_pricing_screen")));
      else
        WebWindow.Show(url, (WebWindow.DidCloseDelegate) null);
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      sideMenuViewModel.HandleError(ex);
    }
  }
}
