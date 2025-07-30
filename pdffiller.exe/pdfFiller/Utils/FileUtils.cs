// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.FileUtils
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

#nullable disable
namespace pdfFiller.Utils;

public class FileUtils
{
  public static Dictionary<string, string> MimeTypes = new Dictionary<string, string>()
  {
    ["application/pdf"] = "/pdfFiller;component/Resources/Images/Porjects/pdf.png",
    ["application/msword"] = "/pdfFiller;component/Resources/Images/Porjects/word.png",
    ["application/vnd.openxmlformats-officedocument.wordprocessingml.document"] = "/pdfFiller;component/Resources/Images/Porjects/word.png",
    ["application/vnd.ms-powerpoint"] = "/pdfFiller;component/Resources/Images/Porjects/ppt.png",
    ["application/vnd.openxmlformats-officedocument.presentationml.presentation"] = "/pdfFiller;component/Resources/Images/Porjects/ppt.png",
    ["text/plain"] = "/pdfFiller;component/Resources/Images/Porjects/txt.png",
    ["image/jpeg"] = "/pdfFiller;component/Resources/Images/Porjects/image.png",
    ["image/jpg"] = "/pdfFiller;component/Resources/Images/Porjects/image.png",
    ["image/png"] = "/pdfFiller;component/Resources/Images/Porjects/image.png"
  };
  public static List<string> Extensions = new List<string>()
  {
    ".pdf",
    ".doc",
    ".docx",
    ".ppt",
    ".pptx",
    ".txt",
    ".jpeg",
    ".jpg",
    ".png"
  };

  public static string GetFilterString()
  {
    StringBuilder filterBuilder = new StringBuilder();
    StringBuilder filterBuilderAll = new StringBuilder();
    filterBuilderAll.Append("All Files|");
    FileUtils.Extensions.ForEach((Action<string>) (ex =>
    {
      filterBuilderAll.Append("*").Append(ex).Append(";");
      filterBuilder.Append("File ").Append("(").Append(ex).Append(")").Append("|").Append("*").Append(ex).Append("|");
    }));
    string str1 = filterBuilderAll.ToString();
    string str2 = filterBuilder.ToString();
    return $"{str1.Substring(0, str1.LastIndexOf(";"))}|{str2.Substring(0, str2.LastIndexOf("|"))}";
  }

  public static bool IsFileAccepted(string filePath)
  {
    string mimeMapping = MimeMapping.GetMimeMapping(filePath);
    return FileUtils.MimeTypes.Keys.Contains<string>(mimeMapping);
  }

  public static string GetMimeType(string file) => MimeMapping.GetMimeMapping(file);
}
