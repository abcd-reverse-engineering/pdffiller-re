// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.EmptyFolders.EmptyFolderViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.ViewModel;

#nullable disable
namespace pdfFiller.UI.EmptyFolders;

public class EmptyFolderViewModel : BaseViewModel
{
  public string ImageSource { get; set; }

  public string Title { get; set; }

  public string Message { get; set; }
}
