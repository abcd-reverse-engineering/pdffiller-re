// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.ProjectsStructure
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure.Actions;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class ProjectsStructure
{
  public List<Project> projects;
  public int page;
  public int pagesCount;
  public int projectsCount;
  public ActionsConstants mask;

  public ProjectsStructure(
    List<Project> projects,
    int page,
    int pagesCount,
    ActionsConstants mask,
    int projectsCount = 0)
  {
    this.projects = projects;
    this.page = page;
    this.pagesCount = pagesCount;
    this.projectsCount = projectsCount;
    this.mask = mask;
  }

  public bool HasNexPage() => this.page < this.pagesCount;

  public int GetNexPage() => this.page + 1;
}
