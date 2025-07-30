// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Recents.RecentsViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus.Refresh;
using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Api;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.UI.Editor;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.Recents;

public class RecentsViewModel : BaseViewModel, RefreshConsumer
{
  public const string KEY = "RecentsViewModel";
  public ObservableCollection<Project> _recents;
  private bool _isRecntWasClicked;

  public ObservableCollection<Project> Recents
  {
    get => this._recents;
    set
    {
      this._recents = value;
      this.NotifyProperty(nameof (Recents));
    }
  }

  public ICommand RecentClickCommand { get; }

  public ICommand MenuClickCommand { get; }

  public RecentsViewModel()
  {
    this.RecentClickCommand = (ICommand) new RelayCommand(new Action<object>(this.OnRecentClick));
    DIManager.BusManager.GetRefreshDispatcherr("TabsAndFoldersViewModel").RegisterConsumer(nameof (RecentsViewModel), (RefreshConsumer) this);
  }

  private async void OnRecentClick(object item)
  {
    RecentsViewModel recentsViewModel = this;
    try
    {
      if (recentsViewModel._isRecntWasClicked || item == null)
        return;
      DialogFactory.ShowLoader();
      EditorConnector editorConnector = await recentsViewModel.dataManager.GetEditorConnector(item as Project);
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new EditorControl(editorConnector));
      recentsViewModel._isRecntWasClicked = false;
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      recentsViewModel.HandleError(ex);
    }
  }

  public async void LoadData()
  {
    RecentsViewModel recentsViewModel = this;
    recentsViewModel.IsLoading = true;
    try
    {
      List<Project> recents = await recentsViewModel.dataManager.GetRecents();
      recentsViewModel.Recents = new ObservableCollection<Project>(recents);
    }
    catch (Exception ex)
    {
      recentsViewModel.HandleError(ex);
    }
    recentsViewModel.IsLoading = false;
  }

  public void Refresh() => this.LoadData();
}
