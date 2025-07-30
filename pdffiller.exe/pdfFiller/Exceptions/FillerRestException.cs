// Decompiled with JetBrains decompiler
// Type: pdfFiller.Exceptions.FillerRestException
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;

#nullable disable
namespace pdfFiller.Exceptions;

public class FillerRestException : Exception
{
  public virtual string ErrorTitle { get; private set; }

  public virtual string ErrorMessage { get; private set; }

  public FillerRestException(string message) => this.ErrorMessage = message;

  public FillerRestException(string message, string title)
  {
    this.ErrorMessage = message;
    this.ErrorTitle = title;
  }
}
