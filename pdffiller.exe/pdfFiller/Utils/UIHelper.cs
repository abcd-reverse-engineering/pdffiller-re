// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.UIHelper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace pdfFiller.Utils;

internal static class UIHelper
{
  internal static IList<T> FindChildren<T>(DependencyObject element) where T : FrameworkElement
  {
    List<T> children = new List<T>();
    for (int childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(element); ++childIndex)
    {
      if (VisualTreeHelper.GetChild(element, childIndex) is FrameworkElement child)
      {
        if (child is T obj)
          children.Add(obj);
        else
          children.AddRange((IEnumerable<T>) UIHelper.FindChildren<T>((DependencyObject) child));
      }
    }
    return (IList<T>) children;
  }

  internal static T FindParent<T>(DependencyObject element) where T : FrameworkElement
  {
    if (!(VisualTreeHelper.GetParent(element) is FrameworkElement parent))
      return default (T);
    return parent is T obj ? obj : UIHelper.FindParent<T>((DependencyObject) parent);
  }
}
