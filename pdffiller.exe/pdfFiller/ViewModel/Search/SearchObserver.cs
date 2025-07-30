// Decompiled with JetBrains decompiler
// Type: pdfFiller.ViewModel.Search.SearchObserver`1
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Dialogs;
using System;

#nullable disable
namespace pdfFiller.ViewModel.Search;

public class SearchObserver<T> : IObserver<T>
{
  private IDataProvider<T> _dataProvider;

  public SearchObserver(IDataProvider<T> dataProvider) => this._dataProvider = dataProvider;

  public void OnCompleted()
  {
  }

  public void OnError(Exception error) => DialogFactory.ShowAlertMessageBox(error.Message);

  public void OnNext(T value) => this._dataProvider.OnNewQuery(value);
}
