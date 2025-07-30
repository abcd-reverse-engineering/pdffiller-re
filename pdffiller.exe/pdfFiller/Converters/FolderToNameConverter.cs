// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.FolderToNameConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class FolderToNameConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    switch (value)
    {
      case null:
      case Project _:
        return (object) "";
      default:
        return (object) (value as Folder).Name;
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) new Folder();
  }
}
