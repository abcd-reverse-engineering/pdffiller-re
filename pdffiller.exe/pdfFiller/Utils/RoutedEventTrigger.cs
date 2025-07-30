// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.RoutedEventTrigger
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;

#nullable disable
namespace pdfFiller.Utils;

public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
{
  private RoutedEvent _routedEvent;

  public RoutedEvent RoutedEvent
  {
    get => this._routedEvent;
    set => this._routedEvent = value;
  }

  protected override void OnAttached()
  {
    Behavior associatedObject1 = this.AssociatedObject as Behavior;
    FrameworkElement associatedObject2 = this.AssociatedObject as FrameworkElement;
    if (associatedObject1 != null)
      associatedObject2 = ((IAttachedObject) associatedObject1).AssociatedObject as FrameworkElement;
    if (associatedObject2 == null)
      throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
    if (this.RoutedEvent == null)
      return;
    associatedObject2.AddHandler(this.RoutedEvent, (Delegate) new RoutedEventHandler(this.OnRoutedEvent));
  }

  private void OnRoutedEvent(object sender, RoutedEventArgs args) => this.OnEvent((EventArgs) args);

  protected override string GetEventName() => this.RoutedEvent.Name;
}
