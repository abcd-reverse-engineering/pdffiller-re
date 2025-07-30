// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Mapper.PostBodyBuilder`1
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Mapper;

public interface PostBodyBuilder<in T>
{
  Dictionary<string, object> Build(T value);
}
