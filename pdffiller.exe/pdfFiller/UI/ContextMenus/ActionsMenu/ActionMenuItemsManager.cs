// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.ActionMenuItemsManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu;

public class ActionMenuItemsManager
{
  public static string CURRENT_BUS_KEY = "";
  private static Dictionary<string, ActionMenuItem> actions = new Dictionary<string, ActionMenuItem>();
  private static Dictionary<string, ActionMenuItem> manage = new Dictionary<string, ActionMenuItem>();
  private static Dictionary<string, ActionMenuItem> filledFormsActions = new Dictionary<string, ActionMenuItem>();
  private static List<string> availableProjectActionsConstants = new List<string>()
  {
    "FILL",
    "SIGN_KEY",
    "VIEW",
    "FILLED_FORMS",
    "OPEN_PREVIEW",
    "CREATE",
    "ADD_TO_MY_FORMS",
    "MARK_AS_TEMPLATE",
    "SAVE_AS",
    "RENAME",
    "TRASH_BIN_PUT_BACK",
    "TRASH_BIN_DELETE",
    "DELETE"
  };
  private static List<string> availableFolderActionsConstants = new List<string>()
  {
    "OPEN_FOLDER",
    "RENAME",
    "TRASH_BIN_PUT_BACK",
    "TRASH_BIN_DELETE",
    "DELETE"
  };

  static ActionMenuItemsManager()
  {
    ActionMenuItemsManager.actions.Add("PRINT", new ActionMenuItem("PRINT", "/pdfFiller;component/Resources/Images/Actions/print.png", ResourcesUtils.GetStringResource("action_print")));
    ActionMenuItemsManager.actions.Add("SMS", new ActionMenuItem("SMS", "/pdfFiller;component/Resources/Images/Actions/sms.png", ResourcesUtils.GetStringResource("action_sms")));
    ActionMenuItemsManager.actions.Add("EMAIL", new ActionMenuItem("EMAIL", "/pdfFiller;component/Resources/Images/Actions/email.png", ResourcesUtils.GetStringResource("action_email")));
    ActionMenuItemsManager.actions.Add("FAX", new ActionMenuItem("FAX", "/pdfFiller;component/Resources/Images/Actions/fax.png", ResourcesUtils.GetStringResource("action_fax")));
    ActionMenuItemsManager.actions.Add("SHARE", new ActionMenuItem("SHARE", "/pdfFiller;component/Resources/Images/Actions/share.png", ResourcesUtils.GetStringResource("action_share")));
    ActionMenuItemsManager.actions.Add("SEND_TO_SIGN", new ActionMenuItem("SEND_TO_SIGN", "/pdfFiller;component/Resources/Images/Actions/s_2_s.png", ResourcesUtils.GetStringResource("action_s2s")));
    ActionMenuItemsManager.actions.Add("SIGN_NOW", new ActionMenuItem("SIGN_NOW", "/pdfFiller;component/Resources/Images/Actions/sign_now.png", ResourcesUtils.GetStringResource("action_sign_now")));
    ActionMenuItemsManager.actions.Add("EMBED", new ActionMenuItem("EMBED", "/pdfFiller;component/Resources/Images/Actions/l_2_f.png", ResourcesUtils.GetStringResource("action_l2f")));
    ActionMenuItemsManager.actions.Add("MESSENGER", new ActionMenuItem("MESSENGER", "/pdfFiller;component/Resources/Images/Actions/messenger_logo.png", ResourcesUtils.GetStringResource("action_messenger")));
    ActionMenuItemsManager.actions.Add("WHATS_APP", new ActionMenuItem("WHATS_APP", "/pdfFiller;component/Resources/Images/Actions/whats_app_logo.png", ResourcesUtils.GetStringResource("action_whatsapp")));
    ActionMenuItemsManager.actions.Add("VIBER", new ActionMenuItem("VIBER", "/pdfFiller;component/Resources/Images/Actions/viber_logo.png", ResourcesUtils.GetStringResource("action_viber")));
    ActionMenuItemsManager.actions.Add("EMAIL_RESEND", new ActionMenuItem("EMAIL_RESEND", "/pdfFiller;component/Resources/Images/Actions/email.png", ResourcesUtils.GetStringResource("action_resend")));
    ActionMenuItemsManager.actions.Add("FAX_RESEND", new ActionMenuItem("FAX_RESEND", "/pdfFiller;component/Resources/Images/Actions/email.png", ResourcesUtils.GetStringResource("action_resend")));
    ActionMenuItemsManager.actions.Add("S2S_RESEND", new ActionMenuItem("S2S_RESEND", "/pdfFiller;component/Resources/Images/Actions/email.png", ResourcesUtils.GetStringResource("action_resend")));
    ActionMenuItemsManager.actions.Add("SEND_TO_SIGN_RESEND", new ActionMenuItem("SEND_TO_SIGN_RESEND", "/pdfFiller;component/Resources/Images/Actions/email.png", ResourcesUtils.GetStringResource("action_resend")));
    ActionMenuItemsManager.actions.Add("FILL", new ActionMenuItem("FILL", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_open")));
    ActionMenuItemsManager.actions.Add("OPEN_FOLDER", new ActionMenuItem("OPEN_FOLDER", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_open")));
    ActionMenuItemsManager.actions.Add("SIGN_KEY", new ActionMenuItem("SIGN_KEY", "/pdfFiller;component/Resources/Images/Actions/sign.png", ResourcesUtils.GetStringResource("action_sign")));
    ActionMenuItemsManager.actions.Add("VIEW", new ActionMenuItem("VIEW", "/pdfFiller;component/Resources/Images/Actions/view.png", ResourcesUtils.GetStringResource("action_view")));
    ActionMenuItemsManager.actions.Add("OPEN_PREVIEW", new ActionMenuItem("OPEN_PREVIEW", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_view")));
    ActionMenuItemsManager.actions.Add("CREATE", new ActionMenuItem("CREATE", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_create_form")));
    ActionMenuItemsManager.actions.Add("SAVE_AS", new ActionMenuItem("SAVE_AS", "/pdfFiller;component/Resources/Images/Actions/save_as.png", ResourcesUtils.GetStringResource("action_save_as")));
    ActionMenuItemsManager.actions.Add("SEND_TO_SIGN_SETTINGS", new ActionMenuItem("SEND_TO_SIGN_SETTINGS", "/pdfFiller;component/Resources/Images/Actions/settings.png", ResourcesUtils.GetStringResource("action_status")));
    ActionMenuItemsManager.actions.Add("SHARE_SETTINGS", new ActionMenuItem("SHARE_SETTINGS", "/pdfFiller;component/Resources/Images/Actions/settings.png", ResourcesUtils.GetStringResource("action_share_settings")));
    ActionMenuItemsManager.actions.Add("MOVE_TO_MY_DOCS", new ActionMenuItem("MOVE_TO_MY_DOCS", "/pdfFiller;component/Resources/Images/Actions/copy_to_mydocs.png", ResourcesUtils.GetStringResource("action_move_to_mybox")));
    ActionMenuItemsManager.actions.Add("ADD_TO_MY_FORMS", new ActionMenuItem("ADD_TO_MY_FORMS", "/pdfFiller;component/Resources/Images/Actions/copy_to_mydocs.png", ResourcesUtils.GetStringResource("action_copy_to_mybox")));
    ActionMenuItemsManager.actions.Add("TRASH_BIN_PUT_BACK", new ActionMenuItem("TRASH_BIN_PUT_BACK", "/pdfFiller;component/Resources/Images/Actions/restore.png", ResourcesUtils.GetStringResource("action_restore")));
    ActionMenuItemsManager.actions.Add("TRASH_BIN_DELETE", new ActionMenuItem("TRASH_BIN_DELETE", "/pdfFiller;component/Resources/Images/Actions/delete.png", ResourcesUtils.GetStringResource("action_delete_from_trash_bin")));
    ActionMenuItemsManager.actions.Add("FILLED_FORMS", new ActionMenuItem("FILLED_FORMS", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_filled_forms")));
    ActionMenuItemsManager.actions.Add("SEND_TO_SIGN_ATTACHMENT", new ActionMenuItem("SEND_TO_SIGN_ATTACHMENT", "/pdfFiller;component/Resources/Images/Actions/info_doc.png", ResourcesUtils.GetStringResource("action_attachments")));
    ActionMenuItemsManager.actions.Add("RENAME", new ActionMenuItem("RENAME", "/pdfFiller;component/Resources/Images/Actions/rename.png", ResourcesUtils.GetStringResource("action_rename")));
    ActionMenuItemsManager.actions.Add("SHARE_TEMPLATE", new ActionMenuItem("SHARE_TEMPLATE", "/pdfFiller;component/Resources/Images/Actions/share.png", ResourcesUtils.GetStringResource("action_share_template")));
    ActionMenuItemsManager.actions.Add("LINK2FILL_SETTINGS", new ActionMenuItem("LINK2FILL_SETTINGS", "/pdfFiller;component/Resources/Images/Actions/settings.png", ResourcesUtils.GetStringResource("action_settings")));
    ActionMenuItemsManager.manage.Add("DELETE_SMART_FOLDER_KEY", new ActionMenuItem("DELETE_SMART_FOLDER_KEY", "/pdfFiller;component/Resources/Images/Actions/delete.png", ResourcesUtils.GetStringResource("action_delete_smart_folder")));
    ActionMenuItemsManager.manage.Add("EDIT_SMART_FOLDER_KEY", new ActionMenuItem("EDIT_SMART_FOLDER_KEY", "/pdfFiller;component/Resources/Images/Actions/open.png", ResourcesUtils.GetStringResource("action_edit_smart_folder")));
    ActionMenuItemsManager.manage.Add("COPY", new ActionMenuItem("COPY", "/pdfFiller;component/Resources/Images/Actions/copy.png", ResourcesUtils.GetStringResource("action_copy")));
    ActionMenuItemsManager.manage.Add("RENAME", new ActionMenuItem("RENAME", "/pdfFiller;component/Resources/Images/Actions/rename.png", ResourcesUtils.GetStringResource("action_rename")));
    ActionMenuItemsManager.manage.Add("DELETE", new ActionMenuItem("DELETE", "/pdfFiller;component/Resources/Images/Actions/delete.png", ResourcesUtils.GetStringResource("action_delete")));
    ActionMenuItemsManager.manage.Add("MOVE", new ActionMenuItem("MOVE", "/pdfFiller;component/Resources/Images/Actions/move.png", ResourcesUtils.GetStringResource("action_move")));
    ActionMenuItemsManager.manage.Add("CLEAR", new ActionMenuItem("CLEAR", "/pdfFiller;component/Resources/Images/Actions/clear.png", ResourcesUtils.GetStringResource("action_clear_fields")));
    ActionMenuItemsManager.manage.Add("MARK_AS_TEMPLATE", new ActionMenuItem("MARK_AS_TEMPLATE", "/pdfFiller;component/Resources/Images/Actions/create_template.png", ResourcesUtils.GetStringResource("action_template")));
    ActionMenuItemsManager.manage.Add("ADD_EMPTY_PAGES", new ActionMenuItem("ADD_EMPTY_PAGES", "/pdfFiller;component/Resources/Images/Actions/add_empty_pages_ic.png", ResourcesUtils.GetStringResource("action_empty_pages")));
    ActionMenuItemsManager.manage.Add("TAG", new ActionMenuItem("TAG", "/pdfFiller;component/Resources/Images/Actions/tags.png", ResourcesUtils.GetStringResource("action_tag")));
    ActionMenuItemsManager.manage.Add("CONTACT_WITH_SENDER", new ActionMenuItem("CONTACT_WITH_SENDER", "/pdfFiller;component/Resources/Images/Actions/contact_sender.png", ResourcesUtils.GetStringResource("action_contact_sender")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_SEND_TO_CLOD_KEY", new ActionMenuItem("FILLED_FORMS_SEND_TO_CLOD_KEY", "/pdfFiller;component/Resources/Images/Actions/upload.png", ResourcesUtils.GetStringResource("action_send_to_cloud")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_DELETE_KEY", new ActionMenuItem("FILLED_FORMS_DELETE_KEY", "/pdfFiller;component/Resources/Images/Actions/delete.png", ResourcesUtils.GetStringResource("action_delete")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_DOWNLOAD_KEY", new ActionMenuItem("FILLED_FORMS_DOWNLOAD_KEY", "/pdfFiller;component/Resources/Images/Actions/save_as.png", ResourcesUtils.GetStringResource("action_download")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_SAVE_TO_MY_BOX_KEY", new ActionMenuItem("FILLED_FORMS_SAVE_TO_MY_BOX_KEY", "/pdfFiller;component/Resources/Images/Actions/copy_to_mydocs.png", ResourcesUtils.GetStringResource("action_send_to_cloud")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_EXPORT_KEY", new ActionMenuItem("FILLED_FORMS_EXPORT_KEY", "/pdfFiller;component/Resources/Images/Actions/export.png", ResourcesUtils.GetStringResource("action_export")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_TRACK_DOCUMENT_KEY", new ActionMenuItem("FILLED_TRACK_DOCUMENT_KEY", "/pdfFiller;component/Resources/Images/Actions/track.png", ResourcesUtils.GetStringResource("action_track_document")));
    ActionMenuItemsManager.filledFormsActions.Add("FILLED_FORMS_INFO_KEY", new ActionMenuItem("FILLED_FORMS_INFO_KEY", "/pdfFiller;component/Resources/Images/Actions/info_doc.png", ResourcesUtils.GetStringResource("action_info")));
  }

  public static List<ActionMenuItem> GetItems(ActionsHolder holder)
  {
    if (holder is Folder)
    {
      if ((holder as Folder).IsSystem)
        return new List<ActionMenuItem>()
        {
          ActionMenuItemsManager.actions["OPEN_FOLDER"]
        };
      if ((holder as Folder).IsInTrash)
        return new List<ActionMenuItem>()
        {
          ActionMenuItemsManager.actions["OPEN_FOLDER"],
          ActionMenuItemsManager.actions["TRASH_BIN_PUT_BACK"],
          ActionMenuItemsManager.actions["TRASH_BIN_DELETE"]
        };
    }
    List<string> availableActionsConstants = holder is Folder ? ActionMenuItemsManager.availableFolderActionsConstants : ActionMenuItemsManager.availableProjectActionsConstants;
    List<ActionMenuItem> items1 = ActionMenuItemsManager.GetItems(holder.GetConstants().GetAvailbaleActions(holder.GetMask().GetActions()), ActionMenuItemsManager.actions, availableActionsConstants);
    List<ActionMenuItem> items2 = ActionMenuItemsManager.GetItems(holder.GetConstants().GetAvailbaleManageActions(holder.GetMask().GetManageActions()), ActionMenuItemsManager.manage, availableActionsConstants);
    List<ActionMenuItem> items3 = new List<ActionMenuItem>();
    items3.AddRange((IEnumerable<ActionMenuItem>) items1);
    if (!items1.IsNullOrEmpty<ActionMenuItem>() && !items2.IsNullOrEmpty<ActionMenuItem>())
      items3.Add((ActionMenuItem) new MenuSeparator());
    items3.AddRange((IEnumerable<ActionMenuItem>) items2);
    if (holder is Project)
    {
      ActionMenuItem actionMenuItem = ActionMenuItemsManager.manage["MARK_AS_TEMPLATE"];
      if (!(holder as Project).IsInTrash && items3.Contains(ActionMenuItemsManager.manage["MARK_AS_TEMPLATE"]))
        actionMenuItem.Name = actionMenuItem == null || !(holder as Project).IsTemplate ? ResourcesUtils.GetStringResource("action_template") : ResourcesUtils.GetStringResource("action_template_revert");
      ActionMenuItemsManager.manage["DELETE"].Name = (holder as Project).IsSignatureRequest || (holder as Project).IsOutBoxEmail || (holder as Project).IsOutBoxFax || (holder as Project).IsOutBoxS2S || (holder as Project).IsOutBoxShare || (holder as Project).IsSharedWithMe ? ResourcesUtils.GetStringResource("delete_title") : ResourcesUtils.GetStringResource("action_delete");
      if ((holder as Project).IsInboxEmail)
        items3.Remove(actionMenuItem);
      ActionMenuItemsManager.actions["FILL"].Name = !(holder as Project).IsSignatureRequest ? ResourcesUtils.GetStringResource("action_open") : ResourcesUtils.GetStringResource("action_sign");
    }
    return items3;
  }

  private static List<ActionMenuItem> GetItems(
    List<string> actionsConstants,
    Dictionary<string, ActionMenuItem> items,
    List<string> availableActionsConstants)
  {
    List<ActionMenuItem> items1 = new List<ActionMenuItem>();
    foreach (string actionsConstant in actionsConstants)
    {
      if (availableActionsConstants.Contains(actionsConstant))
      {
        try
        {
          items1.Add(items[actionsConstant]);
        }
        catch (KeyNotFoundException ex)
        {
        }
      }
    }
    return items1;
  }

  public static ActionMenuItem GetItemFromList(string key, List<ActionMenuItem> list)
  {
    return !list.Contains(ActionMenuItemsManager.actions[key]) ? (ActionMenuItem) null : list.First<ActionMenuItem>((Func<ActionMenuItem, bool>) (item => item.key == key));
  }
}
