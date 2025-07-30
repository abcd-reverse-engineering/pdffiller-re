// Decompiled with JetBrains decompiler
// Type: pdfFiller.Exceptions.FileSizeException
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;

#nullable disable
namespace pdfFiller.Exceptions;

public class FileSizeException : FillerRestException
{
  public FileSizeException()
    : base(ResourcesUtils.GetStringResource("file_size_error_message"), ResourcesUtils.GetStringResource("file_size_error_title"))
  {
  }

  public FileSizeException(string message)
    : base(message)
  {
  }

  public FileSizeException(string message, string title)
    : base(message, title)
  {
  }
}
