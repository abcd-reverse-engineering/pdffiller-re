// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TrashBin.TrashBinFoldersViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.JustFolders;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.TrashBin;

public class TrashBinFoldersViewModel : JustFoldersViewModel
{
  public new const string KEY = "TrashBinFoldersViewModel";

  protected override int GetBoxId() => -100;

  protected override string GetBusManagerKey() => nameof (TrashBinFoldersViewModel);

  protected override Task<FoldersStructure> GetFoldersStructure()
  {
    return this.dataManager.GetTrashBinStructure();
  }
}
