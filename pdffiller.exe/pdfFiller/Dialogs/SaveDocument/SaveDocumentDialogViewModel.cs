// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.SaveDocument.SaveDocumentDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Win32;
using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Exceptions;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.SaveDocument;

public class SaveDocumentDialogViewModel : BaseViewModel
{
  private SaveDocumentType _selectedType = SaveDocumentType.Items[0];

  public ObservableCollection<SaveDocumentType> Types { get; } = new ObservableCollection<SaveDocumentType>(SaveDocumentType.Items);

  public SaveDocumentType SelectedType
  {
    get => this._selectedType;
    set
    {
      this._selectedType = value;
      this.NotifyProperty(nameof (SelectedType));
    }
  }

  public ICommand DownloadCommand { get; }

  public pdfFiller.Model.Pojo.Data.Project Project { get; internal set; }

  public SaveDocumentDialogViewModel()
  {
    this.DownloadCommand = (ICommand) new SimpleCommand((Action) (() => this.DownloadFile()));
  }

  private async void DownloadFile()
  {
    SaveDocumentDialogViewModel documentDialogViewModel = this;
    try
    {
      DialogFactory.HideDialog();
      DialogFactory.ShowLoader();
      SaveAsResponse saveAsResponse = await documentDialogViewModel.dataManager.SaveAs(documentDialogViewModel.Project.projectId, documentDialogViewModel.SelectedType.Type);
      DialogFactory.DissmisLoader();
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = documentDialogViewModel.Project.Name;
      saveFileDialog.AddExtension = true;
      saveFileDialog.DefaultExt = Path.GetExtension(documentDialogViewModel.SelectedType.Extension);
      saveFileDialog.Filter = $"{documentDialogViewModel.SelectedType.Title}|{documentDialogViewModel.SelectedType.Extension}";
      bool? nullable = saveFileDialog.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      DialogFactory.ShowLoader();
      await documentDialogViewModel.dataManager.DownloadFile(saveAsResponse.url, saveFileDialog.FileName);
      DIManager.AmplitudeManager.AddEvent("Document Action Completed", new Dictionary<string, object>()
      {
        {
          "action_type",
          (object) "save_as"
        },
        {
          "doc_format",
          (object) (!(documentDialogViewModel.SelectedType.Type == "pdf") ? (!(documentDialogViewModel.SelectedType.Type == "word") ? (!(documentDialogViewModel.SelectedType.Type == "excel") ? "pptx" : "xls") : "docx") : "pdf")
        }
      });
      LifecycleEventDispatcherControl.GetInstance().ShowSnackbar("Downloaded");
      DialogFactory.DissmisLoader();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      if (ex is FillerRestException)
        DialogFactory.ShowAlertMessageBox(ResourcesUtils.GetStringResource("file_download_error_message"));
      else
        documentDialogViewModel.HandleError(ex);
    }
  }
}
