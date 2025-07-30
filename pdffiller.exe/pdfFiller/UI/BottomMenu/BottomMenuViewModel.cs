// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.BottomMenu.BottomMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.CSharp.RuntimeBinder;
using pdfFiller.Bus;
using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.UI.Main;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.BottomMenu;

public class BottomMenuViewModel : BaseViewModel, RouterObserver
{
  public const string KEY = "BottomMenuViewModel";
  private bool _isTrashBinEnabled = true;

  public BottomMenuViewModel()
  {
    DIManager.BusManager.GetRouter(MainViewModel.KEY).RegisterObserver(nameof (BottomMenuViewModel), (RouterObserver) this);
  }

  public bool IsTrashBinEnabled
  {
    get => this._isTrashBinEnabled;
    set
    {
      this._isTrashBinEnabled = value;
      this.NotifyProperty(nameof (IsTrashBinEnabled));
    }
  }

  public ICommand TrashBinCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DIManager.BusManager.GetRouter(MainViewModel.KEY).SendData(MainViewModel.KEY, (object) MainControlContent.TRASH_BIN)));

  public ICommand FinPdfCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DIManager.BusManager.GetRouter(MainViewModel.KEY).SendData(MainViewModel.KEY, (object) MainControlContent.FIND_PDF)));

  public ICommand RefreshCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DIManager.BusManager.GetRefreshDispatcherr(MainControlNavigationHelper.GetCurrentBusKey()).RefreshAll()));

  public void ObserveData(object dataContainer)
  {
    // ISSUE: reference to a compiler-generated field
    if (BottomMenuViewModel.\u003C\u003Eo__15.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BottomMenuViewModel.\u003C\u003Eo__15.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (bool), typeof (BottomMenuViewModel)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.IsTrashBinEnabled = BottomMenuViewModel.\u003C\u003Eo__15.\u003C\u003Ep__0.Target((CallSite) BottomMenuViewModel.\u003C\u003Eo__15.\u003C\u003Ep__0, dataContainer);
  }
}
