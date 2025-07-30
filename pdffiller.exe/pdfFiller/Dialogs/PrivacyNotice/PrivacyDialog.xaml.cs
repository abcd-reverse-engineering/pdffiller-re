// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.PrivacyNotice.PrivacyDialog
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Web.WebView2.Core;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller.Dialogs.PrivacyNotice;

public partial class PrivacyDialog : UserControl, IComponentConnector
{
  internal pdfFiller.UI.WebView.WebView Browser;
  internal Button Accept;
  private bool _contentLoaded;

  private void Browser_Loaded(object sender, RoutedEventArgs e)
  {
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
    this.Browser.CoreWebView2.NavigateToString((this.DataContext as PrivacyDialogViewModel).htmlContent);
  }

  public PrivacyDialog() => this.InitializeComponent();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/dialogs/privacynotice/privacydialog.xaml", UriKind.Relative));
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
        this.Accept = (Button) target;
      else
        this._contentLoaded = true;
    }
    else
      this.Browser = (pdfFiller.UI.WebView.WebView) target;
  }
}
