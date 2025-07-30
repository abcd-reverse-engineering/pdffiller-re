// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.JustFolders.JustFoldersViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.Bus.Refresh;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.JustFolders;

public abstract class JustFoldersViewModel : BaseViewModel, RefreshConsumer, RouterObserver
{
  public const string KEY = "JustFoldersViewModel";
  private ObservableCollection<object> _folders;
  private Folder _selectedFolder;
  private Router _navigationRouter;
  private BackStackHandler<Folder> _backStackHandler;

  public ObservableCollection<object> Folders
  {
    get => this._folders;
    set
    {
      this._folders = value;
      this.NotifyProperty(nameof (Folders));
    }
  }

  public Folder SelectedFolder
  {
    get => this._selectedFolder;
    set
    {
      this._selectedFolder = value;
      this.OnFolderSelected((object) value);
      this.NotifyProperty(nameof (SelectedFolder));
    }
  }

  protected void OnFolderSelected(object item)
  {
    if (item == null || !(item is Folder))
      return;
    this._backStackHandler.Root = item as Folder;
    this._navigationRouter.SendData("FilesListViewModel", (object) new Tuple<Folder, int>(item as Folder, this.GetBoxId()));
    this._navigationRouter.SendData("ToolbarViewModel", item);
  }

  public JustFoldersViewModel()
  {
    DIManager.BusManager.CreateRefreshDispatcher(this.GetBusManagerKey()).RegisterConsumer(nameof (JustFoldersViewModel), (RefreshConsumer) this);
    this._navigationRouter = DIManager.BusManager.CreateRouter(this.GetBusManagerKey());
    this._navigationRouter.RegisterObserver(this.GetBusManagerKey(), (RouterObserver) this);
    this._backStackHandler = DIManager.BusManager.CreateFoldersBackStackHandler(this.GetBusManagerKey());
  }

  public async void LoadData()
  {
    JustFoldersViewModel foldersViewModel = this;
    foldersViewModel.IsLoading = true;
    try
    {
      FoldersStructure foldersStructure = await foldersViewModel.GetFoldersStructure();
      foldersViewModel.Folders = new ObservableCollection<object>(foldersStructure.folders);
      foldersViewModel.SelectedFolder = foldersViewModel.SelectedFolder != null ? FoldersStructureResponse.GetFolderById(foldersViewModel.SelectedFolder.id, foldersStructure.folders) : foldersViewModel.Folders.First<object>((Func<object, bool>) (item => item is Folder)) as Folder;
    }
    catch (Exception ex)
    {
      foldersViewModel.HandleError(ex);
    }
    foldersViewModel.IsLoading = false;
  }

  public void Refresh() => this.LoadData();

  protected abstract int GetBoxId();

  protected abstract Task<FoldersStructure> GetFoldersStructure();

  protected abstract string GetBusManagerKey();

  public void ObserveData(object dataContainer)
  {
    this.SelectedFolder = dataContainer as Folder;
    this.OnFolderSelected((object) (dataContainer as Folder));
  }
}
