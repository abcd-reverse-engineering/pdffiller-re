// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddDocumentSearch.AddDocumentSearchViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Model.Api;
using pdfFiller.UI.AddDocumentSearch.Parser;
using pdfFiller.UI.Editor;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.AddDocumentSearch;

public class AddDocumentSearchViewModel : BaseViewModel
{
  public ICommand BackCommand { get; } = (ICommand) new SimpleCommand((Action) (() => LifecycleEventDispatcherControl.GetInstance().BackPress()));

  public AddressListener AddressListener { get; set; }

  public async void LoadData()
  {
    AddDocumentSearchViewModel documentSearchViewModel = this;
    documentSearchViewModel.IsLoading = true;
    try
    {
      string module = await documentSearchViewModel.dataManager.GetModule("search");
      documentSearchViewModel.AddressListener.OnAddressReady(module);
    }
    catch (Exception ex)
    {
      documentSearchViewModel.HandleError(ex);
    }
    documentSearchViewModel.IsLoading = false;
  }

  public async void ProcessUrl(string url)
  {
    AddDocumentSearchViewModel documentSearchViewModel = this;
    IUrlParser urlParser = UrlParsersFactory.Create(url);
    if (urlParser == null)
      return;
    documentSearchViewModel.IsLoading = true;
    try
    {
      DIManager.AnalyticsManager.TrackEvent("upload", "library");
      DIManager.AmplitudeManager.AddEvent("Document Added", new Dictionary<string, object>()
      {
        {
          "add_type",
          (object) "search"
        }
      });
      long url1 = await urlParser.ParseUrl(documentSearchViewModel.dataManager, url);
      EditorConnector editorConnector = await documentSearchViewModel.dataManager.GetEditorConnector(url1);
      LifecycleEventDispatcherControl.GetInstance().OnNewPageAndKillCurrent((UserControl) new EditorControl(editorConnector));
    }
    catch (Exception ex)
    {
      documentSearchViewModel.HandleError(ex);
    }
    documentSearchViewModel.IsLoading = false;
  }
}
