// Decompiled with JetBrains decompiler
// Type: pdfFiller.Properties.Settings
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace pdfFiller.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
  private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

  public static Settings Default => Settings.defaultInstance;

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string LOGIN_RESPONSE
  {
    get => (string) this[nameof (LOGIN_RESPONSE)];
    set => this[nameof (LOGIN_RESPONSE)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string USER_INFO
  {
    get => (string) this[nameof (USER_INFO)];
    set => this[nameof (USER_INFO)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string SUBSCRIPTION
  {
    get => (string) this[nameof (SUBSCRIPTION)];
    set => this[nameof (SUBSCRIPTION)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string PROJECTS_MASK
  {
    get => (string) this[nameof (PROJECTS_MASK)];
    set => this[nameof (PROJECTS_MASK)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string FOLDERS_MASK
  {
    get => (string) this[nameof (FOLDERS_MASK)];
    set => this[nameof (FOLDERS_MASK)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool IS_ADD_BTN_COLLAPSED
  {
    get => (bool) this[nameof (IS_ADD_BTN_COLLAPSED)];
    set => this[nameof (IS_ADD_BTN_COLLAPSED)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string OPEN_WITH_FILE_PATH
  {
    get => (string) this[nameof (OPEN_WITH_FILE_PATH)];
    set => this[nameof (OPEN_WITH_FILE_PATH)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string SORTING
  {
    get => (string) this[nameof (SORTING)];
    set => this[nameof (SORTING)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool IS_BIOMETRIC_AVAILABLE
  {
    get => (bool) this[nameof (IS_BIOMETRIC_AVAILABLE)];
    set => this[nameof (IS_BIOMETRIC_AVAILABLE)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string USER_CRED
  {
    get => (string) this[nameof (USER_CRED)];
    set => this[nameof (USER_CRED)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool IS_BIOMETRIC_ENABLED_BY_USER
  {
    get => (bool) this[nameof (IS_BIOMETRIC_ENABLED_BY_USER)];
    set => this[nameof (IS_BIOMETRIC_ENABLED_BY_USER)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool NEED_TO_SHOW_FLOW
  {
    get => (bool) this[nameof (NEED_TO_SHOW_FLOW)];
    set => this[nameof (NEED_TO_SHOW_FLOW)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("False")]
  public bool IS_AUTO_UPDATE_ENABLED
  {
    get => (bool) this[nameof (IS_AUTO_UPDATE_ENABLED)];
    set => this[nameof (IS_AUTO_UPDATE_ENABLED)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  public bool FIRST_OPEN
  {
    get => (bool) this[nameof (FIRST_OPEN)];
    set => this[nameof (FIRST_OPEN)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string EMAIL
  {
    get => (string) this[nameof (EMAIL)];
    set => this[nameof (EMAIL)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("https://www.pdffiller.com")]
  public string BASE_URL
  {
    get => (string) this[nameof (BASE_URL)];
    set => this[nameof (BASE_URL)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string SKIP_VERSION
  {
    get => (string) this[nameof (SKIP_VERSION)];
    set => this[nameof (SKIP_VERSION)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("0")]
  public long LAST_SESSION
  {
    get => (long) this[nameof (LAST_SESSION)];
    set => this[nameof (LAST_SESSION)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string DEVICE_ID
  {
    get => (string) this[nameof (DEVICE_ID)];
    set => this[nameof (DEVICE_ID)] = (object) value;
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("")]
  public string VARIANT
  {
    get => (string) this[nameof (VARIANT)];
    set => this[nameof (VARIANT)] = (object) value;
  }
}
