// Decompiled with JetBrains decompiler
// Type: pdfFiller.MainWindow
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using MaterialDesignThemes.Wpf;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.UI.Splash;
using pdfFiller.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller;

public partial class MainWindow : Window, AppLifecycleObserver<UserControl>, IComponentConnector
{
  private SnackbarMessageQueue messageQueue;
  private SessionTracker sessionTracker;
  internal ContentControl Container;
  internal Snackbar MySnackbar;
  private bool _contentLoaded;

  public MainWindow()
  {
    this.InitializeComponent();
    this.StateChanged += new EventHandler(this.MainWindow_StateChanged);
    this.sessionTracker = new SessionTracker();
    this.Deactivated += new EventHandler(this.MainWindow_Deactivated);
    this.Activated += new EventHandler(this.MainWindow_Activated);
  }

  private void MainWindow_StateChanged(object sender, EventArgs e)
  {
    if (this.WindowState == WindowState.Normal)
      Console.WriteLine("!!! State Normal");
    else
      Console.WriteLine("!!! State Minimized");
    this.sessionTracker.CheckWindowState(this.WindowState);
    Console.WriteLine("Window has gained focus or become active.");
  }

  private void MainWindow_Deactivated(object sender, EventArgs e)
  {
    DIManager.AmplitudeManager.BecomeInactive();
    Console.WriteLine("!!! Deactivated");
  }

  private void MainWindow_Activated(object sender, EventArgs e)
  {
    DIManager.AmplitudeManager.BecomeActive();
    Console.WriteLine("!!! Activated");
  }

  public void OnNewPage(UserControl control) => this.Container.Content = (object) control;

  public void ShowSnackbar(string message) => this.messageQueue.Enqueue((object) message);

  public void BringToFront() => this.Activate();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    this.sessionTracker.StartSession();
    LifecycleEventDispatcherControl.GetInstance().registerObserver((AppLifecycleObserver<UserControl>) this);
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new SplashControl(), true);
    this.messageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(2000.0));
    this.MySnackbar.MessageQueue = this.messageQueue;
    AutoUpdateManager.StartAutoCheck();
  }

  private void DevButton_Click(object sender, RoutedEventArgs e) => DialogFactory.ShowDevDialog();

  private void Window_Unloaded(object sender, RoutedEventArgs e)
  {
    this.sessionTracker.StopSession();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/mainwindow.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        ((FrameworkElement) target).Unloaded += new RoutedEventHandler(this.Window_Unloaded);
        break;
      case 2:
        this.Container = (ContentControl) target;
        break;
      case 3:
        this.MySnackbar = (Snackbar) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
