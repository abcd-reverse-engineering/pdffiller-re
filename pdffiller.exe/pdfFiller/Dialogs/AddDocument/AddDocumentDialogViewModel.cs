// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.AddDocument.AddDocumentDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.Win32;
using pdfFiller.Commnands;
using pdfFiller.di;
using pdfFiller.Utils;
using pdfFiller.Utils.Uploader;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.Dialogs.AddDocument;

public class AddDocumentDialogViewModel : BaseViewModel
{
  private FileUploader _fileUploader;

  public ICommand DragAndDropCommand { get; set; }

  public ICommand OpenFilePickerDialogCommand { get; set; }

  public AddDocumentDialogViewModel()
  {
    this._fileUploader = new FileUploader(this.dataManager);
    this.DragAndDropCommand = (ICommand) new RelayCommand((Action<object>) (files => this.UploadFile((files as string[])[0])));
    this.OpenFilePickerDialogCommand = (ICommand) new SimpleCommand((Action) (() =>
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = FileUtils.GetFilterString();
      bool? nullable = openFileDialog.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      this.UploadFile(openFileDialog.FileName);
    }));
  }

  private async void UploadFile(string file)
  {
    AddDocumentDialogViewModel documentDialogViewModel = this;
    if (!FileUtils.IsFileAccepted(file))
      return;
    documentDialogViewModel.IsLoading = true;
    try
    {
      await documentDialogViewModel._fileUploader.Upload(file);
      DIManager.AnalyticsManager.TrackEvent("upload", "device");
      DIManager.AmplitudeManager.AddEvent("Document Added", new Dictionary<string, object>()
      {
        {
          "add_type",
          (object) "upload"
        }
      });
      DialogFactory.HideDialog();
    }
    catch (Exception ex)
    {
      DialogFactory.HideDialog();
      if (ex is TaskCanceledException)
      {
        DialogFactory.ShowAlertMessageBox(ResourcesUtils.GetStringResource("timeout_error"));
        return;
      }
      documentDialogViewModel.HandleError(ex);
    }
    documentDialogViewModel.IsLoading = false;
  }
}
