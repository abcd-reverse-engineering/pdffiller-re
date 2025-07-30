// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.TabItemProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class TabItemProperties
{
  public static readonly DependencyProperty TabImageSourceProperty = DependencyProperty.RegisterAttached("TabImageSource", typeof (ImageSource), typeof (TabItemProperties), new PropertyMetadata((object) null));
  public static readonly DependencyProperty TabImageSourceSelectedProperty = DependencyProperty.RegisterAttached("TabImageSourceSelected", typeof (ImageSource), typeof (TabItemProperties), new PropertyMetadata((object) null));
  public static readonly DependencyProperty TabTitleProperty = DependencyProperty.RegisterAttached("TabTitle", typeof (string), typeof (TabItemProperties), new PropertyMetadata((object) ""));
  public static readonly DependencyProperty IndicatorVisibilityProperty = DependencyProperty.RegisterAttached("IndicatorVisibility", typeof (Visibility), typeof (TabItemProperties), new PropertyMetadata((object) Visibility.Collapsed));
  public static readonly DependencyProperty CounterProperty = DependencyProperty.RegisterAttached("Counter", typeof (string), typeof (TabItemProperties), new PropertyMetadata((object) ""));

  public static ImageSource GetTabImageSource(TabItem d)
  {
    return d.GetValue(TabItemProperties.TabImageSourceProperty) as ImageSource;
  }

  public static void SetTabImageSource(TabItem d, ImageSource value)
  {
    d.SetValue(TabItemProperties.TabImageSourceProperty, (object) value);
  }

  public static ImageSource GetTabImageSourceSelected(TabItem d)
  {
    return d.GetValue(TabItemProperties.TabImageSourceSelectedProperty) as ImageSource;
  }

  public static void SetTabImageSourceSelected(TabItem d, ImageSource value)
  {
    d.SetValue(TabItemProperties.TabImageSourceSelectedProperty, (object) value);
  }

  public static string GetTabTitle(TabItem d)
  {
    return d.GetValue(TabItemProperties.TabTitleProperty) as string;
  }

  public static void SetTabTitle(TabItem d, string value)
  {
    d.SetValue(TabItemProperties.TabTitleProperty, (object) value);
  }

  public static Visibility GetIndicatorVisibility(TabItem d)
  {
    return (Visibility) d.GetValue(TabItemProperties.IndicatorVisibilityProperty);
  }

  public static void SetIndicatorVisibility(TabItem d, Visibility value)
  {
    d.SetValue(TabItemProperties.IndicatorVisibilityProperty, (object) value);
  }

  public static string GetCounter(TabItem d)
  {
    return (string) d.GetValue(TabItemProperties.CounterProperty);
  }

  public static void SetCounter(TabItem d, string value)
  {
    d.SetValue(TabItemProperties.CounterProperty, (object) value);
  }
}
