// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.BaseProjectDeleteBodyBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

public abstract class BaseProjectDeleteBodyBuilder : PostBodyBuilder<Project>
{
  public virtual Dictionary<string, object> Build(Project value)
  {
    return new Dictionary<string, object>()
    {
      ["selectedFolder"] = (object) value.folderId,
      ["type"] = (object) this.GetDeleteType()
    };
  }

  protected abstract string GetDeleteType();
}
