// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Amplitude.AmplitudeManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Response;
using pdfFiller.storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

#nullable disable
namespace pdfFiller.Model.Amplitude;

public class AmplitudeManager
{
  public const string BASE_URL = "https://api.amplitude.com";
  private AmplitudeRestInterface restInterface;
  private DateTimeOffset currentDateOffset = DateTimeOffset.FromUnixTimeMilliseconds(0L);
  private DateTimeOffset inactiveDateOffset = DateTimeOffset.FromUnixTimeMilliseconds(0L);
  private List<AmplitudeEvent> Events = new List<AmplitudeEvent>();
  private string deviceId;
  private string userId;
  private bool sync;
  private UserDataStorage UserDataStorage = new UserDataStorage();
  private string osVersion;
  private string country;
  private Subject<string> subject = new Subject<string>();

  private IObservable<T> Debounce<T>(IObservable<T> source, TimeSpan delay)
  {
    return source.Do<T>((Action<T>) (x => this.TimestampedPrint((object) "----!!!!!! EVENT SOURCE"))).Select<T, IObservable<T>>((Func<T, IObservable<T>>) (x => Observable.Return<T>(x).Delay<T>(delay))).Switch<T>();
  }

  private void TimestampedPrint(object o) => Console.WriteLine($"{DateTime.Now:HH.mm.ss.fff}: {o}");

  public AmplitudeManager(AmplitudeRestInterface restInterface)
  {
    this.restInterface = restInterface;
    this.currentDateOffset = DateTimeOffset.FromUnixTimeMilliseconds(pdfFiller.Properties.Settings.Default.LAST_SESSION);
    this.inactiveDateOffset = DateTimeOffset.FromUnixTimeMilliseconds(pdfFiller.Properties.Settings.Default.LAST_SESSION);
    this.deviceId = pdfFiller.Properties.Settings.Default.DEVICE_ID;
    this.osVersion = Environment.OSVersion.Version.ToString();
    this.country = RegionInfo.CurrentRegion.EnglishName;
    string userId = this.UserDataStorage.GetUserId();
    this.userId = !(userId == "") ? userId : (string) null;
    this.Debounce<string>((IObservable<string>) this.subject, TimeSpan.FromSeconds(4.0)).ObserveOn<string>(SynchronizationContext.Current).Subscribe<string>((Action<string>) (x => this.SendEvents(x)));
    this.BecomeActive();
  }

  public void BecomeActive()
  {
    DateTimeOffset utcNow = DateTimeOffset.UtcNow;
    if (Math.Abs((utcNow - this.inactiveDateOffset).TotalMinutes) <= 5.0)
      return;
    if (this.currentDateOffset != DateTimeOffset.FromUnixTimeMilliseconds(0L))
      this.Events.Add(this.ConfigureEvent("session_end", new Dictionary<string, object>(), new Dictionary<string, object>()));
    this.inactiveDateOffset = utcNow;
    this.currentDateOffset = utcNow;
    pdfFiller.Properties.Settings.Default.LAST_SESSION = utcNow.ToUnixTimeMilliseconds();
    pdfFiller.Properties.Settings.Default.Save();
    this.Events.Add(this.ConfigureEvent("session_start", new Dictionary<string, object>(), new Dictionary<string, object>()));
    this.subject.OnNext("!!!!!!---- EVENT SENT: session_start");
  }

  public void BecomeInactive()
  {
    this.inactiveDateOffset = DateTimeOffset.UtcNow;
    this.InstantSendEvents("!!!!!!---- EVENT SENT: become inactive");
  }

  public void deleteUserId()
  {
    this.userId = (string) null;
    this.GenerateNewDevice();
  }

  public void Configure(string userId)
  {
    if (this.currentDateOffset != DateTimeOffset.FromUnixTimeMilliseconds(0L))
      this.Events.Add(this.ConfigureEvent("session_end", new Dictionary<string, object>(), new Dictionary<string, object>()));
    this.userId = userId;
    DateTimeOffset utcNow = DateTimeOffset.UtcNow;
    this.currentDateOffset = utcNow;
    pdfFiller.Properties.Settings.Default.LAST_SESSION = utcNow.ToUnixTimeMilliseconds();
    pdfFiller.Properties.Settings.Default.Save();
    this.Events.Add(this.ConfigureEvent("session_start", new Dictionary<string, object>(), new Dictionary<string, object>()));
    this.subject.OnNext("!!!!!!---- EVENT SENT: session_start");
  }

  public void configureUserProperties(Dictionary<string, object> userProperties)
  {
    this.Events.Add(this.ConfigureEvent("$identify", new Dictionary<string, object>(), userProperties));
    this.subject.OnNext("!!!!!!---- EVENT SENT: session_start");
  }

  public void AddEvent(string name) => this.AddEvent(name, new Dictionary<string, object>());

  public void AddEvent(string name, Dictionary<string, object> eventProperties)
  {
    this.Events.Add(this.ConfigureEvent(name, eventProperties, new Dictionary<string, object>()));
    this.subject.OnNext("!!!!!!---- EVENT SENT: " + name);
  }

  private void GenerateNewDevice()
  {
    string str = Guid.NewGuid().ToString();
    this.deviceId = str;
    pdfFiller.Properties.Settings.Default.DEVICE_ID = str;
    pdfFiller.Properties.Settings.Default.Save();
  }

  private AmplitudeEvent ConfigureEvent(
    string name,
    Dictionary<string, object> eventProperties,
    Dictionary<string, object> userProperties)
  {
    if (this.deviceId == null || this.deviceId == "")
      this.GenerateNewDevice();
    return new AmplitudeEvent()
    {
      UserId = this.userId,
      DeviceId = this.deviceId,
      EventType = name,
      SessionId = this.currentDateOffset.ToUnixTimeMilliseconds(),
      EventProperties = eventProperties,
      UserProperties = userProperties,
      Language = "English",
      Time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
      AppVersion = "1.3.130",
      Platform = "Windows",
      OsName = "windows",
      OsVersion = this.osVersion,
      Country = this.country
    };
  }

  private void SendEvents(string triggerEvent) => this.InstantSendEvents(triggerEvent);

  private async void InstantSendEvents(string triggerEvent)
  {
    this.TimestampedPrint((object) triggerEvent);
    AmplitudeEvent[] eventsPack;
    if (this.sync)
      eventsPack = (AmplitudeEvent[]) null;
    else if (this.Events.Count == 0)
    {
      eventsPack = (AmplitudeEvent[]) null;
    }
    else
    {
      this.sync = true;
      eventsPack = this.Events.Take<AmplitudeEvent>(10).ToArray<AmplitudeEvent>();
      Dictionary<string, object> body = new Dictionary<string, object>()
      {
        {
          "api_key",
          (object) "8bdb33563ac16711682cef91eea59256"
        },
        {
          "events",
          (object) eventsPack
        }
      };
      try
      {
        AmplitudeResponse amplitudeResponse = await this.restInterface.SendEvents(body);
        Console.WriteLine(amplitudeResponse.code.ToString());
        this.sync = false;
        if (amplitudeResponse.code != 200)
        {
          eventsPack = (AmplitudeEvent[]) null;
        }
        else
        {
          foreach (AmplitudeEvent amplitudeEvent in eventsPack)
            this.Events.Remove(amplitudeEvent);
          this.subject.OnNext("!!!!!!---- EVENT SENT: NEXT CHUNK");
          eventsPack = (AmplitudeEvent[]) null;
        }
      }
      catch (Exception ex)
      {
        this.sync = false;
        Console.WriteLine(ex.ToString());
        eventsPack = (AmplitudeEvent[]) null;
      }
    }
  }
}
