// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.WebView.WebView
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Windows;

#nullable disable
namespace pdfFiller.UI.WebView;

public class WebView : Microsoft.Web.WebView2.Wpf.WebView2, IDisposable
{
  public bool _isDisposed;

  public event EventHandler<CoreWebView2InitializationCompletedEventArgs> WebViewInitializationCompletedEvent;

  public WebView() => this.Loaded += new RoutedEventHandler(this.OnLoaded);

  public async void OnLoaded(object sender, RoutedEventArgs e)
  {
    pdfFiller.UI.WebView.WebView webView = this;
    webView.CoreWebView2InitializationCompleted += new EventHandler<CoreWebView2InitializationCompletedEventArgs>(webView.WebView_CoreWebView2InitializationCompleted);
    try
    {
      CoreWebView2Environment async = await CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(Path.GetTempPath(), "pdffiller"));
      if (!webView._isDisposed)
        await webView.EnsureCoreWebView2Async(async);
      else
        Console.WriteLine("The WebView2 control was disposed before initialization could complete.");
    }
    catch (ObjectDisposedException ex)
    {
      Console.WriteLine("Failed to initialize WebView2 environment: " + ex.Message);
      Console.WriteLine(ex.StackTrace);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Failed to initialize WebView2 environment: " + ex.Message);
      Console.WriteLine(ex.StackTrace);
    }
  }

  private void WebView_CoreWebView2InitializationCompleted(
    object sender,
    CoreWebView2InitializationCompletedEventArgs e)
  {
    if (this.CoreWebView2 != null)
      this.CoreWebView2.CookieManager.DeleteAllCookies();
    EventHandler<CoreWebView2InitializationCompletedEventArgs> initializationCompletedEvent = this.WebViewInitializationCompletedEvent;
    if (initializationCompletedEvent == null)
      return;
    initializationCompletedEvent((object) this, e);
  }

  public new void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected override void Dispose(bool disposing)
  {
    if (!this._isDisposed)
    {
      if (disposing && this.CoreWebView2 != null)
      {
        this.CoreWebView2InitializationCompleted -= new EventHandler<CoreWebView2InitializationCompletedEventArgs>(this.WebView_CoreWebView2InitializationCompleted);
        this.CoreWebView2.Stop();
      }
      this._isDisposed = true;
    }
    base.Dispose(disposing);
  }

  ~WebView() => this.Dispose(false);
}
