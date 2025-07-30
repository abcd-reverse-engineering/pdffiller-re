// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.FoldersStructureResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure.Actions;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class FoldersStructureResponse
{
  public FoldersStructureResponse.Rows rows;
  public ActionsConstants mask;

  public Folder getFolderByName(string folderName)
  {
    return FoldersStructureResponse.getFolderByName(folderName, this.rows.folders);
  }

  public void RemoveUnsuportedFolders()
  {
    this.rows.folders["myBox"].subFolders.Remove("id_-14");
    Folder folder = this.rows.folders["outbox"];
    folder.subFolders.Remove("irs");
    folder.subFolders.Remove("signnow");
    folder.subFolders.Remove("notarize");
  }

  public static Folder getFolderByName(string folderName, Dictionary<string, Folder> folders)
  {
    for (int index = 0; index < folders.Count; ++index)
    {
      KeyValuePair<string, Folder> keyValuePair = folders.ElementAt<KeyValuePair<string, Folder>>(index);
      if (keyValuePair.Key.Equals(folderName))
        return keyValuePair.Value;
      if (keyValuePair.Value.subFolders != null)
      {
        Folder folderByName = FoldersStructureResponse.getFolderByName(folderName, keyValuePair.Value.subFolders);
        if (folderByName != null)
          return folderByName;
      }
    }
    return (Folder) null;
  }

  public static Folder GetFolderById(long id, List<object> folders)
  {
    for (int index = 0; index < folders.Count; ++index)
    {
      object folder = folders[index];
      if (folder is Folder)
      {
        Folder folderById1 = folder as Folder;
        if (folderById1.id == id)
          return folderById1;
        if (folderById1.subFolders != null)
        {
          Folder folderById2 = FoldersStructureResponse.GetFolderById(id, new List<object>((IEnumerable<object>) folderById1.subFolders.Values.ToList<Folder>()));
          if (folderById2 != null)
            return folderById2;
        }
      }
    }
    return (Folder) null;
  }

  public class Rows
  {
    public Dictionary<string, Folder> folders;
  }
}
