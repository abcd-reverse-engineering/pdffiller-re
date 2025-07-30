// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.AddDocumentMenu.AddDocumentMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.ViewModel;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.ContextMenus.AddDocumentMenu;

public class AddDocumentMenuViewModel : BaseViewModel
{
  public ObservableCollection<AddDocumentType> Types => AddDocumentTypesManager.Types;
}
