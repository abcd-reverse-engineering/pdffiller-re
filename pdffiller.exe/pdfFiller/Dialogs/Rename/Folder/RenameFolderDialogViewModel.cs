// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Rename.Folder.RenameFolderDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using pdfFiller.Model.Pojo.Data.Structure;
using System;

#nullable disable
namespace pdfFiller.Dialogs.Rename.Folder;

public class RenameFolderDialogViewModel(ActionsHolder holder) : RenameDialogViewModel(holder)
{
  public override async void OnConfirmCommand()
  {
    RenameFolderDialogViewModel folderDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      int num = await folderDialogViewModel.dataManager.RenameFolder(folderDialogViewModel.ActionsHolder as pdfFiller.Model.Pojo.Data.Folder, folderDialogViewModel.Name) ? 1 : 0;
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TabsAndFoldersViewModel").RefreshAll();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      folderDialogViewModel.HandleError(ex);
    }
  }
}
