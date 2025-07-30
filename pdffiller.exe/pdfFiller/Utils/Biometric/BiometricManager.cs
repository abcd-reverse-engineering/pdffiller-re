// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Biometric.BiometricManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using pdfFiller.Properties;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.Utils.Biometric;

public class BiometricManager
{
  private const string IS_BIOMETRIC_AVAILABLE_KEY = "IS_BIOMETRIC_AVAILABLE";
  private const string USER_CRED_KEY = "USER_CRED";
  private const string EMAIL_KEY = "EMAIL_KEY";
  private const string PASS_KEY = "PASS_KEY";
  private Settings settings;

  public BiometricManager() => this.settings = Settings.Default;

  public async Task<bool> CheckBiometricAvailability()
  {
    KeyValuePair<bool, string> keyValuePair = await BiometricUtils.CheckFingerprintAvailability();
    this.settings.IS_BIOMETRIC_AVAILABLE = keyValuePair.Key;
    this.settings.Save();
    return keyValuePair.Key;
  }

  public Task<KeyValuePair<bool, string>> RequestConsent() => BiometricUtils.RequestConsent();

  public void DissableBiometricAvailability()
  {
    this.settings.IS_BIOMETRIC_AVAILABLE = false;
    this.settings.Save();
  }

  public void SaveUserCredentials(string email, string password)
  {
    this.settings.USER_CRED = JsonConvert.SerializeObject((object) new Dictionary<string, string>()
    {
      ["EMAIL_KEY"] = EncryptionHelper.Encrypt(email, DeviceUtils.GetId()),
      ["PASS_KEY"] = EncryptionHelper.Encrypt(password, DeviceUtils.GetId())
    });
    this.settings.Save();
  }

  public void SetBiometricFlag(bool value)
  {
    this.settings.IS_BIOMETRIC_ENABLED_BY_USER = value;
    this.settings.Save();
  }

  public bool GetBiometricFlag() => this.settings.IS_BIOMETRIC_ENABLED_BY_USER;

  public string GetEmail()
  {
    return EncryptionHelper.Decrypt(JsonConvert.DeserializeObject<Dictionary<string, string>>(this.settings.USER_CRED)["EMAIL_KEY"], DeviceUtils.GetId());
  }

  public string GetPass()
  {
    return EncryptionHelper.Decrypt(JsonConvert.DeserializeObject<Dictionary<string, string>>(this.settings.USER_CRED)["PASS_KEY"], DeviceUtils.GetId());
  }

  public bool IsBiometricAvailabile() => this.settings.IS_BIOMETRIC_AVAILABLE;

  public void Logout()
  {
    this.settings.IS_BIOMETRIC_ENABLED_BY_USER = false;
    this.settings.Save();
  }

  public void SetShowFlag(bool value)
  {
    this.settings.NEED_TO_SHOW_FLOW = value;
    this.settings.Save();
  }

  public bool NeedShowFlow() => this.settings.NEED_TO_SHOW_FLOW;
}
