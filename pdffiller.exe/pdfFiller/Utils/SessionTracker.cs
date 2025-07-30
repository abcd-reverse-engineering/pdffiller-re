// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.SessionTracker
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using System;
using System.Windows;
using System.Windows.Threading;

#nullable disable
namespace pdfFiller.Utils;

public class SessionTracker
{
  private DispatcherTimer timer;

  public void StartSession() => DIManager.AnalyticsManager.TrackSession("start");

  public void StopSession() => DIManager.AnalyticsManager.TrackSession("start");

  public void CheckWindowState(WindowState state)
  {
    if (state == WindowState.Minimized)
      this.StartTimer();
    else
      this.StopTimer();
  }

  private void StopTimer()
  {
    if (this.timer == null || !this.timer.IsEnabled)
      return;
    this.timer.Stop();
  }

  private void StartTimer()
  {
    this.timer = new DispatcherTimer()
    {
      Interval = TimeSpan.FromMinutes(5.0)
    };
    this.timer.Tick += new EventHandler(this.Timer_Tick);
    this.timer.Start();
  }

  private void Timer_Tick(object sender, EventArgs e)
  {
    this.StopSession();
    this.timer.Stop();
    this.timer = (DispatcherTimer) null;
  }
}
