// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Rename.Folder.RenameTemplateDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Model.Api;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.Editor;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Dialogs.Rename.Folder;

public class RenameTemplateDialogViewModel(ActionsHolder project) : RenameDialogViewModel(project)
{
  public override string GetMessage()
  {
    return ResourcesUtils.GetStringResource("create_from_template_message");
  }

  public override string GetTitle()
  {
    return ResourcesUtils.GetStringResource("create_from_template_title");
  }

  public override async void OnConfirmCommand()
  {
    RenameTemplateDialogViewModel templateDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      EditorConnector connector = await templateDialogViewModel.dataManager.CopyTemplate(templateDialogViewModel.ActionsHolder as Project, templateDialogViewModel.Name);
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "create_from_template"
        }
      });
      DialogFactory.DissmisLoader();
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new EditorControl(connector));
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      templateDialogViewModel.HandleError(ex);
    }
  }
}
