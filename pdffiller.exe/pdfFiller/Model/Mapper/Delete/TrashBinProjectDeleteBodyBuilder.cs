// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.TrashBinProjectDeleteBodyBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

public class TrashBinProjectDeleteBodyBuilder : BaseProjectDeleteBodyBuilder
{
  public override Dictionary<string, object> Build(Project value)
  {
    Dictionary<string, object> dictionary = base.Build(value);
    dictionary["projects[0][projectId]"] = (object) value.projectId;
    dictionary["projects[0][systemId]"] = (object) value.systemId;
    dictionary["projects[0][folderId]"] = (object) value.folderId;
    return dictionary;
  }

  protected override string GetDeleteType() => "DELETE_TYPE_TRASH_BIN";
}
