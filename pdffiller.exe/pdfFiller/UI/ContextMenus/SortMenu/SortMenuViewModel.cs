// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.SortMenu.SortMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.ContextMenus.SortMenu;

public class SortMenuViewModel : BaseViewModel
{
  public const string KEY = "SortMenuViewModel";
  private ObservableCollection<SortMenuItem> _sortMenuItems;
  private bool _isMenuOpened;

  public ObservableCollection<SortMenuItem> SortMenuItems
  {
    get => this._sortMenuItems;
    set
    {
      this._sortMenuItems = value;
      this.NotifyProperty(nameof (SortMenuItems));
    }
  }

  public bool IsMenuOpened
  {
    get => this._isMenuOpened;
    set
    {
      this._isMenuOpened = value;
      if (!value)
        return;
      this.BuildSortItemsList(DIManager.BusManager.GetFoldersBackStackHandler(MainControlNavigationHelper.GetCurrentBusKey()).CurrentItem);
    }
  }

  public ICommand SortItemClickCommand { get; set; }

  public SortMenuViewModel()
  {
    this.SortItemClickCommand = (ICommand) new RelayCommand((Action<object>) (d =>
    {
      MenuItem menuItem = d as MenuItem;
      SortMenuItemsManager.SetSortOrderForFolder(this.dataManager, DIManager.BusManager.GetFoldersBackStackHandler(MainControlNavigationHelper.GetCurrentBusKey()).CurrentItem.id, menuItem.DataContext as SortMenuItem);
      DIManager.BusManager.GetRefreshDispatcherr(MainControlNavigationHelper.GetCurrentBusKey()).Refresh("FilesListViewModel");
      DIManager.AmplitudeManager.AddEvent("Sorting Completed");
    }));
  }

  public void BuildSortItemsList(Folder currentFolder)
  {
    List<SortMenuItem> list = new List<SortMenuItem>((IEnumerable<SortMenuItem>) SortMenuItemsManager.GetSortListForFolder(currentFolder.id));
    SortMenuItem sortOrderForFolder = SortMenuItemsManager.GetSortOrderForFolder(this.dataManager, currentFolder.id);
    foreach (SortMenuItem sortMenuItem in list)
      sortMenuItem.IsSelected = sortMenuItem.Equals((object) sortOrderForFolder);
    list.Insert(0, new SortMenuItem("", ResourcesUtils.GetStringResource("sort_by"), (string) null, (string) null, true));
    this.SortMenuItems = new ObservableCollection<SortMenuItem>(list);
  }
}
