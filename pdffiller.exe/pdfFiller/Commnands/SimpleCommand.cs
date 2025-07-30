// Decompiled with JetBrains decompiler
// Type: pdfFiller.Commnands.SimpleCommand
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Commnands;

public class SimpleCommand : ICommand
{
  public Action action;

  public event EventHandler CanExecuteChanged;

  public SimpleCommand(Action a) => this.action = a;

  public SimpleCommand()
  {
  }

  public bool CanExecute(object parameter) => true;

  public void Execute(object parameter) => this.action();
}
