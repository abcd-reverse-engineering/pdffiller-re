// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddDocumentSearch.Parser.UrlParsersFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.UI.AddDocumentSearch.Parser;

public class UrlParsersFactory
{
  public static bool IsUrlCorrect(string url)
  {
    return url.StartsWith("pdffiller://fill?id=") || url.StartsWith("pdffiller://fill?url=");
  }

  public static IUrlParser Create(string Url)
  {
    if (Url.StartsWith("pdffiller://fill?id="))
      return (IUrlParser) new ContainsIdParser();
    return Url.StartsWith("pdffiller://fill?url=") ? (IUrlParser) new NoIdParser() : (IUrlParser) null;
  }
}
