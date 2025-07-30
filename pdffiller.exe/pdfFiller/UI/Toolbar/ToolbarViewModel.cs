// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Toolbar.ToolbarViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.ViewModel;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.Toolbar;

public abstract class ToolbarViewModel : BaseViewModel, RouterObserver
{
  public const string KEY = "ToolbarViewModel";
  private BackStackHandler<Folder> _backStackHandler;
  private Router _navigationRouter;

  public bool IsSortButtonVisible
  {
    get
    {
      return this._backStackHandler.CurrentItem != null && this._backStackHandler.CurrentItem.count.projects != 0;
    }
  }

  public bool IsEmptyTrashVisible => this.CanEmptyTrashVisible();

  protected virtual bool CanEmptyTrashVisible() => false;

  public bool IsBackButtonVisible => this._backStackHandler.HasItems();

  public string FolderName
  {
    get
    {
      return this._backStackHandler.CurrentItem == null ? (string) null : this._backStackHandler.CurrentItem.Name;
    }
  }

  public ICommand BackCommand { get; set; }

  public ICommand EmptyTrashCommand { get; set; }

  public ToolbarViewModel()
  {
    this._backStackHandler = DIManager.BusManager.GetFoldersBackStackHandler(this.GetBusManagerKey());
    this._navigationRouter = DIManager.BusManager.GetRouter(this.GetBusManagerKey());
    this._navigationRouter.RegisterObserver(nameof (ToolbarViewModel), (RouterObserver) this);
    this.BackCommand = (ICommand) new SimpleCommand((Action) (() =>
    {
      DIManager.BusManager.GetRouter(this.GetBusManagerKey()).SendData("FilesListViewModel", (object) this._backStackHandler.Back());
      this.UpdateUI();
    }));
    this.EmptyTrashCommand = (ICommand) new SimpleCommand(new Action(this.EmptyTrash));
  }

  public void ObserveData(object dataContainer)
  {
    this._backStackHandler.Add(dataContainer as Folder);
    this.UpdateUI();
  }

  private void EmptyTrash() => DialogFactory.ShowEmptyTrashDialog();

  private void UpdateUI()
  {
    this.NotifyProperty("FolderName");
    this.NotifyProperty("IsSortButtonVisible");
    this.NotifyProperty("IsBackButtonVisible");
  }

  protected abstract string GetBusManagerKey();
}
