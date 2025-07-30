// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.FilleCheckBoxAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class FilleCheckBoxAttachedProperties
{
  public static readonly DependencyProperty TextLeftProperty = DependencyProperty.RegisterAttached("TextLeft", typeof (string), typeof (FilleCheckBoxAttachedProperties), new PropertyMetadata((object) "", new PropertyChangedCallback(FilleCheckBoxAttachedProperties.OnTextLeftChanged)));
  public static readonly DependencyProperty TextRightProperty = DependencyProperty.RegisterAttached("TextRight", typeof (string), typeof (FilleCheckBoxAttachedProperties), new PropertyMetadata((object) "", new PropertyChangedCallback(FilleCheckBoxAttachedProperties.OnTextRightChanged)));

  private static void OnTextLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    FilleCheckBoxAttachedProperties.SetTextLeft(d, e.NewValue as string);
  }

  private static void OnTextRightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    FilleCheckBoxAttachedProperties.SetTextRight(d, e.NewValue as string);
  }

  public static void SetTextLeft(DependencyObject d, string value)
  {
    d.SetValue(FilleCheckBoxAttachedProperties.TextLeftProperty, (object) value);
  }

  public static string GetTextLeft(DependencyObject d)
  {
    return d.GetValue(FilleCheckBoxAttachedProperties.TextLeftProperty) as string;
  }

  public static void SetTextRight(DependencyObject d, string value)
  {
    d.SetValue(FilleCheckBoxAttachedProperties.TextRightProperty, (object) value);
  }

  public static string GetTextRight(DependencyObject d)
  {
    return d.GetValue(FilleCheckBoxAttachedProperties.TextRightProperty) as string;
  }
}
