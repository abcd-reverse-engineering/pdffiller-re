// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.FindPdf.FindPdfViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.UI.Main;
using pdfFiller.ViewModel.Search;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.FindPdf;

public class FindPdfViewModel : BaseSearchViewModel
{
  public const string KEY = "FindPdfViewModel";
  private Router _router;

  public ICommand ClearCommand { get; }

  public bool HasQuery { get; private set; }

  public ICommand BackCommand { get; } = (ICommand) new SimpleCommand((Action) (() => DIManager.BusManager.GetRouter(MainViewModel.KEY).SendData(MainViewModel.KEY, (object) MainControlContent.BACK)));

  public FindPdfViewModel()
  {
    this._router = DIManager.BusManager.CreateRouter(nameof (FindPdfViewModel));
    this.ClearCommand = (ICommand) new SimpleCommand((Action) (() => this.Query = ""));
  }

  protected override void OnNewQuery(string result)
  {
    this.HasQuery = result != "";
    this.NotifyProperty("HasQuery");
    this._router.SendData("FilesListViewModel", (object) result);
  }
}
