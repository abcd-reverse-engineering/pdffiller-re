// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.Settings.SettingsMenuViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using pdfFiller.ViewModel;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.ContextMenus.Settings;

public class SettingsMenuViewModel : BaseViewModel
{
  public ObservableCollection<SettingMenuItem> SettingsItems { get; }

  public SettingsMenuViewModel()
  {
    this.SettingsItems = new ObservableCollection<SettingMenuItem>();
    if (!this.dataManager.IsBiometricAvailabile())
      return;
    this.SettingsItems.Add(new SettingMenuItem("/pdfFiller;component/Resources/Images/fingerprint.png", ResourcesUtils.GetStringResource("touch_id"), new SettingMenuItem.SettingFlagProvider(this.dataManager.SaveBiometricFlag), new SettingMenuItem.GettingFlagProvider(this.dataManager.GetBiometricFlag)));
  }
}
