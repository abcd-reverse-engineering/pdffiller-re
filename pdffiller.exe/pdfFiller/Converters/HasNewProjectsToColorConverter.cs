// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.HasNewProjectsToColorConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

#nullable disable
namespace pdfFiller.Converters;

public class HasNewProjectsToColorConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) new SolidColorBrush((bool) value ? Colors.White : Color.FromRgb((byte) 151, (byte) 153, (byte) 155));
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) true;
  }
}
