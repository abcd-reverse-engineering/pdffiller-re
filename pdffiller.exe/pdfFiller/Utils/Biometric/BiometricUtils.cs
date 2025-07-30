// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Biometric.BiometricUtils
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;

#nullable disable
namespace pdfFiller.Utils.Biometric;

public class BiometricUtils
{
  internal static async Task<KeyValuePair<bool, string>> CheckFingerprintAvailability()
  {
    bool returnValue = false;
    string str;
    try
    {
      switch ((int) await UserConsentVerifier.CheckAvailabilityAsync())
      {
        case 0:
          str = ResourcesUtils.GetStringResource("biometric_result_availavle");
          returnValue = true;
          break;
        case 1:
          str = ResourcesUtils.GetStringResource("biometric_result_no_device");
          break;
        case 2:
          str = ResourcesUtils.GetStringResource("biometric_result_not_configured");
          break;
        case 3:
          str = ResourcesUtils.GetStringResource("biometric_result_disabled_by_policy");
          break;
        case 4:
          str = ResourcesUtils.GetStringResource("biometric_result_busy");
          break;
        default:
          str = ResourcesUtils.GetStringResource("biometric_result_unavailavle");
          break;
      }
    }
    catch (Exception ex)
    {
      str = $"{ResourcesUtils.GetStringResource("biometric_result_check_exception")} {ex.Message}";
    }
    return new KeyValuePair<bool, string>(returnValue, str);
  }

  internal static async Task<KeyValuePair<bool, string>> RequestConsent(string userMessage = null)
  {
    bool returnValue = false;
    if (string.IsNullOrEmpty(userMessage))
      userMessage = ResourcesUtils.GetStringResource("biometric_request_default_message");
    string str;
    try
    {
      switch ((int) await UserConsentVerifier.RequestVerificationAsync(userMessage))
      {
        case 0:
          str = ResourcesUtils.GetStringResource("biometric_result_verified");
          returnValue = true;
          break;
        case 1:
          str = ResourcesUtils.GetStringResource("biometric_result_no_device");
          break;
        case 2:
          str = ResourcesUtils.GetStringResource("biometric_result_not_configured");
          break;
        case 3:
          str = ResourcesUtils.GetStringResource("biometric_result_disabled_by_policy");
          break;
        case 4:
          str = ResourcesUtils.GetStringResource("biometric_result_busy");
          break;
        case 5:
          str = ResourcesUtils.GetStringResource("biometric_result_too_many_attempts");
          break;
        case 6:
          str = ResourcesUtils.GetStringResource("biometric_result_canceled");
          break;
        default:
          str = ResourcesUtils.GetStringResource("biometric_result_unavailavle");
          returnValue = false;
          break;
      }
    }
    catch (Exception ex)
    {
      str = $"{ResourcesUtils.GetStringResource("biometric_result_request_exception")} {ex.Message}";
    }
    return new KeyValuePair<bool, string>(returnValue, str);
  }
}
