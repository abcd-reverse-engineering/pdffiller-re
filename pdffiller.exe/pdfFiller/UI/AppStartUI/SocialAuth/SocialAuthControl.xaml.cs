// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SocialAuth.SocialAuthControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json.Linq;
using pdfFiller.Dialogs;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SocialAuth;

public partial class SocialAuthControl : 
  UserControl,
  SocialAuthCredentialsListener,
  IComponentConnector
{
  internal TextBlock Title;
  internal pdfFiller.UI.WebView.WebView Browser;
  private bool _contentLoaded;

  public SocialAuthControl() => this.InitializeComponent();

  public string GetRedirectUrl() => "/en/account/account_information/";

  public void OnCredentials(string userId, string token)
  {
  }

  private void Browser_Loaded(object sender, RoutedEventArgs e)
  {
    DialogFactory.ShowLoader();
    this.Browser.WebViewInitializationCompletedEvent += new EventHandler<CoreWebView2InitializationCompletedEventArgs>(this.Browser_CoreWebView2InitializationCompleted);
  }

  private void Browser_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Browser.Dispose();
    this.Browser = (pdfFiller.UI.WebView.WebView) null;
  }

  private void Browser_CoreWebView2InitializationCompleted(
    object sender,
    CoreWebView2InitializationCompletedEventArgs e)
  {
    if (this.Browser == null || this.Browser.CoreWebView2 == null)
      return;
    CoreWebView2 coreWebView2 = this.Browser.CoreWebView2;
    coreWebView2.WebResourceRequested += new EventHandler<CoreWebView2WebResourceRequestedEventArgs>(this.CoreWebView2_WebResourceRequested);
    coreWebView2.WebResourceResponseReceived += new EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs>(this.CoreWebView2_WebResourceResponseReceived);
    coreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Document);
    coreWebView2.NavigationCompleted += new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.CoreWebView2_NavigationCompleted);
    coreWebView2.NavigationStarting += new EventHandler<CoreWebView2NavigationStartingEventArgs>(this.CoreWebView2_NavigationStarting);
    coreWebView2.Navigate((this.DataContext as SocialAuthViewModel).Address);
  }

  private void CoreWebView2_WebResourceResponseReceived(
    object sender,
    CoreWebView2WebResourceResponseReceivedEventArgs e)
  {
  }

  private async void CoreWebView2_NavigationStarting(
    object sender,
    CoreWebView2NavigationStartingEventArgs e)
  {
    SocialAuthControl socialAuthControl = this;
    if (!e.Uri.Contains("en/login/close_and_redirect.htm") && !e.Uri.Contains("accounts/SetSID"))
      return;
    socialAuthControl.Dispatcher.Invoke((Action) (() =>
    {
      this.Dispatcher.Invoke((Action) (() => DialogFactory.ShowLoader()));
      this.Browser.Visibility = Visibility.Hidden;
    }));
    Task task = await socialAuthControl.Dispatcher.InvokeAsync<Task>((Func<Task>) (async () =>
    {
      try
      {
        foreach (CoreWebView2Cookie coreWebView2Cookie in await this.Browser.CoreWebView2.CookieManager.GetCookiesAsync(e.Uri))
        {
          if (coreWebView2Cookie.Name == "api_auth")
          {
            JObject jobject = JObject.Parse(WebUtility.UrlDecode(coreWebView2Cookie.Value));
            string userId = (string) jobject["userId"];
            string token = (string) jobject["token"];
            this.Dispatcher.Invoke((Action) (() =>
            {
              this.Browser.CoreWebView2.CookieManager.DeleteAllCookies();
              (this.DataContext as SocialAuthViewModel).OnCredentials(userId, token);
            }));
          }
        }
      }
      catch (Exception ex)
      {
      }
    }));
  }

  private void CoreWebView2_NavigationCompleted(
    object sender,
    CoreWebView2NavigationCompletedEventArgs e)
  {
    if (this.Browser.Visibility != Visibility.Visible)
      return;
    DialogFactory.DissmisLoader();
  }

  private void CoreWebView2_WebResourceRequested(
    object sender,
    CoreWebView2WebResourceRequestedEventArgs e)
  {
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/ui/appstartui/socialauth/socialauthcontrol.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId != 1)
    {
      if (connectionId == 2)
        this.Browser = (pdfFiller.UI.WebView.WebView) target;
      else
        this._contentLoaded = true;
    }
    else
      this.Title = (TextBlock) target;
  }
}
