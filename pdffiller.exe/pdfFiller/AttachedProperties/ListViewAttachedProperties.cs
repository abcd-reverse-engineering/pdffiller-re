// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.ListViewAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class ListViewAttachedProperties
{
  public static readonly DependencyProperty ScrollChangedCommandProperty = DependencyProperty.RegisterAttached("ScrollChangedCommand", typeof (ICommand), typeof (ListViewAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ListViewAttachedProperties.OnScrollChangedCommandChanged)));
  public static readonly DependencyProperty ItemClickCommandListBoxProperty = DependencyProperty.RegisterAttached("ItemClickCommandListBox", typeof (ICommand), typeof (ListViewAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ListViewAttachedProperties.OnItemClickListBoxCommandChanged)));
  public static readonly DependencyProperty ItemClickCommandProperty = DependencyProperty.RegisterAttached("ItemClickCommand", typeof (ICommand), typeof (ListViewAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ListViewAttachedProperties.OnItemClickCommandChanged)));

  private static void OnScrollChangedCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is ListView listView))
      return;
    if (e.NewValue != null)
    {
      listView.Loaded += new RoutedEventHandler(ListViewAttachedProperties.ListViewOnLoaded);
    }
    else
    {
      if (e.OldValue == null)
        return;
      listView.Loaded -= new RoutedEventHandler(ListViewAttachedProperties.ListViewOnLoaded);
    }
  }

  private static void ListViewOnLoaded(object sender, RoutedEventArgs routedEventArgs)
  {
    if (!(sender is ListView element))
      return;
    ScrollViewer scrollViewer = UIHelper.FindChildren<ScrollViewer>((DependencyObject) element).FirstOrDefault<ScrollViewer>();
    if (scrollViewer == null)
      return;
    scrollViewer.ScrollChanged += new ScrollChangedEventHandler(ListViewAttachedProperties.ScrollViewerOnScrollChanged);
  }

  private static void ScrollViewerOnScrollChanged(object sender, ScrollChangedEventArgs e)
  {
    ListView parent = UIHelper.FindParent<ListView>((DependencyObject) (sender as ScrollViewer));
    if (parent == null)
      return;
    ListViewAttachedProperties.GetScrollChangedCommand((DependencyObject) parent).Execute((object) e);
  }

  public static void SetScrollChangedCommand(DependencyObject element, ICommand value)
  {
    element.SetValue(ListViewAttachedProperties.ScrollChangedCommandProperty, (object) value);
  }

  public static ICommand GetScrollChangedCommand(DependencyObject element)
  {
    return (ICommand) element.GetValue(ListViewAttachedProperties.ScrollChangedCommandProperty);
  }

  private static void OnItemClickListBoxCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is ListBoxItem listBoxItem))
      return;
    if (e.NewValue != null)
    {
      listBoxItem.MouseLeftButtonUp += new MouseButtonEventHandler(ListViewAttachedProperties.OnMouseLeftDownListBox);
    }
    else
    {
      if (e.OldValue == null)
        return;
      listBoxItem.MouseLeftButtonUp -= new MouseButtonEventHandler(ListViewAttachedProperties.OnMouseLeftDownListBox);
    }
  }

  private static void OnMouseLeftDownListBox(object sender, MouseButtonEventArgs e)
  {
    ListBoxItem element = sender as ListBoxItem;
    ListViewAttachedProperties.GetItemClickCommandListBox((DependencyObject) element).Execute(element.DataContext);
  }

  public static void SetItemClickCommandListBox(DependencyObject element, ICommand value)
  {
    element.SetValue(ListViewAttachedProperties.ItemClickCommandListBoxProperty, (object) value);
  }

  public static ICommand GetItemClickCommandListBox(DependencyObject element)
  {
    return (ICommand) element.GetValue(ListViewAttachedProperties.ItemClickCommandListBoxProperty);
  }

  private static void OnItemClickCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is ListViewItem listViewItem))
      return;
    if (e.NewValue != null)
    {
      listViewItem.PreviewMouseDoubleClick += new MouseButtonEventHandler(ListViewAttachedProperties.OnMouseLeftDown);
    }
    else
    {
      if (e.OldValue == null)
        return;
      listViewItem.PreviewMouseDoubleClick -= new MouseButtonEventHandler(ListViewAttachedProperties.OnMouseLeftDown);
    }
  }

  private static void OnMouseLeftDown(object sender, MouseButtonEventArgs e)
  {
    ListViewItem element = sender as ListViewItem;
    ListViewAttachedProperties.GetItemClickCommand((DependencyObject) element).Execute(element.DataContext);
  }

  public static void SetItemClickCommand(DependencyObject element, ICommand value)
  {
    element.SetValue(ListViewAttachedProperties.ItemClickCommandProperty, (object) value);
  }

  public static ICommand GetItemClickCommand(DependencyObject element)
  {
    return (ICommand) element.GetValue(ListViewAttachedProperties.ItemClickCommandProperty);
  }
}
