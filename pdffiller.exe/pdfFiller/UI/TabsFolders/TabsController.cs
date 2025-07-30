// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.TabsController
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#nullable disable
namespace pdfFiller.UI.TabsFolders;

public class TabsController
{
  private Tab _selectedTab;

  public ObservableCollection<Tab> Tabs { get; set; } = Tab.GetTabs();

  private Action<Folder> OnFolderSelected { get; set; }

  public Tab SelectedTab
  {
    get => this._selectedTab;
    set
    {
      if (this._selectedTab != null)
      {
        this._selectedTab.ChangeIcon();
        this._selectedTab.FolderSelectedAction = (Action<Folder>) null;
      }
      this._selectedTab = value;
      this._selectedTab.ChangeIcon();
      this._selectedTab.FolderSelectedAction = this.OnFolderSelected;
      if (this._selectedTab.Folders != null)
        this._selectedTab.SelectedFolder = this._selectedTab.Folders.First<object>((Func<object, bool>) (item => item is Folder)) as Folder;
      if (value.id == 1)
        DIManager.AnalyticsManager.TrackPage("my_docs_clouds_tab");
      if (value.id != 1 && value.id != 2 && value.id != 3)
        return;
      DIManager.AmplitudeManager.AddEvent(value.id != 1 ? (value.id != 2 ? "Outbox Tab Opened" : "Inbox Tab Opened") : "Cloud Tab Opened");
    }
  }

  public TabsController(Action<Folder> onFolderSelected)
  {
    this.OnFolderSelected = onFolderSelected;
  }

  public void ProvideData(Dictionary<int, FoldersStructure> data)
  {
    foreach (Tab tab in (Collection<Tab>) this.Tabs)
    {
      FoldersStructure foldersStructure = data[tab.id];
      tab.TabCustomizer.Customize(foldersStructure, tab);
    }
    if (this.SelectedTab.SelectedFolder == null)
    {
      BackStackHandler<Folder> backStack = DIManager.BusManager.GetFoldersBackStackHandler("TabsAndFoldersViewModel");
      if (backStack.Root == null)
        this.SelectedTab.SelectedFolder = this.SelectedTab.Folders.First<object>((Func<object, bool>) (item => item is Folder)) as Folder;
      else
        this.SelectedTab.SelectedFolder = this.SelectedTab.Folders.First<object>((Func<object, bool>) (item => item is Folder && (item as Folder).id == backStack.Root.id)) as Folder;
    }
    else
      this.SelectedTab.SelectedFolder = FoldersStructureResponse.GetFolderById(this.SelectedTab.SelectedFolder.id, data[this.SelectedTab.id].folders);
  }
}
