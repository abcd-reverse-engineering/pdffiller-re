// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.SideMenu.SideMenuItem
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;

#nullable disable
namespace pdfFiller.UI.SideMenu;

public class SideMenuItem
{
  public string ImageSource { get; set; }

  public string Title { get; set; }

  public Action ItemClick { get; set; }
}
