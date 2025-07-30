// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.DialogFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using AutoUpdaterDotNET;
using MaterialDesignThemes.Wpf;
using pdfFiller.di;
using pdfFiller.Dialogs.Delete;
using pdfFiller.Dialogs.Dev;
using pdfFiller.Dialogs.EmptyTrashBin;
using pdfFiller.Dialogs.Error;
using pdfFiller.Dialogs.GoToMyDocs;
using pdfFiller.Dialogs.Logout;
using pdfFiller.Dialogs.Payment;
using pdfFiller.Dialogs.PrivacyNotice;
using pdfFiller.Dialogs.Rename;
using pdfFiller.Dialogs.Rename.Folder;
using pdfFiller.Dialogs.Update;
using pdfFiller.Dialogs.YesNo;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.MyDocs;
using pdfFiller.UI.TrashBin;
using pdfFiller.Utils.View;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Dialogs;

public class DialogFactory
{
  public static void ShowAlertMessageBox(
    string message,
    DialogFactory.ClosingEventHandler closingEventHandler = null)
  {
    ErrorDialogControl dialogControl = new ErrorDialogControl();
    (dialogControl.DataContext as ErrorDialogViewModel).Message = message;
    (dialogControl.DataContext as ErrorDialogViewModel).ClosingEvent = closingEventHandler;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowAlertMessageBox(
    string title,
    string message,
    DialogFactory.ClosingEventHandler closingEventHandler = null)
  {
    ErrorDialogControl dialogControl = new ErrorDialogControl();
    (dialogControl.DataContext as ErrorDialogViewModel).Message = message;
    (dialogControl.DataContext as ErrorDialogViewModel).Header = title;
    (dialogControl.DataContext as ErrorDialogViewModel).ClosingEvent = closingEventHandler;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowPrivacyDialog(string message, Action onAcceptCallback)
  {
    PrivacyDialog dialogControl = new PrivacyDialog();
    (dialogControl.DataContext as PrivacyDialogViewModel).htmlContent = message;
    (dialogControl.DataContext as PrivacyDialogViewModel).OnAccepted = onAcceptCallback;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowRenameFolderDialog(pdfFiller.Model.Pojo.Data.Folder folder)
  {
    RenameFolderDialogViewModel folderDialogViewModel = new RenameFolderDialogViewModel((ActionsHolder) folder);
    RenameDialog dialogControl = new RenameDialog();
    dialogControl.DataContext = (object) folderDialogViewModel;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowRenameProjectDialog(Project project)
  {
    RenameProjectDialogViewModel projectDialogViewModel = new RenameProjectDialogViewModel((ActionsHolder) project);
    RenameDialog dialogControl = new RenameDialog();
    dialogControl.DataContext = (object) projectDialogViewModel;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowDeleteDialog(ActionsHolder holder)
  {
    DeleteDialog dialogControl = new DeleteDialog();
    DeleteDialogViewModel deleteDialogViewModel;
    if (holder.IsInTrash)
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "TRASH_BIN_DELETE"
        }
      });
      deleteDialogViewModel = (DeleteDialogViewModel) new TrashBinDeleteDialogViewModel((DeleteDialogViewModel.DidCloseDelegate) (() => DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "TRASH_BIN_DELETE"
        }
      })));
    }
    else
    {
      DIManager.AmplitudeManager.AddEvent("Document Action Clicked", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "delete"
        }
      });
      deleteDialogViewModel = (DeleteDialogViewModel) new MyDocsDeleteDialogViewModel((DeleteDialogViewModel.DidCloseDelegate) (() => DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "delete"
        }
      })));
    }
    deleteDialogViewModel.actionsHolder = holder;
    dialogControl.DataContext = (object) deleteDialogViewModel;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowGoToMyDocsDialog()
  {
    YesNoDialog dialogControl = new YesNoDialog();
    dialogControl.DataContext = (object) new GoToMyDocsDialogViewModel();
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowLogoutDialog()
  {
    YesNoDialog dialogControl = new YesNoDialog();
    dialogControl.DataContext = (object) new LogoutDialogViewModel();
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowEmptyTrashDialog()
  {
    YesNoDialog dialogControl = new YesNoDialog();
    dialogControl.DataContext = (object) new EmptyTrashBinDialogViewModel();
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowCopyTemplateDialog(Project project, string name)
  {
    RenameTemplateDialogViewModel templateDialogViewModel = new RenameTemplateDialogViewModel((ActionsHolder) project);
    templateDialogViewModel.Name = name;
    RenameDialog dialogControl = new RenameDialog();
    dialogControl.DataContext = (object) templateDialogViewModel;
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowSubscriptionDialog()
  {
    YesNoDialog dialogControl = new YesNoDialog();
    dialogControl.DataContext = (object) new PaymentDialogViewModel();
    DialogFactory.ShowDialog((UserControl) dialogControl);
  }

  public static void ShowUpdateDialog(UpdateInfoEventArgs args)
  {
    UpdateAppDialog content = new UpdateAppDialog();
    content.DataContext = (object) new UpdateAppDialogViewModel(args);
    DialogHost.Show((object) content, (object) "UpdateRootDialog");
  }

  public static void ShowLoader(string identifier)
  {
    DialogFactory.ShowDialog((UserControl) new Loader(), identifier);
  }

  public static void ShowLoader() => DialogFactory.ShowDialog((UserControl) new Loader());

  public static void DissmisLoader() => DialogFactory.HideDialog();

  public static void DissmisLoader(string identifier) => DialogFactory.HideDialog(identifier);

  public static void HideDialog(string identifier = "RootDialog")
  {
    try
    {
      DialogHost.Close((object) identifier);
    }
    catch (Exception ex)
    {
    }
  }

  public static void ShowDialog(UserControl dialogControl, string identifier = "RootDialog")
  {
    DialogHost.Show((object) dialogControl, (object) identifier);
  }

  public static void ShowDevDialog() => DialogFactory.ShowDialog((UserControl) new DevModeDialog());

  public delegate void ClosingEventHandler();
}
