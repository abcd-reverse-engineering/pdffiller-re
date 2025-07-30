// Decompiled with JetBrains decompiler
// Type: pdfFiller.common.PropertyNotifier
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.ComponentModel;

#nullable disable
namespace pdfFiller.common;

public abstract class PropertyNotifier : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler PropertyChanged;

  protected void NotifyProperty(string property)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(property));
  }
}
