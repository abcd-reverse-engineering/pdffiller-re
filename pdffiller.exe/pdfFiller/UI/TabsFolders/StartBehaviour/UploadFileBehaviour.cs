// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.StartBehaviour.UploadFileBehaviour
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Dialogs;
using pdfFiller.Utils.Uploader;
using System;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.TabsFolders.StartBehaviour;

public class UploadFileBehaviour : IBehaviour
{
  public async Task DoOnSuccessLogin(TabsAndFoldersViewModel viewModel)
  {
    try
    {
      DialogFactory.ShowLoader();
      await new FileUploader(viewModel.dataManager).Upload(viewModel.FileAssociationHandler.GetFileToUpload());
      DialogFactory.DissmisLoader();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      viewModel.HandleError(ex);
    }
  }
}
