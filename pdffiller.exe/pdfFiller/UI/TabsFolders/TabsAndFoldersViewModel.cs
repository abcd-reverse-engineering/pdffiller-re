// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.TabsAndFoldersViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.Bus.Refresh;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.UI.TabsFolders.StartBehaviour;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.TabsFolders;

public class TabsAndFoldersViewModel : BaseViewModel, RefreshConsumer, RouterObserver
{
  public const string KEY = "TabsAndFoldersViewModel";
  private Router _navigationRouter;
  private BackStackHandler<Folder> _backStackHandler;
  public FileAssociationHandler FileAssociationHandler = new FileAssociationHandler();
  private IBehaviour _myDocsBehaviour = (IBehaviour) new LoadMyDocsBehaviour();
  public TabsController TabsController;
  private ObservableCollection<object> _folders;

  public TabsAndFoldersViewModel()
  {
    this.TabsController = new TabsController(new Action<Folder>(this.OnFolderSelected));
    DIManager.BusManager.CreateRefreshDispatcher(nameof (TabsAndFoldersViewModel)).RegisterConsumer(nameof (TabsAndFoldersViewModel), (RefreshConsumer) this);
    this._navigationRouter = DIManager.BusManager.CreateRouter(nameof (TabsAndFoldersViewModel));
    this._navigationRouter.RegisterObserver(nameof (TabsAndFoldersViewModel), (RouterObserver) this);
    this._backStackHandler = DIManager.BusManager.CreateFoldersBackStackHandler(nameof (TabsAndFoldersViewModel));
  }

  public ObservableCollection<Tab> Tabs => this.TabsController.Tabs;

  public Tab SelectedTab
  {
    get => this.TabsController.SelectedTab;
    set
    {
      this.TabsController.SelectedTab = value;
      this.NotifyProperty(nameof (SelectedTab));
    }
  }

  public ObservableCollection<object> Folders
  {
    get => this._folders;
    set
    {
      this._folders = value;
      this.NotifyProperty(nameof (Folders));
    }
  }

  protected void OnFolderSelected(object item)
  {
    if (item == null || !(item is Folder))
      return;
    this._backStackHandler.Root = item as Folder;
    this._navigationRouter.SendData("FilesListViewModel", (object) new Tuple<Folder, int>(item as Folder, this.TabsController.SelectedTab.id));
    this._navigationRouter.SendData("ToolbarViewModel", item);
  }

  public async void LoadData()
  {
    TabsAndFoldersViewModel viewModel = this;
    await viewModel._myDocsBehaviour.DoOnSuccessLogin(viewModel);
    if (!viewModel.FileAssociationHandler.HasFileToUplaodOnStart())
      return;
    await new UploadFileBehaviour().DoOnSuccessLogin(viewModel);
  }

  public void Refresh() => this._myDocsBehaviour.DoOnSuccessLogin(this);

  public void ObserveData(object dataContainer)
  {
    this.SelectedTab.SelectedFolder = dataContainer as Folder;
    this.OnFolderSelected((object) (dataContainer as Folder));
  }
}
