// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.StartBehaviour.LoadMyDocsBehaviour
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.TabsFolders.StartBehaviour;

public class LoadMyDocsBehaviour : IBehaviour
{
  public async Task DoOnSuccessLogin(TabsAndFoldersViewModel viewModel)
  {
    viewModel.IsLoading = true;
    try
    {
      viewModel.TabsController.ProvideData(await viewModel.dataManager.GetStructure());
    }
    catch (Exception ex)
    {
      viewModel.HandleError(ex);
    }
    viewModel.IsLoading = false;
  }
}
