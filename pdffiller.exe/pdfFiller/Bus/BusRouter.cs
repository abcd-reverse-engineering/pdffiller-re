// Decompiled with JetBrains decompiler
// Type: pdfFiller.Bus.BusRouter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace pdfFiller.Bus;

public class BusRouter : Router
{
  private Dictionary<string, RouterObserver> _observers = new Dictionary<string, RouterObserver>();
  private Dictionary<string, object> _postData = new Dictionary<string, object>();

  public void PostSendData(string key, object data)
  {
    if (this._observers.ContainsKey(key))
    {
      // ISSUE: reference to a compiler-generated field
      if (BusRouter.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BusRouter.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Action<CallSite, RouterObserver, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ObserveData", (IEnumerable<Type>) null, typeof (BusRouter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      BusRouter.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) BusRouter.\u003C\u003Eo__2.\u003C\u003Ep__0, this._observers[key], data);
    }
    else
      this._postData[key] = data;
  }

  public void RegisterObserver(string key, RouterObserver observer)
  {
    this._observers[key] = observer;
    if (!this._postData.ContainsKey(key))
      return;
    // ISSUE: reference to a compiler-generated field
    if (BusRouter.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BusRouter.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Action<CallSite, RouterObserver, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ObserveData", (IEnumerable<Type>) null, typeof (BusRouter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      }));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    BusRouter.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) BusRouter.\u003C\u003Eo__3.\u003C\u003Ep__0, observer, this._postData[key]);
  }

  public void SendData(string key, object data)
  {
    // ISSUE: reference to a compiler-generated field
    if (BusRouter.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BusRouter.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Action<CallSite, RouterObserver, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ObserveData", (IEnumerable<Type>) null, typeof (BusRouter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      }));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    BusRouter.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) BusRouter.\u003C\u003Eo__4.\u003C\u003Ep__0, this._observers[key], data);
  }
}
