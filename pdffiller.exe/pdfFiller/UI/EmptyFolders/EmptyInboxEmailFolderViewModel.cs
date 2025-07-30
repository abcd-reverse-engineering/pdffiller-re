// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.EmptyFolders.EmptyInboxEmailFolderViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.ViewModel;
using System;
using System.Windows;

#nullable disable
namespace pdfFiller.UI.EmptyFolders;

public class EmptyInboxEmailFolderViewModel : BaseViewModel
{
  public string Email => this.dataManager.GetFillerEmail();

  public SimpleCommand CopyToClipboard { get; }

  public EmptyInboxEmailFolderViewModel()
  {
    this.CopyToClipboard = new SimpleCommand((Action) (() => Clipboard.SetText(this.Email)));
  }
}
