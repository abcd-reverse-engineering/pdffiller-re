// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Amplitude.AmplitudeEvent
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Amplitude;

internal class AmplitudeEvent
{
  [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
  public string UserId { get; set; }

  [JsonProperty("device_id")]
  public string DeviceId { get; set; }

  [JsonProperty("event_type")]
  public string EventType { get; set; }

  [JsonProperty("session_id")]
  public long SessionId { get; set; }

  [JsonProperty("user_properties")]
  public Dictionary<string, object> UserProperties { get; set; } = new Dictionary<string, object>();

  [JsonProperty("event_properties")]
  public Dictionary<string, object> EventProperties { get; set; } = new Dictionary<string, object>();

  [JsonProperty("language")]
  public string Language { get; set; }

  [JsonProperty("time")]
  public long Time { get; set; }

  [JsonProperty("app_version")]
  public string AppVersion { get; set; }

  [JsonProperty("platform")]
  public string Platform { get; set; }

  [JsonProperty("os_name")]
  public string OsName { get; set; }

  [JsonProperty("os_version")]
  public string OsVersion { get; set; }

  [JsonProperty("country")]
  public string Country { get; set; }
}
