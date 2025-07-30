// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AddButton.AddButtonSizeController
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Properties;

#nullable disable
namespace pdfFiller.UI.AddButton;

public class AddButtonSizeController
{
  private const string SETTINGS_KEY = "IS_ADD_BTN_COLLAPSED";
  public int CollapsedWidth = 46;

  public bool IsButtonCollapsed
  {
    get => (bool) Settings.Default["IS_ADD_BTN_COLLAPSED"];
    set
    {
      Settings.Default["IS_ADD_BTN_COLLAPSED"] = (object) value;
      Settings.Default.Save();
    }
  }

  public int CurrentWidth => this.IsButtonCollapsed ? this.CollapsedWidth : this.NormalWidth;

  public int NormalWidth => this.CollapsedWidth * 5;

  public int CornerRadius => this.CollapsedWidth / 2;
}
