// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Uploader.FileUploader
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.common;
using pdfFiller.Exceptions;
using pdfFiller.Model.Api;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.UI.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Utils.Uploader;

public class FileUploader
{
  private const long MAX_FILE_SIZE = 26214400 /*0x01900000*/;
  private const long MAX_RETRY_COUNT = 50;
  private DataProvider dataManager;
  private int retryCount;

  public FileUploader(DataProvider dataManager) => this.dataManager = dataManager;

  public async Task Upload(string file)
  {
    if (new FileInfo(file).Length > 26214400L /*0x01900000*/)
      throw new FileSizeException();
    EditorConnector editorConnector = await this.dataManager.GetEditorConnector(long.Parse((await this.CheckUploadState((await this.dataManager.UploadFiles((IEnumerable<string>) new List<string>()
    {
      file
    }))[0].id)).project.id));
    LifecycleEventDispatcherControl.GetInstance().OnNewPage((UserControl) new EditorControl(editorConnector));
  }

  private async Task<ProjectInfoResponse> CheckUploadState(long id)
  {
    FileUploader fileUploader1 = this;
    ProjectInfoResponse projectInfo = await fileUploader1.dataManager.GetProjectInfo(id);
    if (projectInfo.GetProjectStatus() == ProjectInfoResponse.ProjectStatus.STATE_FINISHED)
      return projectInfo;
    FileUploader fileUploader2 = fileUploader1;
    int retryCount = fileUploader1.retryCount;
    int num = retryCount + 1;
    fileUploader2.retryCount = num;
    if (retryCount > 50)
      throw new FileUploadError();
    await Task.Delay(TimeSpan.FromMilliseconds(20.0));
    return await fileUploader1.CheckUploadState(id);
  }
}
