// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.TextBoxAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class TextBoxAttachedProperties
{
  public static readonly DependencyProperty OnTextChangeCommandProperty = DependencyProperty.RegisterAttached("OnTextChangeCommand", typeof (ICommand), typeof (TextBoxAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(TextBoxAttachedProperties.OnTextChangeCommandChanged)));
  public static readonly DependencyProperty CaretIndexProperty = DependencyProperty.RegisterAttached("CaretIndex", typeof (int), typeof (TextBoxAttachedProperties), new PropertyMetadata((object) 0, new PropertyChangedCallback(TextBoxAttachedProperties.OnCaretIndexChanged)));

  private static void OnTextChangeCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is TextBox textBox))
      return;
    if (e.NewValue != null)
    {
      textBox.TextChanged += new TextChangedEventHandler(TextBoxAttachedProperties.OnTextChanged);
    }
    else
    {
      if (e.OldValue == null)
        return;
      textBox.TextChanged -= new TextChangedEventHandler(TextBoxAttachedProperties.OnTextChanged);
    }
  }

  private static void OnTextChanged(object sender, TextChangedEventArgs e)
  {
    TextBoxAttachedProperties.GetOnTextChangeCommand(sender as DependencyObject).Execute((object) e);
  }

  public static void SetOnTextChangeCommand(DependencyObject element, ICommand value)
  {
    element.SetValue(TextBoxAttachedProperties.OnTextChangeCommandProperty, (object) value);
  }

  public static ICommand GetOnTextChangeCommand(DependencyObject element)
  {
    return (ICommand) element.GetValue(TextBoxAttachedProperties.OnTextChangeCommandProperty);
  }

  private static void OnCaretIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (!(d is TextBox textBox))
      return;
    textBox.Focus();
    textBox.CaretIndex = (int) e.NewValue;
  }

  public static void SetCaretIndex(DependencyObject element, int value)
  {
    element.SetValue(TextBoxAttachedProperties.CaretIndexProperty, (object) value);
  }

  public static int GetCaretIndex(DependencyObject element)
  {
    return (int) element.GetValue(TextBoxAttachedProperties.CaretIndexProperty);
  }
}
