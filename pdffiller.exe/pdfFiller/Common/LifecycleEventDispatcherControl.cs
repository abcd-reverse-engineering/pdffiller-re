// Decompiled with JetBrains decompiler
// Type: pdfFiller.common.LifecycleEventDispatcherControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.common;

internal class LifecycleEventDispatcherControl
{
  private static LifecycleEventDispatcherControl instance;
  private BackStackHandler<UserControl> BackStack = new BackStackHandler<UserControl>();

  public static LifecycleEventDispatcherControl GetInstance()
  {
    if (LifecycleEventDispatcherControl.instance == null)
      LifecycleEventDispatcherControl.instance = new LifecycleEventDispatcherControl();
    return LifecycleEventDispatcherControl.instance;
  }

  private AppLifecycleObserver<UserControl> observer { get; set; }

  public void BackPress(int steps = 1)
  {
    UserControl viewModel = (UserControl) null;
    if (steps > 1)
    {
      for (int index = 0; index < steps; ++index)
        viewModel = this.BackStack.Back();
    }
    else
      viewModel = this.BackStack.Back();
    this.observer.OnNewPage(viewModel);
  }

  public void OnNewPageAndKillCurrent(UserControl control, bool isRoot = false)
  {
    if (this.observer == null)
      return;
    if (isRoot)
      this.BackStack.Root = control;
    this.BackStack.Back();
    this.BackStack.Add(control);
    this.observer.OnNewPage(control);
  }

  public void OnNewPageAndClearStack(UserControl control)
  {
    if (this.observer == null)
      return;
    this.BackStack.Clear();
    this.BackStack.Root = control;
    this.BackStack.Add(control);
    this.observer.OnNewPage(control);
  }

  public void Activate() => this.observer.BringToFront();

  public void OnNewPage(UserControl control, bool isRoot = false)
  {
    if (this.observer == null)
      return;
    if (isRoot)
    {
      this.BackStack.Clear();
      this.BackStack.Root = control;
    }
    this.BackStack.Add(control);
    this.observer.OnNewPage(control);
  }

  public void registerObserver(AppLifecycleObserver<UserControl> observer)
  {
    this.observer = observer;
  }

  public void ShowSnackbar(string message) => this.observer.ShowSnackbar(message);
}
