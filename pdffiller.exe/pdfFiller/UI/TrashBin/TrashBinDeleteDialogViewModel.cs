// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TrashBin.TrashBinDeleteDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Dialogs.Delete;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.TrashBin;

public class TrashBinDeleteDialogViewModel(DeleteDialogViewModel.DidCloseDelegate didClose) : 
  DeleteDialogViewModel(didClose)
{
  protected override Task<bool> DeleteItem(ActionsHolder actionsHolder)
  {
    return actionsHolder is Project ? this.dataManager.DeleteProjectFromTrash(actionsHolder as Project) : this.dataManager.DeleteFolderFromTashBin(actionsHolder as Folder);
  }

  protected override string GetBusManagerKey() => "TrashBinFoldersViewModel";

  protected override string GetConfirmButtonContent()
  {
    return ResourcesUtils.GetStringResource("action_delete_from_trash_bin");
  }

  protected override string GetTitle()
  {
    return this.actionsHolder is Folder ? ResourcesUtils.GetStringResource("delete_title_folder_common") : ResourcesUtils.GetStringResource("delete_title_project_common");
  }

  protected override string GetMessage()
  {
    return this.actionsHolder is Folder ? ResourcesUtils.GetStringResource("delete_message_folder_common") : ResourcesUtils.GetStringResource("delete_message_common");
  }
}
