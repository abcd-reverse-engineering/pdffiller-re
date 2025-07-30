// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.Delete.ShareFolderDeleteMapper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Mapper.Delete;

public class ShareFolderDeleteMapper : FolderDeleteMapper
{
  protected override string GetDeleteType() => "DELETE_TYPE_SHARE_INBOX";
}
