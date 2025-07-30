// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Project
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Data.Structure.Actions;
using pdfFiller.Properties;
using System;
using System.Globalization;

#nullable disable
namespace pdfFiller.Model.Pojo.Data;

public class Project : ActionsHolder
{
  public const string LOCATION_INBOX_EMAIL = "inBox:email";
  public const string LOCATION_INBOX_FAX = "inBox:faxes";
  public const string LOCATION_SIGNATURE_REQUEST = "s2s_me";
  public const string LOCATION_L2F = "link2fill";
  public const string LOCATION_INBOX_SHARE_WITH_ME = "shared";
  public const string LOCATION_OUTBOX_SMS = "outbox:sms";
  public const string LOCATION_OUTBOX_EMAIL = "outbox:email";
  public const string LOCATION_OUTBOX_FAX = "outbox:faxes";
  public const string LOCATION_OUTBOX_SHARE = "outbox:share";
  public const string LOCATION_OUTBOX_S2S = "outbox:s2s";
  public string fileName;
  public string date;
  public string location;
  public string fileType;
  public string created;
  public string modify;
  public string modified;
  public string title;
  public string ext;
  public string projectType;
  public long cloneState;
  public Project.S2S s2s;
  public Project.Sender sender;
  public Project.Status status;
  public Project.ProjectMask mask;
  [JsonProperty(PropertyName = "tiny_url")]
  public string tinyUrl;

  [JsonProperty(PropertyName = "project_id")]
  public long projectId { get; set; }

  [JsonProperty(PropertyName = "attr_template")]
  public int templateAttr { get; set; }

  [JsonProperty(PropertyName = "attr_viewed")]
  public int attrViewed { get; set; } = 1;

  [JsonProperty(PropertyName = "system_id")]
  public long systemId { get; set; }

  [JsonProperty(PropertyName = "folder_id")]
  public long folderId { get; set; }

  public string Name => this.fileName;

  public string Date
  {
    get
    {
      try
      {
        return DateTime.Parse(this.date).ToString("MM-dd-yy hh:mm tt", (IFormatProvider) CultureInfo.InvariantCulture);
      }
      catch (Exception ex)
      {
        return this.date;
      }
    }
  }

  public string ProjectIcon => ProjectsIconsCollection.GetIcon(this);

  public string ProjectStatusIcon => ProjectsIconsCollection.GetStatusIcon(this);

  public bool IsTemplate => this.templateAttr == 1;

  public bool IsViewed => this.attrViewed == 0 && Folder.IsInboxFolder(this.folderId);

  public bool IsSignatureRequest => this.location != null && this.location.Equals("s2s_me");

  public bool IsNewS2S => this.s2s != null && this.s2s.type == 2;

  public bool IsInboxEmail => this.location.Equals("inBox:email");

  public bool IsInboxFax => this.location.Equals("inBox:faxes");

  public bool IsL2F
  {
    get => this.location.Contains("link2fill") || this.folderId == -17L || this.folderId == -15L;
  }

  public bool IsSharedWithMe => this.location.Equals("shared");

  public bool IsOutBoxEmail
  {
    get => this.location.Equals("outbox:email") || this.location.Equals("outbox:sms");
  }

  public bool IsOutBoxFax => this.location.Equals("outbox:faxes");

  public bool IsOutBoxShare => this.location.Equals("outbox:share");

  public bool IsOutBoxS2S => this.location.Equals("outbox:s2s");

  public bool IsUsps => false;

  public bool IsInTrash => this.location.ToLower().Contains("trash");

  public string SenderEmail => this.sender != null ? this.sender.from : this.Name;

  public ActionsConstants GetConstants()
  {
    return ActionsConstants.FromString(Settings.Default["PROJECTS_MASK"] as string);
  }

  public Mask GetMask() => (Mask) this.mask;

  public bool IsSuggestedDocument => this.location == "id_" + -12L.ToString();

  public string PreviewUrl
  {
    get
    {
      return this.tinyUrl == null || this.tinyUrl.Length == 0 ? "/pdfFiller;component/Resources/Images/doc_preview.png" : "https://www.pdffiller.com/preview/" + this.tinyUrl;
    }
  }

  public string GetName() => this.Name;

  public class S2S
  {
    public string name;
    public int type;
    public string text;
    public string pin;
  }

  public class Sender
  {
    public string from;
    public string text;
  }

  public class Status
  {
    public int code;
    public string text;
    public int shareType;
  }

  public class ProjectMask : Mask
  {
    public int[] manage;
    public int[] action;

    public int[] GetActions() => this.action;

    public int[] GetManageActions() => this.manage;
  }
}
