// Decompiled with JetBrains decompiler
// Type: pdfFiller.Bus.BackStackHandler`1
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.Bus;

public class BackStackHandler<T>
{
  private Stack<T> stack = new Stack<T>();
  private T _root;

  public T CurrentItem { get; set; }

  public T Root
  {
    get => this._root;
    set
    {
      this._root = value;
      this.CurrentItem = value;
      this.stack.Clear();
    }
  }

  public T Previous
  {
    get
    {
      return this.stack.Count<T>() != 0 ? this.stack.ElementAt<T>(this.stack.Count<T>() - 1) : this.Root;
    }
  }

  public T Back()
  {
    this.CurrentItem = this.stack.Count == 0 ? this.Root : this.stack.Pop();
    return this.CurrentItem;
  }

  public void Add(T item)
  {
    if (this.CurrentItem.Equals((object) this.Root))
    {
      this.CurrentItem = item;
    }
    else
    {
      this.stack.Push(this.CurrentItem);
      this.CurrentItem = item;
    }
  }

  public void Clear()
  {
    this.Root = default (T);
    this.CurrentItem = this.Root;
    this.stack.Clear();
  }

  internal bool HasItems()
  {
    if (this.stack.Count<T>() > 0)
      return true;
    return (object) this.CurrentItem != null && !this.CurrentItem.Equals((object) this.Root);
  }
}
