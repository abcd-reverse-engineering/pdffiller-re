// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.ActionsMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.ContextMenus.ActionsMenu.FolderMenu;
using pdfFiller.UI.ContextMenus.ActionsMenu.ProjectMenu;
using pdfFiller.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu;

public class ActionsMenuViewModel : BaseViewModel
{
  private FolderActionsManager _folderActionsManager = new FolderActionsManager();
  private ProjectActionsManager _projectActionsManager = new ProjectActionsManager();
  private ObservableCollection<ActionMenuItem> _items;
  private bool _isMenuOpened;

  public ObservableCollection<ActionMenuItem> Items
  {
    get => this._items;
    set
    {
      this._items = value;
      this.NotifyProperty(nameof (Items));
    }
  }

  public bool IsMenuOpened
  {
    get => this._isMenuOpened;
    set => this._isMenuOpened = value;
  }

  public ICommand ActionItemClickCommand { get; set; }

  public void BuildItemsList(ActionsHolder actionsHolder)
  {
    this.Items = new ObservableCollection<ActionMenuItem>(ActionMenuItemsManager.GetItems(actionsHolder));
    this.ActionItemClickCommand = (ICommand) new RelayCommand((Action<object>) (item =>
    {
      Tuple<ActionMenuItem, ActionsHolder> tuple = item as Tuple<ActionMenuItem, ActionsHolder>;
      if (tuple.Item2 is Project)
        this._projectActionsManager.OnAction(tuple.Item1.key, tuple.Item2 as Project);
      if (!(tuple.Item2 is Folder))
        return;
      this._folderActionsManager.OnAction(tuple.Item1.key, tuple.Item2 as Folder);
    }));
  }
}
