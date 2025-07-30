// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TrashBin.TrashBinViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.UI.Main;
using pdfFiller.ViewModel;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.TrashBin;

public class TrashBinViewModel : BaseViewModel
{
  public ICommand CloseCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DIManager.BusManager.GetRouter(MainViewModel.KEY).SendData(MainViewModel.KEY, (object) MainControlContent.BACK)));
}
