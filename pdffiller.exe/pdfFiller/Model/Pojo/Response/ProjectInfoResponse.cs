// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.ProjectInfoResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class ProjectInfoResponse
{
  public ProjectInfoResponse.Project project;

  public ProjectInfoResponse.ProjectStatus GetProjectStatus()
  {
    switch (int.Parse(this.project.status))
    {
      case 3:
        return ProjectInfoResponse.ProjectStatus.STATE_FINISHED;
      case 4:
        return ProjectInfoResponse.ProjectStatus.STATE_ERROR;
      case 6:
        return ProjectInfoResponse.ProjectStatus.STATE_PROTECTED;
      default:
        return ProjectInfoResponse.ProjectStatus.STATE_PROGRESS;
    }
  }

  public class Project
  {
    public const int PROGRESS = 2;
    public const int FINISHED = 3;
    public const int ERROR = 4;
    public const int PROTECTED = 6;
    public string id;
    public string userid;
    public string filename;
    [JsonProperty(PropertyName = "create_date")]
    public string createDate;
    public string modified;
    public string print;
    [JsonProperty(PropertyName = "print_all")]
    public string printAll;
    public string fax;
    public string agent;
    public string ispaid;
    public string fileid;
    public string url;
    public string folderid;
    public int formid;
    public string status;
    [JsonProperty(PropertyName = "file_type")]
    public string fileType;
    [JsonProperty(PropertyName = "file_convert")]
    public string fileConvert;
    public string ver;
  }

  public enum ProjectStatus
  {
    STATE_PROGRESS = 2,
    STATE_FINISHED = 3,
    STATE_ERROR = 4,
    STATE_PROTECTED = 6,
  }
}
