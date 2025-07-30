// Decompiled with JetBrains decompiler
// Type: pdfFiller.App
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using pdfFiller.Properties;
using pdfFiller.Utils;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

#nullable disable
namespace pdfFiller;

public partial class App : System.Windows.Application
{
  public const bool Release = true;
  private int Message;
  private Mutex Mutex;
  private bool _contentLoaded;

  private void Application_DispatcherUnhandledException(
    object sender,
    DispatcherUnhandledExceptionEventArgs e)
  {
    int num = (int) System.Windows.Forms.MessageBox.Show(e.Exception.ToString());
  }

  private void Application_Startup(object sender, StartupEventArgs e)
  {
    FileAssociationHandler.HandleOpenWithFlow();
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    string str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Local\\{{{0}}}{{{1}}}", (object) executingAssembly.GetType().GUID, (object) executingAssembly.GetName().Name);
    bool createdNew;
    this.Mutex = new Mutex(true, str, out createdNew);
    this.Message = pdfFiller.Utils.NativeMethods.RegisterWindowMessage(str);
    if (!createdNew)
    {
      this.Mutex = (Mutex) null;
      pdfFiller.Utils.NativeMethods.PostMessage(pdfFiller.Utils.NativeMethods.HWND_BROADCAST, this.Message, IntPtr.Zero, IntPtr.Zero);
      System.Windows.Application.Current.Shutdown();
    }
    else
    {
      DIManager.Inject();
      this.TrackFirstOpen();
      pdfFiller.MainWindow mainWindow = new pdfFiller.MainWindow();
      this.MainWindow = (Window) mainWindow;
      mainWindow.Show();
      HwndSource.FromHwnd(new WindowInteropHelper((Window) mainWindow).Handle).AddHook(new HwndSourceHook(this.HandleMessages));
    }
  }

  protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
  {
    DIManager.AnalyticsManager.TrackSession("end");
    base.OnSessionEnding(e);
  }

  private void Dispose(bool disposing)
  {
    if (!disposing || this.Mutex == null)
      return;
    this.Mutex.ReleaseMutex();
    this.Mutex.Close();
    this.Mutex = (Mutex) null;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  private IntPtr HandleMessages(
    IntPtr handle,
    int message,
    IntPtr wParameter,
    IntPtr lParameter,
    ref bool handled)
  {
    if (message == this.Message)
    {
      if (this.MainWindow.WindowState == WindowState.Minimized)
        this.MainWindow.WindowState = WindowState.Normal;
      bool topmost = this.MainWindow.Topmost;
      this.MainWindow.Topmost = true;
      this.MainWindow.Topmost = topmost;
    }
    return IntPtr.Zero;
  }

  protected override void OnExit(ExitEventArgs e)
  {
    this.Dispose();
    base.OnExit(e);
  }

  private void TrackFirstOpen()
  {
    if (!Settings.Default.FIRST_OPEN)
      return;
    Settings.Default.FIRST_OPEN = false;
    Settings.Default.Save();
    DIManager.AnalyticsManager.TrackInstall();
    DIManager.AmplitudeManager.AddEvent("First Open");
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    this.Startup += new StartupEventHandler(this.Application_Startup);
    this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(this.Application_DispatcherUnhandledException);
    System.Windows.Application.LoadComponent((object) this, new Uri("/pdfFiller;component/app.xaml", UriKind.Relative));
  }

  [STAThread]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public static void Main()
  {
    App app = new App();
    app.InitializeComponent();
    app.Run();
  }
}
