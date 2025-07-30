// Decompiled with JetBrains decompiler
// Type: pdfFiller.Exceptions.FileUploadError
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System;

#nullable disable
namespace pdfFiller.Exceptions;

public class FileUploadError : Exception
{
  public override string Message => ResourcesUtils.GetStringResource("file_upload_error_message");
}
