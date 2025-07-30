// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.View.ListViewSelectionItemChangedOnMouseUp
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Utils.View;

public class ListViewSelectionItemChangedOnMouseUp : ListView
{
  protected override void OnMouseUp(MouseButtonEventArgs e)
  {
    if (e.ChangedButton != MouseButton.Left)
      return;
    DependencyObject dependencyObject = this.ContainerFromElement((DependencyObject) e.OriginalSource);
    if (dependencyObject == null || !(dependencyObject is FrameworkElement frameworkElement) || !(frameworkElement is ListViewItem listViewItem))
      return;
    this.SelectedItem = listViewItem.DataContext;
  }

  protected override void OnPreviewMouseDown(MouseButtonEventArgs e) => e.Handled = true;
}
