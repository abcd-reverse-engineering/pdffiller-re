// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.TabCustomizer
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure;

#nullable disable
namespace pdfFiller.UI.TabsFolders;

public interface TabCustomizer
{
  void Customize(FoldersStructure foldersStructure, Tab tab);
}
