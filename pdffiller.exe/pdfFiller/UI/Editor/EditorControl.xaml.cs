// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Editor.EditorControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Web.WebView2.Core;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Api;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller.UI.Editor;

public partial class EditorControl : UserControl, ConfigsCallback<EditorConfigs>, IComponentConnector
{
  private EditorConfigs _configs;
  internal TextBlock ProjectName;
  internal pdfFiller.UI.WebView.WebView Browser;
  private bool _contentLoaded;

  public EditorControl(EditorConnector connector)
  {
    connector.BuildConfigs((ConfigsCallback<EditorConfigs>) this);
    this.InitializeComponent();
  }

  public void OnConfigsReady(EditorConfigs configs) => this._configs = configs;

  private async void Browser_Loaded(object sender, RoutedEventArgs e)
  {
    EditorControl editorControl = this;
    DIManager.AnalyticsManager.TrackEvent("editor_start");
    DIManager.AmplitudeManager.AddEvent("Editor Opened");
    editorControl.Dispatcher.Invoke((Action) (() => DialogFactory.ShowLoader()));
    editorControl.Browser.WebViewInitializationCompletedEvent += new EventHandler<CoreWebView2InitializationCompletedEventArgs>(editorControl.Browser_CoreWebView2InitializationCompleted);
  }

  private void Browser_CoreWebView2InitializationCompleted(
    object sender,
    CoreWebView2InitializationCompletedEventArgs e)
  {
    if (this.Browser == null || this.Browser.CoreWebView2 == null)
      return;
    CoreWebView2 coreWebView2 = this.Browser.CoreWebView2;
    coreWebView2.WebResourceRequested += new EventHandler<CoreWebView2WebResourceRequestedEventArgs>(this.CoreWebView2_WebResourceRequested);
    coreWebView2.AddWebResourceRequestedFilter(this._configs.Url, CoreWebView2WebResourceContext.Document);
    coreWebView2.NavigationCompleted += new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.CoreWebView2_NavigationCompleted);
    coreWebView2.WebMessageReceived += new EventHandler<CoreWebView2WebMessageReceivedEventArgs>(this.CoreWebView2_WebMessageReceived);
    coreWebView2.Navigate(this._configs.Url);
    this.ProjectName.Text = this._configs.ProjectName;
  }

  private void CoreWebView2_WebMessageReceived(
    object sender,
    CoreWebView2WebMessageReceivedEventArgs e)
  {
    try
    {
      if (!e.WebMessageAsJson.Equals("\"editorDone\""))
        return;
      this.Dispatcher.Invoke((Action) (() =>
      {
        DIManager.AnalyticsManager.TrackEvent("editor_done");
        DIManager.AmplitudeManager.AddEvent("Editor Closed");
        LifecycleEventDispatcherControl.GetInstance().BackPress();
      }));
    }
    catch (Exception ex)
    {
    }
  }

  private void CoreWebView2_NavigationCompleted(
    object sender,
    CoreWebView2NavigationCompletedEventArgs e)
  {
    this.Dispatcher.Invoke((Action) (() => DialogFactory.DissmisLoader()));
    this.Browser.ExecuteScriptAsync("window.addEventListener('message', function(e) { console.log(window.chrome.webview.postMessage(e.data)); } )");
  }

  private async void CoreWebView2_WebResourceRequested(
    object sender,
    CoreWebView2WebResourceRequestedEventArgs e)
  {
    foreach (KeyValuePair<string, object> header in this._configs.Headers)
    {
      // ISSUE: reference to a compiler-generated field
      if (EditorControl.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EditorControl.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Action<CallSite, CoreWebView2HttpRequestHeaders, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetHeader", (IEnumerable<Type>) null, typeof (EditorControl), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      EditorControl.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) EditorControl.\u003C\u003Eo__7.\u003C\u003Ep__0, e.Request.Headers, header.Key, header.Value);
    }
  }

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    DialogFactory.ShowGoToMyDocsDialog();
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
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/ui/editor/editorcontrol.xaml", UriKind.Relative));
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
    switch (connectionId)
    {
      case 1:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.Button_Click);
        break;
      case 2:
        this.ProjectName = (TextBlock) target;
        break;
      case 3:
        this.Browser = (pdfFiller.UI.WebView.WebView) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
