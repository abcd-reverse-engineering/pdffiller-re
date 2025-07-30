// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.MyDocs.MyDocsFilesListViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.UI.FilesList;

#nullable disable
namespace pdfFiller.UI.MyDocs;

public class MyDocsFilesListViewModel : FilesListViewModel
{
  protected override bool CanOpenProject() => true;

  protected override string GetBusManagerKey() => "TabsAndFoldersViewModel";
}
