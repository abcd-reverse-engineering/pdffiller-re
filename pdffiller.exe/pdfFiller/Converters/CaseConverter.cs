// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.CaseConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class CaseConverter : IValueConverter
{
  public CharacterCasing Case { get; set; }

  public CaseConverter() => this.Case = CharacterCasing.Upper;

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (!(value is string str))
      return (object) string.Empty;
    switch (this.Case)
    {
      case CharacterCasing.Normal:
        return (object) str;
      case CharacterCasing.Lower:
        return (object) str.ToLower();
      case CharacterCasing.Upper:
        return (object) str.ToUpper();
      default:
        return (object) str;
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
