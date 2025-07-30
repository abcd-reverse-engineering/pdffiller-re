// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.ActionMenuItem
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu;

public class ActionMenuItem
{
  public string key;

  public ActionMenuItem(string key, string imageSource, string name)
  {
    this.key = key;
    this.Name = name;
    this.ImageSource = imageSource;
  }

  public string Name { get; set; }

  public string ImageSource { get; set; }
}
