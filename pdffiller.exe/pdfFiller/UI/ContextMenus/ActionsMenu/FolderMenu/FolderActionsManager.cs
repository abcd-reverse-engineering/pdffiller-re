// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.FolderMenu.FolderActionsManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using System;

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu.FolderMenu;

public class FolderActionsManager : ActionsManager
{
  public void OnAction(string key, Folder folder)
  {
    if (key == "DELETE" || key == "TRASH_BIN_DELETE")
      this.DeleteFolder(folder);
    if (key == "RENAME")
      this.Rename(folder);
    if (key == "TRASH_BIN_PUT_BACK")
      this.Restore(folder);
    if (!(key == "OPEN_FOLDER"))
      return;
    this.Open(folder);
  }

  private void Open(Folder folder)
  {
    if (folder.IsRoot)
    {
      DIManager.BusManager.GetRouter(MainControlNavigationHelper.GetCurrentBusKey()).SendData(MainControlNavigationHelper.GetCurrentBusKey(), (object) folder);
    }
    else
    {
      DIManager.BusManager.GetRouter(MainControlNavigationHelper.GetCurrentBusKey()).SendData("ToolbarViewModel", (object) folder);
      DIManager.BusManager.GetRouter(MainControlNavigationHelper.GetCurrentBusKey()).SendData("FilesListViewModel", (object) folder);
    }
  }

  private async void Restore(Folder folder)
  {
    FolderActionsManager folderActionsManager = this;
    try
    {
      DialogFactory.ShowLoader();
      int num = await folderActionsManager.dataManager.RestoreFolderFromTrash(folder) ? 1 : 0;
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TrashBinFoldersViewModel").RefreshAll();
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar("Success");
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      folderActionsManager.HandleError(ex);
    }
  }

  private void Rename(Folder folder) => DialogFactory.ShowRenameFolderDialog(folder);

  private void DeleteFolder(Folder folder)
  {
    DialogFactory.ShowDeleteDialog((ActionsHolder) folder);
  }
}
