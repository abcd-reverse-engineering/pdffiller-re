// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Amplitude.AmplitudeRestInterface
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Model.Amplitude;

public interface AmplitudeRestInterface
{
  [Post("/2/httpapi")]
  Task<AmplitudeResponse> SendEvents([Body] Dictionary<string, object> body);
}
