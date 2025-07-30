// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddDocumentSearch.AddDocumentSearchControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Web.WebView2.Core;
using pdfFiller.Dialogs;
using pdfFiller.UI.AddDocumentSearch.Parser;
using pdfFiller.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller.UI.AddDocumentSearch;

public partial class AddDocumentSearchControl : UserControl, AddressListener, IComponentConnector
{
  private string _url;
  internal pdfFiller.UI.WebView.WebView Browser;
  private bool _contentLoaded;

  public AddDocumentSearchControl()
  {
    this.InitializeComponent();
    (this.DataContext as AddDocumentSearchViewModel).AddressListener = (AddressListener) this;
  }

  public async void OnAddressReady(string url)
  {
    this._url = url;
    if (this.Browser.CoreWebView2 == null)
      return;
    this.loadURL();
  }

  private void Browser_CoreWebView2InitializationCompleted(
    object sender,
    CoreWebView2InitializationCompletedEventArgs e)
  {
    if (this.Browser == null || this.Browser.CoreWebView2 == null || this._url == null)
      return;
    this.loadURL();
  }

  private void loadURL()
  {
    CoreWebView2 coreWebView2 = this.Browser.CoreWebView2;
    coreWebView2.WebResourceRequested += new EventHandler<CoreWebView2WebResourceRequestedEventArgs>(this.CoreWebView2_WebResourceRequested);
    coreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Document);
    coreWebView2.NavigationCompleted += new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.CoreWebView2_NavigationCompleted);
    coreWebView2.NavigationStarting += new EventHandler<CoreWebView2NavigationStartingEventArgs>(this.CoreWebView2_NavigationStarting);
    coreWebView2.Navigate(this._url);
  }

  private void CoreWebView2_NavigationStarting(
    object sender,
    CoreWebView2NavigationStartingEventArgs e)
  {
    if (!UrlParsersFactory.IsUrlCorrect(e.Uri))
      return;
    this.Dispatcher.Invoke((Action) (() => (this.DataContext as AddDocumentSearchViewModel).ProcessUrl(e.Uri)));
  }

  private void CoreWebView2_NavigationCompleted(
    object sender,
    CoreWebView2NavigationCompletedEventArgs e)
  {
    this.Dispatcher.Invoke((Action) (() => DialogFactory.DissmisLoader()));
  }

  private async void CoreWebView2_WebResourceRequested(
    object sender,
    CoreWebView2WebResourceRequestedEventArgs e)
  {
    e.Request.Headers.SetHeader("device", "windows");
  }

  private void Browser_Loaded(object sender, RoutedEventArgs e)
  {
    this.Dispatcher.Invoke((Action) (() => DialogFactory.ShowLoader()));
    this.Browser.WebViewInitializationCompletedEvent += new EventHandler<CoreWebView2InitializationCompletedEventArgs>(this.Browser_CoreWebView2InitializationCompleted);
  }

  private void Browser_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Browser.Dispose();
    this.Browser = (pdfFiller.UI.WebView.WebView) null;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/ui/adddocumentsearch/adddocumentsearchcontrol.xaml", UriKind.Relative));
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
}
