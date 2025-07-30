// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.CollectioncExtension
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Utils;

internal static class CollectioncExtension
{
  public static bool IsNullOrEmpty<T>(this IEnumerable<T> genericEnumerable)
  {
    return genericEnumerable == null || !genericEnumerable.Any<T>();
  }

  public static bool IsNullOrEmpty<T>(this ICollection<T> genericCollection)
  {
    return genericCollection == null || genericCollection.Count < 1;
  }
}
