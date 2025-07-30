// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.AddDocumentMenu.AddDocumentTypesManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Dialogs.AddDocument;
using pdfFiller.UI.AddDocumentSearch;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.ContextMenus.AddDocumentMenu;

public class AddDocumentTypesManager
{
  public const int UPLOAD_ID = 0;
  public const int SEARCH_ID = 1;
  public static ObservableCollection<AddDocumentType> Types;

  static AddDocumentTypesManager()
  {
    ObservableCollection<AddDocumentType> observableCollection = new ObservableCollection<AddDocumentType>();
    observableCollection.Add(new AddDocumentType(0, "/pdfFiller;component/Resources/Images/AddDocument/upload.png", ResourcesUtils.GetStringResource("add_document_upload"), (ICommand) new SimpleCommand((Action) (() =>
    {
      DialogFactory.ShowDialog((UserControl) new AddDocumentDialog());
      DIManager.AnalyticsManager.TrackPage("add_new_device");
      DIManager.AmplitudeManager.AddEvent("Add Document Clicked", new Dictionary<string, object>()
      {
        {
          "add_type",
          (object) "upload"
        }
      });
    }))));
    observableCollection.Add(new AddDocumentType(1, "/pdfFiller;component/Resources/Images/AddDocument/search.png", ResourcesUtils.GetStringResource("add_document_search"), (ICommand) new SimpleCommand((Action) (() =>
    {
      LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new AddDocumentSearchControl());
      DIManager.AnalyticsManager.TrackPage("add_new_search_in_library");
      DIManager.AmplitudeManager.AddEvent("Add Document Clicked", new Dictionary<string, object>()
      {
        {
          "add_type",
          (object) "search"
        }
      });
    }))));
    AddDocumentTypesManager.Types = observableCollection;
  }
}
