// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.OutBoxShareProjectDeleteBodyBuilder
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

internal class OutBoxShareProjectDeleteBodyBuilder : BaseProjectDeleteBodyBuilder
{
  public override Dictionary<string, object> Build(Project value)
  {
    Dictionary<string, object> dictionary = base.Build(value);
    dictionary["projects[0][projectId]"] = (object) value.projectId;
    if (value.status.shareType == 2)
      dictionary["projects[0][projectViaLinkListIds]"] = (object) value.systemId;
    else
      dictionary["projects[0][projectListIds]"] = (object) value.systemId;
    dictionary["folders[]"] = (object) "";
    return dictionary;
  }

  protected override string GetDeleteType() => "DELETE_TYPE_SHARE_OUTBOX";
}
