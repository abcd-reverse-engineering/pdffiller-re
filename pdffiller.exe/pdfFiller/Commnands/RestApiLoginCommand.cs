// Decompiled with JetBrains decompiler
// Type: pdfFiller.RestApiLoginCommand
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller;

public class RestApiLoginCommand : ICommand
{
  private Action<string[]> _loginAction;

  public event EventHandler CanExecuteChanged;

  public RestApiLoginCommand(Action<string[]> _loginAction) => this._loginAction = _loginAction;

  public bool CanExecute(object parameter) => true;

  public void Execute(object parameter)
  {
    object[] objArray = parameter as object[];
    this._loginAction(new string[2]
    {
      objArray[0] as string,
      (objArray[1] as PasswordBox).Password
    });
  }
}
