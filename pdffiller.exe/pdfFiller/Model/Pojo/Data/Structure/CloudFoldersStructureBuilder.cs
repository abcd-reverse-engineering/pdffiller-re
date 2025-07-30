// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.CloudFoldersStructureBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class CloudFoldersStructureBuilder : FoldersStructureBuilder
{
  public FoldersStructure build(FoldersStructureResponse response)
  {
    Folder folderByName = response.getFolderByName("cloud");
    return new FoldersStructure(new List<object>((IEnumerable<object>) folderByName.subFolders.Values.ToList<Folder>()), folderByName);
  }
}
