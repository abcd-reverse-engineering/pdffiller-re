// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.CredentialsConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class CredentialsConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    return values.Clone();
  }

  public object[] ConvertBack(
    object value,
    Type[] targetTypes,
    object parameter,
    CultureInfo culture)
  {
    return new object[2];
  }
}
