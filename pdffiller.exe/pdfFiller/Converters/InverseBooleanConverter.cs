// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.InverseBooleanConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class InverseBooleanConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (targetType != typeof (bool))
      throw new InvalidOperationException("The target must be a boolean");
    return (object) !(bool) value;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotSupportedException();
  }
}
