// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.SortMenu.SortMenuItemsManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.Utils;

#nullable disable
namespace pdfFiller.UI.ContextMenus.SortMenu;

public class SortMenuItemsManager
{
  public const string SORT_ID_MODIFIED_NEWEST = "modifiedNewest";
  public const string SORT_ID_MODIFIED_OLDEST = "modifiedOldest";
  public const string SORT_ID_ADDED_NEWEST = "addedNewest";
  public const string SORT_ID_ADDED_OLDEST = "addedOldest";
  public const string SORT_ID_RECEIVED_NEWEST = "receivedNewest";
  public const string SORT_ID_RECEIVED_OLDEST = "receivedOldest";
  public const string SORT_ID_SENT_NEWEST = "sentNewest";
  public const string SORT_ID_SENT_OLDEST = "sentOldest";
  public const string SORT_ID_NAME_AZ = "nameAZ";
  public const string SORT_ID_NAME_ZA = "nameZA";
  public const string SORT_ID_FROM_AZ = "fromAZ";
  public const string SORT_ID_FROM_ZA = "fromZA";
  public const string SORT_ID_TO_AZ = "toAZ";
  public const string SORT_ID_TO_ZA = "toZA";
  public const string SORT_ID_STATUS = "status";
  public const string SORT_ID_READ = "read";
  public const string SORT_ID_UNREAD = "unread";
  public const string SORT_ID_SIGNED = "signed";
  public const string SORT_ID_UNSIGNED = "unsigned";
  public const string SORT_ID_SHARED_NEWEST = "sharedNewest";
  public const string SORT_ID_SHARED_OLDEST = "sharedOldest";
  public const string SORT_ID_CREATED_NEWEST = "createdNewest";
  public const string SORT_ID_CREATED_OLDEST = "createdOldest";
  public const string SORT_ID_EMAIL = "email";
  public const string SORT_ID_IP = "ip";
  public const string SORT_ID_NEWEST = "newest";
  public const string SORT_ID_OLDEST = "oldest";
  public const string SORT_ID_NAME = "name";
  public static SortMenuItem[] SortMenuItems = new SortMenuItem[28]
  {
    new SortMenuItem("modifiedNewest", ResourcesUtils.GetStringResource("fm_dmn"), "modified", "desc"),
    new SortMenuItem("modifiedOldest", ResourcesUtils.GetStringResource("fm_dmo"), "modified", "asc"),
    new SortMenuItem("addedNewest", ResourcesUtils.GetStringResource("fm_dan"), "date", "desc"),
    new SortMenuItem("addedOldest", ResourcesUtils.GetStringResource("fm_dao"), "date", "asc"),
    new SortMenuItem("receivedNewest", ResourcesUtils.GetStringResource("fm_drn"), "date", "desc"),
    new SortMenuItem("receivedOldest", ResourcesUtils.GetStringResource("fm_dro"), "date", "asc"),
    new SortMenuItem("sentNewest", ResourcesUtils.GetStringResource("fm_dsn"), "date", "desc"),
    new SortMenuItem("sentOldest", ResourcesUtils.GetStringResource("fm_dso"), "date", "asc"),
    new SortMenuItem("nameAZ", ResourcesUtils.GetStringResource("fm_fna"), "filename", "asc"),
    new SortMenuItem("nameZA", ResourcesUtils.GetStringResource("fm_fnz"), "filename", "desc"),
    new SortMenuItem("fromAZ", ResourcesUtils.GetStringResource("fm_fa"), "from", "asc"),
    new SortMenuItem("fromZA", ResourcesUtils.GetStringResource("fm_fz"), "from", "desc"),
    new SortMenuItem("toAZ", ResourcesUtils.GetStringResource("fm_ta"), "from", "asc"),
    new SortMenuItem("toZA", ResourcesUtils.GetStringResource("fm_tz"), "from", "desc"),
    new SortMenuItem("status", ResourcesUtils.GetStringResource("fm_s"), "status", "asc"),
    new SortMenuItem("read", ResourcesUtils.GetStringResource("fm_r"), "unread", "desc"),
    new SortMenuItem("unread", ResourcesUtils.GetStringResource("fm_ur"), "unread", "asc"),
    new SortMenuItem("signed", ResourcesUtils.GetStringResource("fm_sgn"), "status", "desc"),
    new SortMenuItem("unsigned", ResourcesUtils.GetStringResource("fm_usgn"), "status", "asc"),
    new SortMenuItem("sharedNewest", ResourcesUtils.GetStringResource("fm_dshn"), "date", "desc"),
    new SortMenuItem("sharedOldest", ResourcesUtils.GetStringResource("fm_dsho"), "date", "asc"),
    new SortMenuItem("createdNewest", ResourcesUtils.GetStringResource("fm_dcn"), "date", "desc"),
    new SortMenuItem("createdOldest", ResourcesUtils.GetStringResource("fm_dco"), "date", "asc"),
    new SortMenuItem("email", ResourcesUtils.GetStringResource("fm_email"), "email", "asc"),
    new SortMenuItem("ip", ResourcesUtils.GetStringResource("fm_ip"), "ip", "asc"),
    new SortMenuItem("newest", ResourcesUtils.GetStringResource("fm_newest"), "newest", "asc"),
    new SortMenuItem("oldest", ResourcesUtils.GetStringResource("fm_oldest"), "oldest", "asc"),
    new SortMenuItem("name", ResourcesUtils.GetStringResource("fm_name"), "name", "asc")
  };

  public static SortMenuItem GetSortOrderById(string soId)
  {
    foreach (SortMenuItem sortMenuItem in SortMenuItemsManager.SortMenuItems)
    {
      if (sortMenuItem.Equals((object) soId))
        return sortMenuItem;
    }
    return SortMenuItemsManager.SortMenuItems[0];
  }

  public static SortMenuItem GetSortOrderForFolder(DataProvider dataProvider, long folderId)
  {
    return dataProvider.GetSortOrder(folderId) ?? SortMenuItemsManager.GetDefaultSortOrderForFolder(folderId);
  }

  public static void SetSortOrderForFolder(
    DataProvider dataProvider,
    long folderId,
    SortMenuItem sortOrder)
  {
    dataProvider.SaveSortOrder(folderId, sortOrder);
  }

  public static SortMenuItem GetDefaultSortOrderForFolder(long folderId)
  {
    if (folderId == -14L || folderId == -20L || folderId == 0L || folderId > 0L)
      return SortMenuItemsManager.GetSortOrderById("modifiedNewest");
    switch (folderId)
    {
      case -777777:
        return SortMenuItemsManager.GetSortOrderById("newest");
      case -100:
        return SortMenuItemsManager.GetSortOrderById("addedNewest");
      case -35:
      case -10:
      case -9:
      case -3:
        return SortMenuItemsManager.GetSortOrderById("sentNewest");
      case -21:
      case -17:
      case -13:
      case -11:
      case -2:
      case -1:
        return SortMenuItemsManager.GetSortOrderById("unread");
      case -15:
        return SortMenuItemsManager.GetSortOrderById("unread");
      case -7:
        return SortMenuItemsManager.GetSortOrderById("sharedNewest");
      case -4:
        return SortMenuItemsManager.GetSortOrderById("unsigned");
      default:
        return SortMenuItemsManager.GetSortOrderById("modifiedNewest");
    }
  }

  public static SortMenuItem[] GetSortListForFolder(long folderId)
  {
    if (folderId == -14L || folderId == -20L || folderId == 0L || folderId > 0L)
      return new SortMenuItem[6]
      {
        SortMenuItemsManager.SortMenuItems[0],
        SortMenuItemsManager.SortMenuItems[1],
        SortMenuItemsManager.SortMenuItems[2],
        SortMenuItemsManager.SortMenuItems[3],
        SortMenuItemsManager.SortMenuItems[8],
        SortMenuItemsManager.SortMenuItems[9]
      };
    switch (folderId)
    {
      case -777777:
        return new SortMenuItem[5]
        {
          SortMenuItemsManager.SortMenuItems[25],
          SortMenuItemsManager.SortMenuItems[26],
          SortMenuItemsManager.SortMenuItems[27],
          SortMenuItemsManager.SortMenuItems[23],
          SortMenuItemsManager.SortMenuItems[24]
        };
      case -100:
        return new SortMenuItem[4]
        {
          SortMenuItemsManager.SortMenuItems[2],
          SortMenuItemsManager.SortMenuItems[3],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
      case -35:
      case -10:
      case -9:
        return new SortMenuItem[7]
        {
          SortMenuItemsManager.SortMenuItems[6],
          SortMenuItemsManager.SortMenuItems[7],
          SortMenuItemsManager.SortMenuItems[12],
          SortMenuItemsManager.SortMenuItems[13],
          SortMenuItemsManager.SortMenuItems[14],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
      case -17:
        return new SortMenuItem[6]
        {
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9],
          SortMenuItemsManager.SortMenuItems[21],
          SortMenuItemsManager.SortMenuItems[22]
        };
      case -15:
        return new SortMenuItem[6]
        {
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9],
          SortMenuItemsManager.SortMenuItems[21],
          SortMenuItemsManager.SortMenuItems[22]
        };
      case -11:
        return new SortMenuItem[10]
        {
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[10],
          SortMenuItemsManager.SortMenuItems[11],
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[4],
          SortMenuItemsManager.SortMenuItems[5],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
      case -7:
        return new SortMenuItem[8]
        {
          SortMenuItemsManager.SortMenuItems[19],
          SortMenuItemsManager.SortMenuItems[20],
          SortMenuItemsManager.SortMenuItems[12],
          SortMenuItemsManager.SortMenuItems[13],
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
      case -4:
        return new SortMenuItem[10]
        {
          SortMenuItemsManager.SortMenuItems[18],
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[10],
          SortMenuItemsManager.SortMenuItems[11],
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[4],
          SortMenuItemsManager.SortMenuItems[5],
          SortMenuItemsManager.SortMenuItems[17]
        };
      case -3:
        return new SortMenuItem[7]
        {
          SortMenuItemsManager.SortMenuItems[6],
          SortMenuItemsManager.SortMenuItems[7],
          SortMenuItemsManager.SortMenuItems[14],
          SortMenuItemsManager.SortMenuItems[12],
          SortMenuItemsManager.SortMenuItems[13],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
      case -2:
        return new SortMenuItem[9]
        {
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[10],
          SortMenuItemsManager.SortMenuItems[11],
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[4],
          SortMenuItemsManager.SortMenuItems[5],
          SortMenuItemsManager.SortMenuItems[14]
        };
      case -1:
        return new SortMenuItem[10]
        {
          SortMenuItemsManager.SortMenuItems[16 /*0x10*/],
          SortMenuItemsManager.SortMenuItems[15],
          SortMenuItemsManager.SortMenuItems[10],
          SortMenuItemsManager.SortMenuItems[11],
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9],
          SortMenuItemsManager.SortMenuItems[4],
          SortMenuItemsManager.SortMenuItems[5]
        };
      default:
        return new SortMenuItem[6]
        {
          SortMenuItemsManager.SortMenuItems[0],
          SortMenuItemsManager.SortMenuItems[1],
          SortMenuItemsManager.SortMenuItems[2],
          SortMenuItemsManager.SortMenuItems[3],
          SortMenuItemsManager.SortMenuItems[8],
          SortMenuItemsManager.SortMenuItems[9]
        };
    }
  }
}
