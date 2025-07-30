// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.StringPatternToBooleanConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public abstract class StringPatternToBooleanConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) this.IsDataCorrect((string) value);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }

  protected abstract bool IsDataCorrect(string data);
}
