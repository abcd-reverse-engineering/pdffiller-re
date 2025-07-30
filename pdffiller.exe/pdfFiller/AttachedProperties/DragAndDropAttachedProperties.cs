// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.DragAndDropAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class DragAndDropAttachedProperties
{
  public static readonly DependencyProperty DragAndDropCommandProperty = DependencyProperty.RegisterAttached("DragAndDropCommand", typeof (ICommand), typeof (DragAndDropAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(DragAndDropAttachedProperties.OnCommandAttachedChanged)));

  private static void OnCommandAttachedChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    DragAndDropAttachedProperties.SetDragAndDropCommand(d, e.NewValue);
    UIElement uiElement = d as UIElement;
    uiElement.AllowDrop = true;
    uiElement.Drop += new DragEventHandler(DragAndDropAttachedProperties.OnDragAndDrop);
  }

  private static void OnDragAndDrop(object sender, DragEventArgs e)
  {
    if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      return;
    (DragAndDropAttachedProperties.GetDragAndDropCommand(sender as DependencyObject) as ICommand).Execute((object) (string[]) e.Data.GetData(DataFormats.FileDrop));
  }

  public static void SetDragAndDropCommand(DependencyObject d, object value)
  {
    d.SetValue(DragAndDropAttachedProperties.DragAndDropCommandProperty, value);
  }

  public static object GetDragAndDropCommand(DependencyObject d)
  {
    return d.GetValue(DragAndDropAttachedProperties.DragAndDropCommandProperty);
  }
}
