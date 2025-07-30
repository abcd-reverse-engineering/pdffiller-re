// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.EmptyTrashBin.EmptyTrashBinDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs.YesNo;
using pdfFiller.Utils;
using System;

#nullable disable
namespace pdfFiller.Dialogs.EmptyTrashBin;

public class EmptyTrashBinDialogViewModel : YesNoDialogViewModel
{
  protected override string GetMessage()
  {
    return ResourcesUtils.GetStringResource("empty_trash_dialog_message");
  }

  protected override string GetTitle()
  {
    return ResourcesUtils.GetStringResource("empty_trash_dialog_title");
  }

  protected override string GetYesButtonText()
  {
    return ResourcesUtils.GetStringResource("empty_trash_dialog_button");
  }

  protected override async void OnConfirmCommand()
  {
    EmptyTrashBinDialogViewModel binDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      object obj = await binDialogViewModel.dataManager.EmptyTrash();
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar("Trash Bin emptied");
      DIManager.BusManager.GetRefreshDispatcherr("TrashBinFoldersViewModel").RefreshAll();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      binDialogViewModel.HandleError(ex);
    }
  }
}
