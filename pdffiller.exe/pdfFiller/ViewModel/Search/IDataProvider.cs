// Decompiled with JetBrains decompiler
// Type: pdfFiller.ViewModel.Search.IDataProvider`1
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.ViewModel.Search;

public interface IDataProvider<T>
{
  void OnNewQuery(T result);
}
