// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.MyDocs.MyDocsDeleteDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Dialogs.Delete;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.MyDocs;

public class MyDocsDeleteDialogViewModel(DeleteDialogViewModel.DidCloseDelegate didClose) : 
  DeleteDialogViewModel(didClose)
{
  protected override Task<bool> DeleteItem(ActionsHolder actionsHolder)
  {
    return actionsHolder is Project ? this.dataManager.DeleteProject(actionsHolder as Project) : this.dataManager.DeleteFolder(actionsHolder as Folder);
  }

  protected override string GetBusManagerKey() => "TabsAndFoldersViewModel";

  protected override string GetConfirmButtonContent()
  {
    return this.IsCommonDelete() || (this.actionsHolder as Project).IsSharedWithMe || (this.actionsHolder as Project).IsOutBoxShare || (this.actionsHolder as Project).IsSignatureRequest || (this.actionsHolder as Project).IsOutBoxS2S || (this.actionsHolder as Project).IsOutBoxEmail ? ResourcesUtils.GetStringResource("delete_title") : base.GetConfirmButtonContent();
  }

  protected override string GetTitle()
  {
    if (this.actionsHolder is Folder)
      return ResourcesUtils.GetStringResource("delete_title_folder");
    if ((this.actionsHolder as Project).IsSharedWithMe)
      return ResourcesUtils.GetStringResource("delete_title_shared_with_me");
    if ((this.actionsHolder as Project).IsOutBoxShare)
      return ResourcesUtils.GetStringResource("delete_title_shared_by_me");
    if ((this.actionsHolder as Project).IsSignatureRequest || (this.actionsHolder as Project).IsOutBoxS2S)
      return ResourcesUtils.GetStringResource("delete_title_s2s");
    return this.IsCommonDelete() ? ResourcesUtils.GetStringResource("delete_title_project_common") : base.GetTitle();
  }

  protected override string GetMessage()
  {
    if (this.actionsHolder is Folder)
      return ResourcesUtils.GetStringResource("delete_message_folder");
    if ((this.actionsHolder as Project).IsOutBoxEmail)
      return ResourcesUtils.GetStringResource("delete_message_outbox_sms_emal");
    if ((this.actionsHolder as Project).IsSignatureRequest)
      return ResourcesUtils.GetStringResource("delete_message_s2s_requested");
    if ((this.actionsHolder as Project).IsOutBoxS2S)
      return ResourcesUtils.GetStringResource("delete_message_s2s_sent");
    if (this.IsCommonDelete())
      return ResourcesUtils.GetStringResource("delete_message_common");
    if ((this.actionsHolder as Project).IsSharedWithMe)
      return ResourcesUtils.GetStringResource("delete_message_shared_with_me");
    return (this.actionsHolder as Project).IsOutBoxShare ? ResourcesUtils.GetStringResource("delete_message_shared_by_me") : base.GetMessage();
  }
}
