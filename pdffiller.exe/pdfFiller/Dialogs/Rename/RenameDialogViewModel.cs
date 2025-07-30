// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.Rename.RenameDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.Rename;

public abstract class RenameDialogViewModel : BaseViewModel
{
  protected ActionsHolder ActionsHolder;
  private string _name;

  public string Name
  {
    get => this._name;
    set
    {
      this._name = value;
      this.NotifyProperty(nameof (Name));
    }
  }

  public string Title => this.GetTitle();

  public string Message => this.GetMessage();

  public ICommand ConfirmCommand { get; }

  public RenameDialogViewModel(ActionsHolder holder)
  {
    this.ActionsHolder = holder;
    this.ConfirmCommand = (ICommand) new SimpleCommand(new Action(this.OnConfirmCommand));
    this._name = holder.GetName();
  }

  public virtual string GetTitle() => ResourcesUtils.GetStringResource("rename_folder_title");

  public virtual string GetMessage() => ResourcesUtils.GetStringResource("rename_folder_message");

  public abstract void OnConfirmCommand();
}
