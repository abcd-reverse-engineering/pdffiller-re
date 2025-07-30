// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.Settings.SettingMenuItem
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using System;
using System.Windows.Input;

#nullable disable
namespace pdfFiller.UI.ContextMenus.Settings;

public class SettingMenuItem
{
  private SettingMenuItem.SettingFlagProvider _settingFlagProvider;
  private SettingMenuItem.GettingFlagProvider _gettingFlagProvider;

  public string Image { get; }

  public string Name { get; }

  public bool IsEnabled => this._gettingFlagProvider();

  public ICommand ToggleCommand { get; }

  public SettingMenuItem(
    string image,
    string name,
    SettingMenuItem.SettingFlagProvider settingFlagProvider,
    SettingMenuItem.GettingFlagProvider gettingFlagProvider)
  {
    this.Image = image;
    this.Name = name;
    this._settingFlagProvider = settingFlagProvider;
    this._gettingFlagProvider = gettingFlagProvider;
    this.ToggleCommand = (ICommand) new RelayCommand(new Action<object>(this.OnNewSettingValue));
  }

  private void OnNewSettingValue(object value) => this._settingFlagProvider((bool) value);

  public delegate void SettingFlagProvider(bool value);

  public delegate bool GettingFlagProvider();
}
