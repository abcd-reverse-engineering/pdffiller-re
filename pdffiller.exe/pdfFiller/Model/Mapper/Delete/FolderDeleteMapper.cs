// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.FolderDeleteMapper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

public class FolderDeleteMapper : PostBodyBuilder<Folder>
{
  public virtual Dictionary<string, object> Build(Folder value)
  {
    return new Dictionary<string, object>()
    {
      ["folders[]"] = (object) value.id,
      ["type"] = (object) this.GetDeleteType()
    };
  }

  protected virtual string GetDeleteType() => "DELETE_TYPE_TRASH_BIN";
}
