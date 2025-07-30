// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.InboxFoldersStructureBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using pdfFiller.Utils;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class InboxFoldersStructureBuilder : FoldersStructureBuilder
{
  public FoldersStructure build(FoldersStructureResponse response)
  {
    Folder folderByName = response.getFolderByName("inBox");
    folderByName.subFolders.Add("s2s_me", response.getFolderByName("s2s_me"));
    folderByName.subFolders.Add("shared", response.getFolderByName("shared"));
    List<object> folders = new List<object>();
    folders.Add((object) new ListDivider("Received"));
    folders.AddRange((IEnumerable<object>) folderByName.subFolders.Values.ToList<Folder>());
    return new FoldersStructure(folders, folderByName);
  }
}
