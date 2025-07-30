// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.SaveAsResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class SaveAsResponse
{
  public string url;
  public SaveAsResponse.Options options;

  public class Options
  {
    public string fileName;
  }
}
