// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.AddDocumentMenu.AddDocumentType
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.ContextMenus.AddDocumentMenu;

public class AddDocumentType
{
  public int id;

  public string ImageSource { get; set; }

  public string Name { get; set; }

  public ICommand ClickCommand { get; }

  public AddDocumentType(int id, string imageSource, string name, ICommand clickCommand)
  {
    this.ImageSource = imageSource;
    this.Name = name;
    this.id = id;
    this.ClickCommand = clickCommand;
  }
}
