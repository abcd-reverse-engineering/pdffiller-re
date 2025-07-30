// Decompiled with JetBrains decompiler
// Type: pdfFiller.TemplateSelectors.ProjectFolderTemplateSelector
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.TemplateSelectors;

public class ProjectFolderTemplateSelector : DataTemplateSelector
{
  public DataTemplate ProjectTemplate { get; set; }

  public DataTemplate ThreeLineProjectTemplate { get; set; }

  public DataTemplate InboxS2SProjectTemplate { get; set; }

  public DataTemplate FolderTemplate { get; set; }

  public DataTemplate TopFormTemplate { get; set; }

  public override DataTemplate SelectTemplate(object item, DependencyObject container)
  {
    if (item is Folder)
      return this.FolderTemplate;
    Project project = item as Project;
    if (project.IsInboxEmail || project.IsOutBoxEmail || project.IsSharedWithMe || project.IsOutBoxShare || project.IsOutBoxS2S || project.IsUsps)
      return this.ThreeLineProjectTemplate;
    return project.IsSignatureRequest ? this.InboxS2SProjectTemplate : this.ProjectTemplate;
  }
}
