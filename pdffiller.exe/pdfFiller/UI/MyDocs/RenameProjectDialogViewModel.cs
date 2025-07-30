// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.MyDocs.RenameProjectDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Dialogs.Rename;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.UI.MyDocs;

public class RenameProjectDialogViewModel(ActionsHolder project) : RenameDialogViewModel(project)
{
  public override string GetMessage() => ResourcesUtils.GetStringResource("rename_message");

  public override string GetTitle() => ResourcesUtils.GetStringResource("rename_title");

  public override async void OnConfirmCommand()
  {
    RenameProjectDialogViewModel projectDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      int num = await projectDialogViewModel.dataManager.RenameProject(projectDialogViewModel.ActionsHolder as Project, projectDialogViewModel.Name) ? 1 : 0;
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "rename"
        }
      });
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TabsAndFoldersViewModel").RefreshAll();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectDialogViewModel.HandleError(ex);
    }
  }
}
