// Decompiled with JetBrains decompiler
// Type: pdfFiller.Commnands.RelayCommand
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Commnands;

public class RelayCommand : ICommand
{
  private Action<object> execute;
  private Func<object, bool> canExecute;

  public event EventHandler CanExecuteChanged
  {
    add => CommandManager.RequerySuggested += value;
    remove => CommandManager.RequerySuggested -= value;
  }

  public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
  {
    this.execute = execute;
    this.canExecute = canExecute;
  }

  public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);

  public void Execute(object parameter) => this.execute(parameter);
}
