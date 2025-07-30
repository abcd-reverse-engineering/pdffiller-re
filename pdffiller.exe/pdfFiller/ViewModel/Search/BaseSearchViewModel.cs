// Decompiled with JetBrains decompiler
// Type: pdfFiller.ViewModel.Search.BaseSearchViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.ViewModel.Search;

public abstract class BaseSearchViewModel : BaseViewModel, IDataProvider<string>
{
  private string _query;
  private Subject<string> _searchSubject = new Subject<string>();
  private SearchObserver<string> _searchObserver;

  public string Query
  {
    get => this._query;
    set
    {
      this._query = value;
      this.NotifyProperty(nameof (Query));
    }
  }

  public RelayCommand BackCommand { get; } = new RelayCommand((Action<object>) (e => LifecycleEventDispatcherControl.GetInstance().BackPress()));

  public RelayCommand TextChangedCommand { get; }

  public BaseSearchViewModel()
  {
    this._searchObserver = new SearchObserver<string>((IDataProvider<string>) this);
    this.TextChangedCommand = new RelayCommand(new Action<object>(this.OnTextChanged));
    this._searchSubject.DistinctUntilChanged<string>().Throttle<string>(TimeSpan.FromMilliseconds(300.0)).SubscribeOn<string>((IScheduler) Scheduler.Default).ObserveOnDispatcher<string>().Subscribe((IObserver<string>) this._searchObserver);
  }

  private void OnTextChanged(object obj)
  {
    this._searchSubject.OnNext(((obj as TextChangedEventArgs).OriginalSource as TextBox).Text);
  }

  protected abstract void OnNewQuery(string result);

  void IDataProvider<string>.OnNewQuery(string result) => this.OnNewQuery(result);
}
