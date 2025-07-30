// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TrashBin.TrashBinFilesListViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.UI.FilesList;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.UI.TrashBin;

public class TrashBinFilesListViewModel : FilesListViewModel
{
  protected override bool CanOpenProject() => false;

  protected override string GetBusManagerKey() => "TrashBinFoldersViewModel";

  protected override bool IsRecentsCanBeVisible() => false;

  protected override Folder GetFolderById<T>(T data, FoldersStructureResponse foldersStructure)
  {
    return FoldersStructureResponse.GetFolderById(((object) data as Tuple<long, int>).Item1, new List<object>((IEnumerable<object>) foldersStructure.getFolderByName("trash").subFolders.Values));
  }
}
