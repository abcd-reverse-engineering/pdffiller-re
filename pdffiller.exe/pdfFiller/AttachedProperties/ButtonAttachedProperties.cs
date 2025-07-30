// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.ButtonAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Media;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class ButtonAttachedProperties
{
  public static readonly DependencyProperty ButtonIconProperty = DependencyProperty.RegisterAttached("ButtonIcon", typeof (ImageSource), typeof (ButtonAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ButtonAttachedProperties.OnIconSourceChanged)));
  public static readonly DependencyProperty ButtonIconHeightProperty = DependencyProperty.RegisterAttached("ButtonIconHeight", typeof (int), typeof (ButtonAttachedProperties), new PropertyMetadata((object) 0, new PropertyChangedCallback(ButtonAttachedProperties.OnIconHeightChanged)));
  public static readonly DependencyProperty ButtonIconWidthProperty = DependencyProperty.RegisterAttached("ButtonIconWidth", typeof (int), typeof (ButtonAttachedProperties), new PropertyMetadata((object) 0, new PropertyChangedCallback(ButtonAttachedProperties.OnIconWidthChanged)));
  public static readonly DependencyProperty ButtonCornerRadiusProperty = DependencyProperty.RegisterAttached("ButtonCornerRadius", typeof (CornerRadius), typeof (ButtonAttachedProperties), new PropertyMetadata((object) new CornerRadius(), new PropertyChangedCallback(ButtonAttachedProperties.OnButtonCornerRadiusChanged)));

  private static void OnIconSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonAttachedProperties.SetButtonIcon(d, e.NewValue);
  }

  public static void SetButtonIcon(DependencyObject d, object value)
  {
    d.SetValue(ButtonAttachedProperties.ButtonIconProperty, value);
  }

  public static object GetButtonIcon(DependencyObject d)
  {
    return d.GetValue(ButtonAttachedProperties.ButtonIconProperty);
  }

  private static void OnIconHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonAttachedProperties.SetButtonIconHeight(d, e.NewValue);
  }

  public static void SetButtonIconHeight(DependencyObject d, object value)
  {
    d.SetValue(ButtonAttachedProperties.ButtonIconHeightProperty, value);
  }

  public static object GetButtonIconHeight(DependencyObject d)
  {
    return d.GetValue(ButtonAttachedProperties.ButtonIconHeightProperty);
  }

  private static void OnIconWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonAttachedProperties.SetButtonIconWidth(d, e.NewValue);
  }

  public static void SetButtonIconWidth(DependencyObject d, object value)
  {
    d.SetValue(ButtonAttachedProperties.ButtonIconWidthProperty, value);
  }

  public static object GetButtonIconWidth(DependencyObject d)
  {
    return d.GetValue(ButtonAttachedProperties.ButtonIconWidthProperty);
  }

  private static void OnButtonCornerRadiusChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ButtonAttachedProperties.SetButtonCornerRadius(d, e.NewValue);
  }

  public static void SetButtonCornerRadius(DependencyObject d, object value)
  {
    d.SetValue(ButtonAttachedProperties.ButtonIconProperty, value);
  }

  public static object GetButtonCornerRadius(DependencyObject d)
  {
    return d.GetValue(ButtonAttachedProperties.ButtonIconProperty);
  }
}
