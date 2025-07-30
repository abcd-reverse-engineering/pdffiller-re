// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.View.IndicatorsControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

#nullable disable
namespace pdfFiller.Utils.View;

public partial class IndicatorsControl : UserControl, IComponentConnector
{
  public static readonly DependencyProperty ItemsCountProperty = DependencyProperty.RegisterAttached(nameof (ItemsCount), typeof (int), typeof (IndicatorsControl), new PropertyMetadata((object) 2));
  public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.RegisterAttached(nameof (SelectedItem), typeof (int), typeof (IndicatorsControl), new PropertyMetadata((object) 1, new PropertyChangedCallback(IndicatorsControl.SelectedItemChanged)));
  internal StackPanel Canvas;
  private bool _contentLoaded;

  private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    (d as IndicatorsControl).buildControl();
  }

  public int ItemsCount
  {
    get => (int) this.GetValue(IndicatorsControl.ItemsCountProperty);
    set => this.SetValue(IndicatorsControl.ItemsCountProperty, (object) value);
  }

  public int SelectedItem
  {
    get => (int) this.GetValue(IndicatorsControl.SelectedItemProperty);
    set => this.SetValue(IndicatorsControl.SelectedItemProperty, (object) value);
  }

  public IndicatorsControl() => this.InitializeComponent();

  public void buildControl()
  {
    if (this.Canvas.Children.Count > 0)
      this.Canvas.Children.Clear();
    for (int index = 0; index < this.ItemsCount; ++index)
    {
      Ellipse element = new Ellipse();
      element.Margin = new Thickness(8.0, 0.0, 0.0, 8.0);
      if (index == this.SelectedItem)
      {
        element.Width = 10.0;
        element.Height = 10.0;
        element.Fill = (Brush) new SolidColorBrush(Color.FromRgb(byte.MaxValue, (byte) 153, (byte) 0));
      }
      else
      {
        element.Width = 8.0;
        element.Height = 8.0;
        element.Fill = (Brush) new SolidColorBrush(Color.FromRgb(byte.MaxValue, (byte) 223, (byte) 191));
      }
      this.Canvas.Children.Add((UIElement) element);
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/utils/view/indicatorscontrol.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.Canvas = (StackPanel) target;
    else
      this._contentLoaded = true;
  }
}
