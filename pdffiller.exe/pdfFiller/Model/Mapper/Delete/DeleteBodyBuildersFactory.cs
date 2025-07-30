// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.DeleteBodyBuildersFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

public class DeleteBodyBuildersFactory
{
  public const string DELETE_TYPE_TRASH_BIN = "DELETE_TYPE_TRASH_BIN";
  public const string DELETE_TYPE_SHARE_INBOX = "DELETE_TYPE_SHARE_INBOX";
  public const string DELETE_TYPE_SHARE_OUTBOX = "DELETE_TYPE_SHARE_OUTBOX";
  public const string DELETE_TYPE_COMMON = "DELETE_TYPE_COMMON";
  private static Dictionary<List<long>, BaseProjectDeleteBodyBuilder> ProjectDeleteBodyBuilders = new Dictionary<List<long>, BaseProjectDeleteBodyBuilder>()
  {
    [new List<long>() { -4L, -9L, -10L, -3L }] = (BaseProjectDeleteBodyBuilder) new CommonProjectDeleteBodyBuilder(),
    [new List<long>() { -2L }] = (BaseProjectDeleteBodyBuilder) new InBoxShareProjectDeleteBodyBuilder(),
    [new List<long>() { -7L }] = (BaseProjectDeleteBodyBuilder) new OutBoxShareProjectDeleteBodyBuilder()
  };

  public static BaseProjectDeleteBodyBuilder GetBuilderByFolderId(Project project)
  {
    long num = project.folderId;
    if (project.IsSignatureRequest || project.IsOutBoxS2S)
      num = -4L;
    foreach (KeyValuePair<List<long>, BaseProjectDeleteBodyBuilder> deleteBodyBuilder in DeleteBodyBuildersFactory.ProjectDeleteBodyBuilders)
    {
      if (deleteBodyBuilder.Key.Contains(num))
        return deleteBodyBuilder.Value;
    }
    return (BaseProjectDeleteBodyBuilder) new TrashBinProjectDeleteBodyBuilder();
  }
}
