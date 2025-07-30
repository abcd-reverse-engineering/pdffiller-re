// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.ApiExceptionsFactory
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Api.Handler;
using System;
using System.Net.Http;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Model.Api;

public class ApiExceptionsFactory
{
  private static ErrorHandler _errorHandler;

  public static async Task<Exception> ExceptionsFactory(HttpResponseMessage responseMessage)
  {
    if (ApiExceptionsFactory._errorHandler == null)
      ApiExceptionsFactory._errorHandler = (ErrorHandler) new ClassicErrorHandler();
    return await ApiExceptionsFactory._errorHandler.Handle(responseMessage);
  }
}
