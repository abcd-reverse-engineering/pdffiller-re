// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Delete.DeleteDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.Delete;

public abstract class DeleteDialogViewModel : BaseViewModel
{
  public ActionsHolder actionsHolder;
  private DeleteDialogViewModel.DidCloseDelegate _didClose;

  public ICommand ConfirmCommand { get; }

  public string Title => this.GetTitle();

  public string Message => this.GetMessage();

  public string ConfirmButtonContent => this.GetConfirmButtonContent();

  protected virtual string GetTitle()
  {
    if (this.actionsHolder is Project)
      return ResourcesUtils.GetStringResource("delete_title_project");
    return this.actionsHolder is Folder ? ResourcesUtils.GetStringResource("delete_title_folder") : ResourcesUtils.GetStringResource("delete_title");
  }

  protected virtual string GetMessage()
  {
    return this.actionsHolder is Folder ? ResourcesUtils.GetStringResource("delete_message_folder") : ResourcesUtils.GetStringResource("delete_message");
  }

  protected virtual string GetConfirmButtonContent()
  {
    return ResourcesUtils.GetStringResource("action_delete");
  }

  public DeleteDialogViewModel(DeleteDialogViewModel.DidCloseDelegate didClose)
  {
    this.ConfirmCommand = (ICommand) new SimpleCommand(new Action(this.Delete));
    this._didClose = didClose;
  }

  private async void Delete()
  {
    DeleteDialogViewModel deleteDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      int num = await deleteDialogViewModel.DeleteItem(deleteDialogViewModel.actionsHolder) ? 1 : 0;
      deleteDialogViewModel._didClose();
      DialogFactory.DissmisLoader();
      DIManager.BusManager.GetRefreshDispatcherr(deleteDialogViewModel.GetBusManagerKey()).RefreshAll();
      string message = "Moved to Trash Bin";
      if (deleteDialogViewModel.actionsHolder is Project && ((deleteDialogViewModel.actionsHolder as Project).IsOutBoxEmail || (deleteDialogViewModel.actionsHolder as Project).IsInboxEmail || (deleteDialogViewModel.actionsHolder as Project).IsSignatureRequest || (deleteDialogViewModel.actionsHolder as Project).IsOutBoxS2S || (deleteDialogViewModel.actionsHolder as Project).IsSharedWithMe || (deleteDialogViewModel.actionsHolder as Project).IsOutBoxFax || (deleteDialogViewModel.actionsHolder as Project).IsInTrash))
        message = "Deleted";
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar(message);
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      deleteDialogViewModel.HandleError(ex);
    }
  }

  protected bool IsCommonDelete()
  {
    return this.actionsHolder is Project && (this.actionsHolder as Project).IsOutBoxFax;
  }

  protected abstract string GetBusManagerKey();

  protected abstract Task<bool> DeleteItem(ActionsHolder actionsHolder);

  public delegate void DidCloseDelegate();
}
