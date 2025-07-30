// Decompiled with JetBrains decompiler
// Type: pdfFiller.AttachedProperties.ContextMenuAttachedProperties
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.ContextMenus.ActionsMenu;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace pdfFiller.AttachedProperties;

public class ContextMenuAttachedProperties
{
  public static readonly DependencyProperty IsLeftClickContextMenuProperty = DependencyProperty.RegisterAttached("IsLeftClickContextMenu", typeof (bool), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) false, new PropertyChangedCallback(ContextMenuAttachedProperties.OnIsLeftClickEnabledChanged)));
  public static readonly DependencyProperty IsRightClickContextMenuProperty = DependencyProperty.RegisterAttached("IsRightClickContextMenu", typeof (bool), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) false, new PropertyChangedCallback(ContextMenuAttachedProperties.OnIsRightClickEnabledChanged)));
  public static readonly DependencyProperty IsLeftClickChildContextMenuProperty = DependencyProperty.RegisterAttached("IsLeftClickChildContextMenu", typeof (bool), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) false, new PropertyChangedCallback(ContextMenuAttachedProperties.OnIsLeftClickChildEnabledChanged)));
  public static readonly DependencyProperty ItemClickOwnerCommandProperty = DependencyProperty.RegisterAttached("ItemClickOwnerCommand", typeof (ICommand), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ContextMenuAttachedProperties.ItemClickOwnerCommandChanged)));
  public static readonly DependencyProperty ItemClickCommandProperty = DependencyProperty.RegisterAttached("ItemClickCommand", typeof (ICommand), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ContextMenuAttachedProperties.OnItemClickCommandChanged)));
  public static readonly DependencyProperty ContextMenuTagProperty = DependencyProperty.RegisterAttached("ContextMenuTag", typeof (object), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ContextMenuAttachedProperties.OnContextMenuTagChanged)));
  public static readonly DependencyProperty ContextMenuDataContextTagProperty = DependencyProperty.RegisterAttached("ContextMenuDataContext", typeof (object), typeof (ContextMenuAttachedProperties), new PropertyMetadata((object) null, new PropertyChangedCallback(ContextMenuAttachedProperties.OnContextMenuDataContextChanged)));

  private static void OnIsLeftClickEnabledChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement uiElement))
      return;
    bool flag = e.NewValue is bool && (bool) e.NewValue;
    if (flag)
    {
      if (uiElement is ButtonBase)
        ((ButtonBase) uiElement).Click += new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUp);
      else
        uiElement.MouseLeftButtonUp += new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUp);
    }
    else if (uiElement is ButtonBase)
      ((ButtonBase) uiElement).Click -= new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUp);
    else
      uiElement.MouseLeftButtonUp -= new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUp);
    ContextMenuAttachedProperties.SetIsLeftClickContextMenu(d, (object) flag);
  }

  private static void OnMouseLeftButtonUp(object sender, RoutedEventArgs e)
  {
    if (!(sender is FrameworkElement frameworkElement))
      return;
    frameworkElement.ContextMenu.IsOpen = true;
  }

  public static void SetIsLeftClickContextMenu(DependencyObject d, object value)
  {
    d.SetValue(ContextMenuAttachedProperties.IsLeftClickContextMenuProperty, value);
  }

  public static object GetIsLeftClickContextMenu(DependencyObject d)
  {
    return d.GetValue(ContextMenuAttachedProperties.IsLeftClickContextMenuProperty);
  }

  private static void OnIsRightClickEnabledChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement uiElement))
      return;
    bool flag = e.NewValue is bool && (bool) e.NewValue;
    if (flag)
    {
      if (uiElement is ButtonBase)
        ((ButtonBase) uiElement).Click += new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseRightButtonUp);
      else
        uiElement.MouseRightButtonUp += new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseRightButtonUp);
    }
    else if (uiElement is ButtonBase)
      ((ButtonBase) uiElement).Click -= new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseRightButtonUp);
    else
      uiElement.MouseRightButtonUp -= new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseRightButtonUp);
    ContextMenuAttachedProperties.SetIsRightClickContextMenu(d, (object) flag);
  }

  private static void OnMouseRightButtonUp(object sender, RoutedEventArgs e)
  {
    if (!(sender is FrameworkElement frameworkElement))
      return;
    if ((sender as FrameworkElement).DataContext is ActionsHolder dataContext)
    {
      frameworkElement.ContextMenu.IsEnabled = true;
      frameworkElement.ContextMenu.IsOpen = true;
      frameworkElement.ContextMenu.Tag = frameworkElement.DataContext;
      (frameworkElement.ContextMenu.DataContext as ActionsMenuViewModel).BuildItemsList(dataContext);
    }
    else
    {
      if (frameworkElement.ContextMenu == null)
        return;
      frameworkElement.ContextMenu.IsOpen = false;
      frameworkElement.ContextMenu.IsEnabled = false;
      frameworkElement.ContextMenu = (ContextMenu) null;
    }
  }

  public static void SetIsRightClickContextMenu(DependencyObject d, object value)
  {
    d.SetValue(ContextMenuAttachedProperties.IsRightClickContextMenuProperty, value);
  }

  public static object GetIsRightClickContextMenu(DependencyObject d)
  {
    return d.GetValue(ContextMenuAttachedProperties.IsRightClickContextMenuProperty);
  }

  private static void OnIsLeftClickChildEnabledChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    UIElement reference = d as UIElement;
    VisualTreeHelper.GetParent((DependencyObject) reference);
    if (reference == null)
      return;
    bool flag = e.NewValue is bool && (bool) e.NewValue;
    if (flag)
    {
      if (reference is ButtonBase)
        ((ButtonBase) reference).Click += new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUpParent);
      else
        reference.MouseLeftButtonUp += new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUpParent);
    }
    else if (reference is ButtonBase)
      ((ButtonBase) reference).Click -= new RoutedEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUpParent);
    else
      reference.MouseLeftButtonUp -= new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftButtonUpParent);
    ContextMenuAttachedProperties.SetIsLeftClickChildContextMenu(d, (object) flag);
  }

  private static void OnMouseLeftButtonUpParent(object sender, RoutedEventArgs e)
  {
    FrameworkElement listViewItem = (FrameworkElement) ContextMenuAttachedProperties.GetListViewItem(sender);
    if (listViewItem == null)
      return;
    ActionsHolder dataContext = (sender as FrameworkElement).DataContext as ActionsHolder;
    listViewItem.ContextMenu.IsOpen = true;
    listViewItem.ContextMenu.Tag = listViewItem.DataContext;
    (listViewItem.ContextMenu.DataContext as ActionsMenuViewModel).BuildItemsList(dataContext);
  }

  private static ListViewItem GetListViewItem(object sender)
  {
    FrameworkElement parent = VisualTreeHelper.GetParent((DependencyObject) (sender as FrameworkElement)) as FrameworkElement;
    while (!(parent is ListViewItem))
      parent = VisualTreeHelper.GetParent((DependencyObject) parent) as FrameworkElement;
    return parent as ListViewItem;
  }

  public static void SetIsLeftClickChildContextMenu(DependencyObject d, object value)
  {
    d.SetValue(ContextMenuAttachedProperties.IsLeftClickChildContextMenuProperty, value);
  }

  public static object GetIsLeftClickChildContextMenu(DependencyObject d)
  {
    return d.GetValue(ContextMenuAttachedProperties.IsLeftClickChildContextMenuProperty);
  }

  private static void ItemClickOwnerCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is MenuItem menuItem))
      return;
    if (e.NewValue != null)
    {
      menuItem.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseOwnerLeftDown);
    }
    else
    {
      if (e.OldValue == null)
        return;
      menuItem.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseOwnerLeftDown);
    }
  }

  private static void OnMouseOwnerLeftDown(object sender, MouseButtonEventArgs e)
  {
    MenuItem element = sender as MenuItem;
    ICommand clickOwnerCommand = ContextMenuAttachedProperties.GetItemClickOwnerCommand((DependencyObject) element);
    ContextMenu menuFromMenuItem = ContextMenuAttachedProperties.GetContextMenuFromMenuItem(element);
    if (!(menuFromMenuItem.Tag is ActionsHolder))
      return;
    clickOwnerCommand.Execute((object) new Tuple<ActionMenuItem, ActionsHolder>(element.DataContext as ActionMenuItem, menuFromMenuItem.Tag as ActionsHolder));
  }

  private static ContextMenu GetContextMenuFromMenuItem(MenuItem item)
  {
    FrameworkElement parent = VisualTreeHelper.GetParent((DependencyObject) item) as FrameworkElement;
    while (!(parent is ContextMenu))
      parent = VisualTreeHelper.GetParent((DependencyObject) parent) as FrameworkElement;
    return parent as ContextMenu;
  }

  public static void SetItemClickOwnerCommand(DependencyObject element, ICommand value)
  {
    element.SetValue(ContextMenuAttachedProperties.ItemClickOwnerCommandProperty, (object) value);
  }

  public static ICommand GetItemClickOwnerCommand(DependencyObject element)
  {
    return (ICommand) element.GetValue(ContextMenuAttachedProperties.ItemClickOwnerCommandProperty);
  }

  private static void OnItemClickCommandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is MenuItem menuItem))
      return;
    if (e.NewValue != null)
    {
      menuItem.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftDown);
    }
    else
    {
      if (e.OldValue == null)
        return;
      menuItem.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(ContextMenuAttachedProperties.OnMouseLeftDown);
    }
  }

  private static void OnMouseLeftDown(object sender, MouseButtonEventArgs e)
  {
    MenuItem menuItem = sender as MenuItem;
    ContextMenuAttachedProperties.GetItemClickCommand((DependencyObject) menuItem).Execute((object) menuItem);
  }

  public static void SetItemClickCommand(DependencyObject element, ICommand value)
  {
    element.SetValue(ContextMenuAttachedProperties.ItemClickCommandProperty, (object) value);
  }

  public static ICommand GetItemClickCommand(DependencyObject element)
  {
    return (ICommand) element.GetValue(ContextMenuAttachedProperties.ItemClickCommandProperty);
  }

  private static void OnContextMenuTagChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ContextMenuAttachedProperties.SetContextMenuTag(d, e.NewValue);
    (d as FrameworkElement).ContextMenuOpening += new ContextMenuEventHandler(ContextMenuAttachedProperties.ContextMenuOpeningHandler);
  }

  private static void ContextMenuOpeningHandler(object sender, ContextMenuEventArgs e)
  {
    (sender as FrameworkElement).ContextMenu.Tag = sender;
  }

  public static void SetContextMenuTag(DependencyObject d, object value)
  {
    d.SetValue(ContextMenuAttachedProperties.ContextMenuTagProperty, value);
  }

  public static object GetContextMenuTag(DependencyObject d)
  {
    return d.GetValue(ContextMenuAttachedProperties.ContextMenuTagProperty);
  }

  private static void OnContextMenuDataContextChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ContextMenuAttachedProperties.SetContextMenuDataContext(d, e.NewValue);
    (d as FrameworkElement).ContextMenu.DataContext = e.NewValue;
  }

  public static void SetContextMenuDataContext(DependencyObject d, object value)
  {
    d.SetValue(ContextMenuAttachedProperties.ContextMenuDataContextTagProperty, value);
  }

  public static object GetContextMenuDataContext(DependencyObject d)
  {
    return d.GetValue(ContextMenuAttachedProperties.ContextMenuDataContextTagProperty);
  }
}
