// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.CopyTemplateResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class CopyTemplateResponse
{
  [JsonProperty(PropertyName = "new_project_id")]
  public long projectId;
}
