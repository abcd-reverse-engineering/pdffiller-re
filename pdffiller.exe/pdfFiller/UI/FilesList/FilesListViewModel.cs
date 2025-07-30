// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.FilesList.FilesListViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.Bus.Refresh;
using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Api;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.UI.Editor;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.FilesList;

public abstract class FilesListViewModel : BaseViewModel, RouterObserver, RefreshConsumer
{
  public const string KEY = "FilesListViewModel";
  private Router _navigationRouter;
  private RefreshDispatcher _refreshDispatcher;
  private BackStackHandler<Folder> _backStackHandler;
  private int BoxId;
  private Folder _emptyFolder;
  private ObservableCollection<object> _data;
  private ProjectsStructure _projectsStructure;
  private object _selectedItem;
  private int _documentsCount;
  private bool IsPagging;
  protected List<CancellationTokenSource> _tokenSources = new List<CancellationTokenSource>();
  private bool _isRecentsVisible;

  public FilesListViewModel()
  {
    if (!string.IsNullOrEmpty(this.GetBusManagerKey()))
    {
      this._navigationRouter = DIManager.BusManager.GetRouter(this.GetBusManagerKey());
      this._refreshDispatcher = DIManager.BusManager.GetRefreshDispatcherr(this.GetBusManagerKey());
      this._backStackHandler = DIManager.BusManager.GetFoldersBackStackHandler(this.GetBusManagerKey());
      if (this._refreshDispatcher != null)
        this._refreshDispatcher.RegisterConsumer(nameof (FilesListViewModel), (RefreshConsumer) this);
      if (this._navigationRouter != null)
        this._navigationRouter.RegisterObserver(nameof (FilesListViewModel), (RouterObserver) this);
    }
    this.ScrollCommand = new RelayCommand(new Action<object>(this.OnScroll));
    this.ItemClickCommand = new RelayCommand(new Action<object>(this.OnItemClick));
  }

  public Folder EmptyFolder
  {
    get => this._emptyFolder;
    set
    {
      this._emptyFolder = value;
      this.NotifyProperty(nameof (EmptyFolder));
    }
  }

  public ObservableCollection<object> Data
  {
    get => this._data;
    set
    {
      this._data = value;
      this.NotifyProperty(nameof (Data));
    }
  }

  protected ProjectsStructure ProjectsStructure
  {
    get => this._projectsStructure;
    set => this._projectsStructure = value;
  }

  public object SelectedItem
  {
    get => this._selectedItem;
    set
    {
      this._selectedItem = value;
      this.NotifyProperty(nameof (SelectedItem));
    }
  }

  public int DocumentsCount
  {
    get => this._documentsCount;
    set
    {
      this._documentsCount = value;
      this.NotifyProperty(nameof (DocumentsCount));
    }
  }

  public RelayCommand ItemClickCommand { get; set; }

  public RelayCommand ScrollCommand { get; }

  private async void OnScroll(object parameter)
  {
    FilesListViewModel filesListViewModel = this;
    if (!(parameter is ScrollChangedEventArgs changedEventArgs))
      return;
    ScrollViewer originalSource = changedEventArgs.OriginalSource as ScrollViewer;
    if (originalSource.VerticalOffset != originalSource.ScrollableHeight || filesListViewModel.ProjectsStructure == null || !filesListViewModel.ProjectsStructure.HasNexPage() || filesListViewModel.IsPagging || filesListViewModel.Data.IsNullOrEmpty<object>())
      return;
    filesListViewModel.IsPagging = filesListViewModel.IsLoading = true;
    try
    {
      filesListViewModel.Dispose();
      CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
      filesListViewModel._tokenSources.Add(cancellationTokenSource);
      ProjectsStructure projectsStructure = await filesListViewModel.Paginate(filesListViewModel.ProjectsStructure, cancellationTokenSource.Token);
      filesListViewModel.ProjectsStructure = projectsStructure;
      List<object> list = new List<object>((IEnumerable<object>) filesListViewModel.Data).Concat<object>((IEnumerable<object>) projectsStructure.projects).ToList<object>();
      filesListViewModel.Data = new ObservableCollection<object>(list);
    }
    catch (ApiException ex)
    {
      filesListViewModel.HandleError((Exception) ex);
    }
    filesListViewModel.IsPagging = filesListViewModel.IsLoading = false;
  }

  protected virtual Task<ProjectsStructure> Paginate(
    ProjectsStructure projectsStructure,
    CancellationToken cancellationToken)
  {
    return this.dataManager.GetProjects(this._backStackHandler.CurrentItem.id, new int?(this.BoxId), projectsStructure.GetNexPage(), cancellationToken);
  }

  public bool IsRecentsVisible
  {
    get => this._isRecentsVisible;
    set
    {
      this._isRecentsVisible = value;
      if (value && this._refreshDispatcher != null)
        this._refreshDispatcher.Refresh("RecentsViewModel");
      this.NotifyProperty(nameof (IsRecentsVisible));
    }
  }

  public virtual void ObserveData(object data)
  {
    Folder folder;
    if (data is Tuple<Folder, int>)
    {
      Tuple<Folder, int> tuple = data as Tuple<Folder, int>;
      folder = tuple.Item1;
      this.BoxId = tuple.Item2;
    }
    else
      folder = data as Folder;
    if (folder == null)
      folder = !this._backStackHandler.HasItems() ? this._backStackHandler.Root : this._backStackHandler.Back();
    this.LoadStructure<Tuple<long, int>>(new Tuple<long, int>(folder.id, this.BoxId));
  }

  public void Refresh()
  {
    this.LoadStructure<Tuple<long, int>>(new Tuple<long, int>(this._backStackHandler.CurrentItem.id, this.BoxId));
  }

  protected virtual async void LoadStructure<T>(T data)
  {
    FilesListViewModel filesListViewModel = this;
    filesListViewModel.IsLoading = true;
    filesListViewModel.Dispose();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    CancellationTokenSource _tokenSourceFolders = new CancellationTokenSource();
    filesListViewModel._tokenSources.Add(cancellationTokenSource);
    filesListViewModel._tokenSources.Add(_tokenSourceFolders);
    try
    {
      filesListViewModel.EmptyFolder = (Folder) null;
      filesListViewModel.IsRecentsVisible = filesListViewModel.IsRecentsCanBeVisible() && filesListViewModel._backStackHandler != null && filesListViewModel._backStackHandler.CurrentItem.id == -20L;
      ProjectsStructure projectsStructure = await filesListViewModel.GetProjectsStructure<T>(data, cancellationTokenSource.Token);
      filesListViewModel.ProjectsStructure = projectsStructure;
      List<Folder> subFolders = new List<Folder>();
      if (filesListViewModel._backStackHandler != null && (!filesListViewModel._backStackHandler.CurrentItem.IsSystem || filesListViewModel._backStackHandler.CurrentItem.id == -2L || filesListViewModel._backStackHandler.CurrentItem.id == -7L))
      {
        FoldersStructureResponse foldersStructure = await filesListViewModel.GetFoldersStructure(_tokenSourceFolders.Token);
        Folder folder = await Task.Run<Folder>((Func<Folder>) (() => this.GetFolderById<T>(data, foldersStructure)));
        if (folder.subFolders != null)
          subFolders = folder.subFolders.Values.ToList<Folder>();
      }
      List<object> objectList = new List<object>();
      if (subFolders != null && !subFolders.IsNullOrEmpty<Folder>())
        objectList.AddRange((IEnumerable<object>) subFolders);
      if (!filesListViewModel.ProjectsStructure.projects.IsNullOrEmpty<pdfFiller.Model.Pojo.Data.Project>())
        objectList.AddRange((IEnumerable<object>) filesListViewModel.ProjectsStructure.projects);
      if (objectList.IsNullOrEmpty<object>())
      {
        filesListViewModel.Data = new ObservableCollection<object>();
        filesListViewModel.EmptyFolder = filesListViewModel.GetEmptyFolder();
        filesListViewModel.DocumentsCount = 0;
      }
      else
      {
        filesListViewModel.Data = new ObservableCollection<object>(objectList);
        filesListViewModel.EmptyFolder = (Folder) null;
        filesListViewModel.DocumentsCount = filesListViewModel.ProjectsStructure.projectsCount;
      }
      subFolders = (List<Folder>) null;
    }
    catch (Exception ex)
    {
      filesListViewModel.HandleError(ex);
    }
    filesListViewModel.IsLoading = false;
    _tokenSourceFolders = (CancellationTokenSource) null;
  }

  private async void OnItemClick(object item)
  {
    FilesListViewModel filesListViewModel = this;
    if (item is Folder)
    {
      Folder data = item as Folder;
      if (filesListViewModel._navigationRouter != null)
        filesListViewModel._navigationRouter.SendData("ToolbarViewModel", (object) data);
      filesListViewModel.LoadStructure<Tuple<long, int>>(new Tuple<long, int>(data.id, filesListViewModel.BoxId));
    }
    if (!(item is pdfFiller.Model.Pojo.Data.Project) || !filesListViewModel.CanOpenProject())
      return;
    pdfFiller.Model.Pojo.Data.Project project = item as pdfFiller.Model.Pojo.Data.Project;
    if (project.IsL2F)
    {
      DialogFactory.ShowAlertMessageBox(ResourcesUtils.GetStringResource("l2f_go_to_web_title"), ResourcesUtils.GetStringResource("l2f_go_to_web_message"));
    }
    else
    {
      if (project.IsTemplate)
        return;
      if (project.IsSuggestedDocument)
        return;
      try
      {
        DialogFactory.ShowLoader();
        EditorConnector editorConnector = await filesListViewModel.dataManager.GetEditorConnector(project);
        DialogFactory.DissmisLoader();
        LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new EditorControl(editorConnector));
      }
      catch (Exception ex)
      {
        DialogFactory.DissmisLoader();
        filesListViewModel.HandleError(ex);
      }
    }
  }

  protected void Dispose()
  {
    if (this._tokenSources.IsNullOrEmpty<CancellationTokenSource>())
      return;
    foreach (CancellationTokenSource tokenSource in this._tokenSources)
    {
      if (tokenSource.Token.CanBeCanceled)
        tokenSource.Cancel();
    }
    this._tokenSources.Clear();
  }

  protected virtual Folder GetEmptyFolder()
  {
    return this._backStackHandler == null ? (Folder) null : this._backStackHandler.CurrentItem;
  }

  protected virtual Task<ProjectsStructure> GetProjectsStructure<T>(
    T data,
    CancellationToken cancellationToken)
  {
    Tuple<long, int> tuple = (object) data as Tuple<long, int>;
    return this.dataManager.GetProjects(tuple.Item1, new int?(tuple.Item2), 1, cancellationToken);
  }

  protected virtual Task<FoldersStructureResponse> GetFoldersStructure(
    CancellationToken cancellationToken)
  {
    return this.dataManager.GetFoldersStructure(0L, cancellationToken);
  }

  protected virtual Folder GetFolderById<T>(T data, FoldersStructureResponse foldersStructure)
  {
    return FoldersStructureResponse.GetFolderById(((object) data as Tuple<long, int>).Item1, new List<object>((IEnumerable<object>) foldersStructure.rows.folders.Values));
  }

  protected abstract string GetBusManagerKey();

  protected abstract bool CanOpenProject();

  protected virtual bool IsRecentsCanBeVisible() => true;
}
