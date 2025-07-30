// Decompiled with JetBrains decompiler
// Type: pdfFiller.ViewModel.BaseViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Analytics;
using pdfFiller.ViewModel.Handler;
using System;

#nullable disable
namespace pdfFiller.ViewModel;

public abstract class BaseViewModel : PropertyNotifier
{
  private int counter;
  private bool _isLoading;
  public DataProvider dataManager;
  public AnalyticsManager analyticsManager;

  public bool IsLoading
  {
    get => this._isLoading;
    set
    {
      if (!value)
      {
        --this.counter;
        if (this.counter == 0)
          this._isLoading = false;
      }
      else
      {
        ++this.counter;
        this._isLoading = true;
      }
      this.NotifyProperty(nameof (IsLoading));
    }
  }

  public BaseViewModel()
  {
    this.dataManager = DIManager.DataProvider;
    this.analyticsManager = DIManager.AnalyticsManager;
  }

  public void HandleError(
    Exception e,
    DialogFactory.ClosingEventHandler closingEventHandler = null)
  {
    ErrorDelegate.Handle(e, closingEventHandler);
  }
}
