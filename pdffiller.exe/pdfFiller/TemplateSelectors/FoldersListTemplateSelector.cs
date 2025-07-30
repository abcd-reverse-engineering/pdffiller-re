// Decompiled with JetBrains decompiler
// Type: pdfFiller.TemplateSelectors.FoldersListTemplateSelector
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.TemplateSelectors;

public class FoldersListTemplateSelector : DataTemplateSelector
{
  public DataTemplate FoldersTemplate { get; set; }

  public DataTemplate DividerTemplate { get; set; }

  public override DataTemplate SelectTemplate(object item, DependencyObject container)
  {
    return item is Folder ? this.FoldersTemplate : this.DividerTemplate;
  }
}
