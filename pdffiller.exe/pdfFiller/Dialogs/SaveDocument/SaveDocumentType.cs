// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.SaveDocument.SaveDocumentType
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Dialogs.SaveDocument;

public class SaveDocumentType
{
  public static List<SaveDocumentType> Items = new List<SaveDocumentType>()
  {
    new SaveDocumentType("/pdfFiller;component/Resources/Images/Projects/pdf.png", "*.pdf", ResourcesUtils.GetStringResource("save_as_pdf"), "pdf"),
    new SaveDocumentType("/pdfFiller;component/Resources/Images/Projects/word.png", "*.docx", ResourcesUtils.GetStringResource("save_as_doc"), "word"),
    new SaveDocumentType("/pdfFiller;component/Resources/Images/Projects/excel.png", "*.xlsx", ResourcesUtils.GetStringResource("save_as_excel"), "excel"),
    new SaveDocumentType("/pdfFiller;component/Resources/Images/Projects/ppt.png", "*.pptx", ResourcesUtils.GetStringResource("save_as_ppt"), "powerpoint")
  };

  public string Image { get; }

  public string Extension { get; }

  public string Title { get; }

  public string Type { get; }

  public SaveDocumentType(string image, string extension, string title, string type)
  {
    this.Image = image;
    this.Extension = extension;
    this.Title = title;
    this.Type = type;
  }
}
