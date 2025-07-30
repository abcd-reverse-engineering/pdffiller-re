// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Folder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Data.Structure.Actions;
using pdfFiller.Properties;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Pojo.Data;

public class Folder : ActionsHolder
{
  public const int TRASH_BIN_BOX_ID = -100;
  public const string MYBOX_NAME = "myBox";
  public const string ENCRYPTED_FOLDER_NAME = "id_-14";
  public const string CLOUD_NAME = "cloud";
  public const string INBOX_NAME = "inBox";
  public const string OUTBOX_NAME = "outbox";
  public const string TRASH_NAME = "trash";
  public const string S2S_ME_NAME = "s2s_me";
  public const string SHARED_NAME = "shared";
  public const string SUGGESTED_DOCUMENTS_NAME = "suggested_documents";
  public const string SMART_NAME = "smart";
  public const string TEMPLATES_NAME = "template";
  public const string SIGN_NOW_NAME = "signnow";
  public const string USPS_NAME = "usps";
  public const string NOTARIZE_NAME = "notarize";
  public const string IRS_NAME = "irs";
  public const string OUTBOX_EMAIL_NAME = "email";
  public const string OUTBOX_FAX_NAME = "fax";
  public const string L2F_NAME = "link2fill";
  public const string S2S_NAME = "s2s";
  public const string OUTBOX_SHARE_NAME = "share";
  public const long MY_BOX_FOLDER_ID = -20;
  public const long MY_BOX_UNSORTED_FOLDER_ID = 0;
  public const long ENCRYPTED_FOLDER_ID = -14;
  public const long TRASH_BIN_ID = -100;
  public const long IN_BOX_FOLDER_ID = -21;
  public const long IN_BOX_EMAIL_FOLDER_ID = -1;
  public const long IN_BOX_PMAIL_FOLDER_ID = -13;
  public const long IN_BOX_FAX_FOLDER_ID = -11;
  public const long IN_BOX_L2F_FOLDER_ID = -17;
  public const long OUT_BOX_FOLDER_ID = -22;
  public const long OUT_BOX_EMAIL_FOLDER_ID = -9;
  public const long OUT_BOX_FAX_FOLDER_ID = -10;
  public const long OUT_BOX_L2F_FOLDER_ID = -15;
  public const long OUT_BOX_SHARE_FOLDER_ID = -7;
  public const long OUT_BOX_SEND_TO_SIGN_FOLDER_ID = -3;
  public const long OUT_BOX_SIGN_NOW_FOLDER_ID = -42;
  public const long OUT_BOX_NOTARIZE_FOLDER_ID = -39;
  public const long OUT_BOX_USPS_FOLDER_ID = -35;
  public const long SHARED_WITH_ME_FOLDER_ID = -2;
  public const long SHARED_WITH_ME_SUBFOLDER_ID = -52;
  public const long SUGGESTED_DOCUMENTS_FOLDER_ID = -12;
  public const long SIGNATURE_FOLDER_ID = -4;
  public const long CLOUD_FOLDER_ID = -32;
  public const long DROPBOX_FOLDER_ID = -33;
  public const long GOOGLE_DRIVE_FOLDER_ID = -34;
  public const long BOX_FOLDER_ID = -36;
  public const long ONEDRIVE_FOLDER_ID = -37;
  public const long SMART_FOLDER_ID = -38;
  public const long TEMPLATES_FOLDER_ID = -60;
  public const long FAKE_FILLED_FORMS_FOLDER_ID = -777777;
  public const long FAKE_FIND_PDF_START_FOLDER_ID = -88888;
  public const long FAKE_FIND_PDF_EMPTY_FOLDER_ID = -99999;
  private static List<long> INBOX_IDS = new List<long>();
  private static List<long> OUTBOX_IDS = new List<long>();
  private Tuple<string, string> folderResources;
  public string name;
  public string type;
  public string location;
  private long _id;
  public Dictionary<string, Folder> subFolders;
  public Folder.Count count;
  public Folder.Behavior behavior;
  public Folder.FolderMask mask;

  public static Folder GetMockFindPdfEmptyFolder()
  {
    return new Folder() { id = -99999 };
  }

  public static Folder GetMockFindPdfStartFolder()
  {
    return new Folder() { id = -88888 };
  }

  public static bool IsCloudsFolder(long id)
  {
    return id == -33L || id == -34L || id == -36L || id == -37L;
  }

  public static bool IsInboxFolder(long folderId) => Folder.INBOX_IDS.Contains(folderId);

  public static bool IsOutboxFolder(long folderId) => Folder.OUTBOX_IDS.Contains(folderId);

  public Mask GetMask() => (Mask) this.mask;

  public string GetName() => this.Name;

  public ActionsConstants GetConstants()
  {
    return ActionsConstants.FromString(Settings.Default["FOLDERS_MASK"] as string);
  }

  public override bool Equals(object obj) => obj is Folder folder && this.id == folder.id;

  static Folder()
  {
    Folder.INBOX_IDS.Add(-2L);
    Folder.INBOX_IDS.Add(-1L);
    Folder.INBOX_IDS.Add(-11L);
    Folder.INBOX_IDS.Add(-15L);
    Folder.INBOX_IDS.Add(-4L);
    Folder.OUTBOX_IDS.Add(-22L);
    Folder.OUTBOX_IDS.Add(-9L);
    Folder.OUTBOX_IDS.Add(-10L);
    Folder.OUTBOX_IDS.Add(-15L);
    Folder.OUTBOX_IDS.Add(-7L);
    Folder.OUTBOX_IDS.Add(-3L);
    Folder.OUTBOX_IDS.Add(-42L);
    Folder.OUTBOX_IDS.Add(-39L);
    Folder.OUTBOX_IDS.Add(-35L);
  }

  public string Name => this.folderResources != null ? this.folderResources.Item1 : this.name;

  public long id
  {
    get => this._id;
    set
    {
      this._id = value;
      this.folderResources = FolderImageSourceCollection.GetFolderResources(value);
    }
  }

  public string FolderImageSource
  {
    get
    {
      if (this.folderResources != null)
        return this.folderResources.Item2;
      return this.IsShared ? "/pdfFiller;component/Resources/Images/Folders/folder_shared.png" : "/pdfFiller;component/Resources/Images/Folders/folder_custom.png";
    }
  }

  public bool IsMenuHidden => !this.IsSystem;

  public bool IsShared => this.behavior != null && this.behavior.shared;

  public string ProjectsCount
  {
    get => this.count.totalProjects != 0 ? this.count.totalProjects.ToString() : "";
  }

  public bool IsSystem => this.id <= 0L;

  public bool HasNewProjects => this.count.newProjects > 0;

  public bool IsInTrash => this.location.Contains("trash");

  public bool IsRoot
  {
    get
    {
      if (this.IsSystem)
        return true;
      return this.location.Split(':').Length <= 2;
    }
  }

  public class Count
  {
    public int totalProjects;
    public int projects;
    public int newProjects;
    public int subFolders;
  }

  public class Behavior
  {
    public bool childAdd;
    public bool currentAdd;
    public bool shared;
  }

  public class FolderMask : Mask
  {
    public int[] manage;
    public int[] action;

    public int[] GetActions() => this.action;

    public int[] GetManageActions() => this.manage;
  }
}
