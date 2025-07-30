// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.OutboxTabCustomizer
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data.Structure;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.TabsFolders;

public class OutboxTabCustomizer : TabCustomizer
{
  public void Customize(FoldersStructure foldersStructure, Tab tab)
  {
    tab.Folders = new ObservableCollection<object>(foldersStructure.folders);
  }
}
