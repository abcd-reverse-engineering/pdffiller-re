// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.FoldersStructure
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class FoldersStructure
{
  public List<object> folders;
  public Folder rootFolder;

  public FoldersStructure(List<object> folders, Folder rootFolder)
  {
    this.folders = folders;
    this.rootFolder = rootFolder;
  }
}
