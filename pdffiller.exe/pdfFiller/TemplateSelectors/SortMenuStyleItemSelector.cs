// Decompiled with JetBrains decompiler
// Type: pdfFiller.TemplateSelectors.SortMenuStyleItemSelector
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.UI.ContextMenus.SortMenu;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.TemplateSelectors;

public class SortMenuStyleItemSelector : StyleSelector
{
  public Style HeaderStyle { get; set; }

  public Style ItemStyle { get; set; }

  public override Style SelectStyle(object item, DependencyObject container)
  {
    return (item as SortMenuItem).IsHeader ? this.HeaderStyle : this.ItemStyle;
  }
}
