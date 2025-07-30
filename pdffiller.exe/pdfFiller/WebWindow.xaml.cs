// Decompiled with JetBrains decompiler
// Type: pdfFiller.WebWindow
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Web.WebView2.Core;
using pdfFiller.Dialogs;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller;

public partial class WebWindow : Window, IComponentConnector
{
  private WebWindow.DidCloseDelegate _didClose;
  private string url;
  internal pdfFiller.UI.WebView.WebView Browser;
  private bool _contentLoaded;

  public static void Show(string url, WebWindow.DidCloseDelegate didClose)
  {
    new WebWindow(url, didClose).Show();
  }

  public WebWindow(string url, WebWindow.DidCloseDelegate didClose)
  {
    this.InitializeComponent();
    this.url = url;
    this._didClose = didClose;
    this.Browser.WebViewInitializationCompletedEvent += new EventHandler<CoreWebView2InitializationCompletedEventArgs>(this.Browser_CoreWebView2InitializationCompleted);
  }

  private void Browser_Unloaded(object sender, RoutedEventArgs e)
  {
    if (this._didClose != null)
      this._didClose();
    this.Browser.Dispose();
    this.Browser = (pdfFiller.UI.WebView.WebView) null;
  }

  private void Browser_CoreWebView2InitializationCompleted(
    object sender,
    CoreWebView2InitializationCompletedEventArgs e)
  {
    if (this.Browser == null || this.Browser.CoreWebView2 == null)
      return;
    DialogFactory.ShowLoader("WebRootDialog");
    this.Browser.Source = new Uri(this.url);
    this.Activate();
    this.Topmost = true;
    this.Browser.CoreWebView2.NavigationCompleted += new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.CoreWebView2_NavigationCompleted);
  }

  private void CoreWebView2_NavigationCompleted(
    object sender,
    CoreWebView2NavigationCompletedEventArgs e)
  {
    this.Dispatcher.Invoke((Action) (() => DialogFactory.DissmisLoader("WebRootDialog")));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/webwindow.xaml", UriKind.Relative));
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
    if (connectionId == 1)
      this.Browser = (pdfFiller.UI.WebView.WebView) target;
    else
      this._contentLoaded = true;
  }

  public delegate void DidCloseDelegate();
}
