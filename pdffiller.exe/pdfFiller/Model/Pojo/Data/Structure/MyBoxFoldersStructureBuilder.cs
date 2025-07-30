// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.MyBoxFoldersStructureBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using pdfFiller.Utils;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class MyBoxFoldersStructureBuilder : FoldersStructureBuilder
{
  public FoldersStructure build(FoldersStructureResponse response)
  {
    Folder folderByName = response.getFolderByName("myBox");
    List<object> list = new List<object>((IEnumerable<object>) folderByName.subFolders.Values.ToList<Folder>()).Prepend<object>((object) folderByName).ToList<object>().Prepend<object>((object) new ListDivider("Folders")).ToList<object>();
    list.Insert(3, (object) response.getFolderByName("template"));
    list.Add((object) new ListDivider("More"));
    list.Add((object) response.getFolderByName("suggested_documents"));
    return new FoldersStructure(list, folderByName);
  }
}
