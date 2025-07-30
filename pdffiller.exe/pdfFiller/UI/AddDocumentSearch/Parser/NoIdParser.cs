// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddDocumentSearch.Parser.NoIdParser
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.AddDocumentSearch.Parser;

public class NoIdParser : IUrlParser
{
  public const string FILL_FORM_URL_START_WITH = "pdffiller://fill?url=";

  public Task<long> ParseUrl(DataProvider dataProvider, string url)
  {
    string url1 = url.Substring("pdffiller://fill?url=".Length);
    return dataProvider.AddProjectByLink(url1);
  }
}
