// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.FoldersStructureBuilderFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class FoldersStructureBuilderFactory
{
  public static FoldersStructureBuilder Create(int tabId)
  {
    switch (tabId)
    {
      case 0:
        return (FoldersStructureBuilder) new MyBoxFoldersStructureBuilder();
      case 1:
        return (FoldersStructureBuilder) new CloudFoldersStructureBuilder();
      case 2:
        return (FoldersStructureBuilder) new InboxFoldersStructureBuilder();
      case 3:
        return (FoldersStructureBuilder) new OutboxFoldersStructureBuilder();
      default:
        return (FoldersStructureBuilder) null;
    }
  }
}
