// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.DeviceUtils
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using DeviceId;
using System;

#nullable disable
namespace pdfFiller.Utils;

public class DeviceUtils
{
  private static string deviceId;

  public static string GetId()
  {
    if (DeviceUtils.deviceId == null)
      DeviceUtils.deviceId = new DeviceIdBuilder().AddMachineName().OnWindows((Action<WindowsDeviceIdBuilder>) (windows => windows.AddProcessorId())).ToString();
    return DeviceUtils.deviceId;
  }
}
