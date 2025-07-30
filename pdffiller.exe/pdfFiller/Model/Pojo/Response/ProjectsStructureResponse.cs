// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.ProjectsStructureResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using pdfFiller.Model.Pojo.Data.Structure.Actions;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class ProjectsStructureResponse
{
  public List<pdfFiller.Model.Pojo.Data.Project> rows;
  public ActionsConstants mask;
  public int page;

  [JsonProperty(PropertyName = "count_pages")]
  public int pagesCount { get; set; }

  [JsonProperty(PropertyName = "count_projects")]
  public int countProjects { get; set; }
}
