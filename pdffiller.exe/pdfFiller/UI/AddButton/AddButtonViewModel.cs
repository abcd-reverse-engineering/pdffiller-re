// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddButton.AddButtonViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.AddButton;

public class AddButtonViewModel : BaseViewModel
{
  private AddButtonSizeController _sizeController = new AddButtonSizeController();

  public int CurrentWidth => this._sizeController.CurrentWidth;

  public int CollapsedWidth => this._sizeController.CollapsedWidth;

  public int NormalWidth => this._sizeController.NormalWidth;

  public bool IsButtonCollapsed => this._sizeController.IsButtonCollapsed;

  public int CornerRadius => this._sizeController.CornerRadius;

  public ICommand AddButtonCommand { get; }

  public AddButtonViewModel()
  {
    this.AddButtonCommand = (ICommand) new RelayCommand((Action<object>) (button =>
    {
      (button as Button).ContextMenu.IsOpen = true;
      this._sizeController.IsButtonCollapsed = true;
      this.NotifyProperty(nameof (IsButtonCollapsed));
    }));
  }
}
