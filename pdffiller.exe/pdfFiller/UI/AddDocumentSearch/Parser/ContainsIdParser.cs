// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddDocumentSearch.Parser.ContainsIdParser
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using System;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.AddDocumentSearch.Parser;

public class ContainsIdParser : IUrlParser
{
  public const string FILL_FORM_URL_START_WITH = "pdffiller://fill?id=";

  public Task<long> ParseUrl(DataProvider dataProvider, string url)
  {
    return Task.Run<long>((Func<long>) (() => long.Parse(url.Substring("pdffiller://fill?id=".Length))));
  }
}
