// Decompiled with JetBrains decompiler
// Type: pdfFiller.Bus.Refresh.RefreshDispatcher
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Bus.Refresh;

public class RefreshDispatcher
{
  private Dictionary<string, RefreshConsumer> _consumers = new Dictionary<string, RefreshConsumer>();

  public void RegisterConsumer(string key, RefreshConsumer consumer)
  {
    this._consumers[key] = consumer;
  }

  public void Refresh(string key) => this._consumers[key].Refresh();

  public void RefreshAll()
  {
    this._consumers.First<KeyValuePair<string, RefreshConsumer>>().Value.Refresh();
  }
}
