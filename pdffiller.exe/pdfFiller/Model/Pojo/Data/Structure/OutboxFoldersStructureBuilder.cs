// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.OutboxFoldersStructureBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure;

public class OutboxFoldersStructureBuilder : FoldersStructureBuilder
{
  private Dictionary<string, int> foldersOrder = new Dictionary<string, int>()
  {
    ["email"] = 0,
    ["fax"] = 1,
    ["usps"] = 2,
    ["s2s"] = 3,
    ["link2fill"] = 4,
    ["share"] = 5
  };

  public FoldersStructure build(FoldersStructureResponse response)
  {
    Folder folderByName = response.getFolderByName("outbox");
    List<Folder> collection = folderByName.subFolders.OrderBy<KeyValuePair<string, Folder>, int>((Func<KeyValuePair<string, Folder>, int>) (item =>
    {
      try
      {
        return this.foldersOrder[item.Key];
      }
      catch (KeyNotFoundException ex)
      {
        return 100;
      }
    })).ToList<KeyValuePair<string, Folder>>().ConvertAll<Folder>((Converter<KeyValuePair<string, Folder>, Folder>) (item => item.Value));
    List<object> folders = new List<object>();
    folders.Add((object) new ListDivider("Sent"));
    folders.AddRange((IEnumerable<object>) collection);
    return new FoldersStructure(folders, folderByName);
  }
}
