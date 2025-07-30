// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.ProjectMenu.ProjectActionsManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Dialogs.SaveDocument;
using pdfFiller.Model.Api;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.UI.Editor;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu.ProjectMenu;

public class ProjectActionsManager : ActionsManager
{
  public void OnAction(string key, pdfFiller.Model.Pojo.Data.Project project)
  {
    if (key == "OPEN_PREVIEW" || key == "FILL" || key == "SIGN_KEY" || key == "VIEW" || key == "OPEN_PREVIEW")
      this.Open(project);
    if (key == "FILLED_FORMS")
      this.UseWebMessage();
    if (key == "DELETE" || key == "TRASH_BIN_DELETE")
      this.Delete(project);
    if (key == "SAVE_AS")
      this.SaveAs(project);
    if (key == "CREATE")
      this.CreateForm(project);
    if (key == "TRASH_BIN_PUT_BACK")
      this.Restore(project);
    if (key == "ADD_TO_MY_FORMS")
      this.AddToMyForms(project);
    if (key == "RENAME")
      this.Rename(project);
    if (!(key == "MARK_AS_TEMPLATE"))
      return;
    this.CreateTemplate(project);
  }

  private void UseWebMessage()
  {
    LifecycleEventDispatcherControl.GetInstance().ShowSnackbar(ResourcesUtils.GetStringResource("l2f_go_to_web_message"));
  }

  private async void CreateTemplate(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          project.IsTemplate ? (object) "revert_from_template" : (object) "convert_to_template"
        }
      });
      DialogFactory.ShowLoader();
      await projectActionsManager.dataManager.CreateTemplate(project);
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          project.IsTemplate ? (object) "revert_from_template" : (object) "convert_to_template"
        }
      });
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TabsAndFoldersViewModel").RefreshAll();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }

  private void Rename(pdfFiller.Model.Pojo.Data.Project project)
  {
    DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
    {
      {
        "action_type",
        (object) "rename"
      }
    });
    DialogFactory.ShowRenameProjectDialog(project);
  }

  private async void AddToMyForms(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "ADD_TO_MY_FORMS"
        }
      });
      DialogFactory.ShowLoader();
      await projectActionsManager.dataManager.AddToMyForms(project);
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "ADD_TO_MY_FORMS"
        }
      });
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TabsAndFoldersViewModel").Refresh("FilesListViewModel");
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }

  private async void CreateForm(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "create_from_template"
        }
      });
      DialogFactory.ShowLoader();
      string uniqueName = await projectActionsManager.dataManager.GetUniqueName(project);
      DialogFactory.DissmisLoader();
      DialogFactory.ShowCopyTemplateDialog(project, Path.GetFileNameWithoutExtension(uniqueName));
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }

  private async void Open(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "open"
        }
      });
      DialogFactory.ShowLoader();
      EditorConnector editorConnector = await projectActionsManager.dataManager.GetEditorConnector(project);
      DialogFactory.DissmisLoader();
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "open"
        }
      });
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new EditorControl(editorConnector));
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }

  private async void SaveAs(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      projectActionsManager.analyticsManager.TrackEvent("save_as_show");
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "save_as"
        }
      });
      DialogFactory.ShowLoader();
      PermissionResponse permissionResponse = await projectActionsManager.PermissionManager.CheckPermission("SAVE_AS", project);
      DialogFactory.DissmisLoader();
      if (permissionResponse.IsFreeUser())
        DialogFactory.ShowSubscriptionDialog();
      else if (!permissionResponse.IsAllowed())
      {
        DialogFactory.ShowAlertMessageBox(permissionResponse.message);
      }
      else
      {
        SaveDocumentDialog dialogControl = new SaveDocumentDialog();
        (dialogControl.DataContext as SaveDocumentDialogViewModel).Project = project;
        DialogFactory.ShowDialog((UserControl) dialogControl);
      }
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }

  private void Delete(pdfFiller.Model.Pojo.Data.Project project)
  {
    DialogFactory.ShowDeleteDialog((ActionsHolder) project);
  }

  private async void Restore(pdfFiller.Model.Pojo.Data.Project project)
  {
    ProjectActionsManager projectActionsManager = this;
    try
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "TRASH_BIN_PUT_BACK"
        }
      });
      DialogFactory.ShowLoader();
      int num = await projectActionsManager.dataManager.RestoreProjectFromTrash(project) ? 1 : 0;
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr("TrashBinFoldersViewModel").RefreshAll();
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar("Success");
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "TRASH_BIN_PUT_BACK"
        }
      });
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      projectActionsManager.HandleError(ex);
    }
  }
}
