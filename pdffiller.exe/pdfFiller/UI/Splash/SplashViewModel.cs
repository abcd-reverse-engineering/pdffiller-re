// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Splash.SplashViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.Exceptions;
using pdfFiller.UI.AppStartUI.Login;
using pdfFiller.UI.Main;
using pdfFiller.Utils.Biometric;
using pdfFiller.ViewModel;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.Splash;

public class SplashViewModel : BaseViewModel
{
  private bool _noConnection;

  public bool NoConnection
  {
    get => this._noConnection;
    set
    {
      this._noConnection = value;
      this.NotifyProperty(nameof (NoConnection));
    }
  }

  public ICommand RefreshCommand { get; set; }

  public SplashViewModel()
  {
    this.RefreshCommand = (ICommand) new SimpleCommand(new Action(this.LoadData));
  }

  public async void LoadData()
  {
    SplashViewModel splashViewModel = this;
    try
    {
      splashViewModel.NoConnection = false;
      splashViewModel.IsLoading = true;
      await splashViewModel.dataManager.CheckToken();
      splashViewModel.IsLoading = false;
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new MainControl(), true);
    }
    catch (UnauthorizedException ex)
    {
      splashViewModel.IsLoading = true;
      splashViewModel.dataManager.DisposeBiometricFlowFlag();
      BiometricState biometricState = await splashViewModel.dataManager.TryLoginViaBiometric();
      splashViewModel.IsLoading = false;
      if (biometricState.state == 2)
      {
        LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new MainControl(), true);
        return;
      }
      if (biometricState.state == 3)
        LifecycleEventDispatcherControl.GetInstance().ShowSnackbar(biometricState.message);
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new LoginControl(), true);
    }
    catch (HttpRequestException ex)
    {
      splashViewModel.IsLoading = false;
      splashViewModel.NoConnection = true;
      splashViewModel.HandleError((Exception) ex);
    }
    catch (Exception ex)
    {
      splashViewModel.IsLoading = false;
      int num = (int) MessageBox.Show(ex.ToString());
      splashViewModel.HandleError(ex);
    }
  }
}
