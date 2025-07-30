// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Analytics.AnalyticsManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.storage;
using pdfFiller.Utils;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Analytics;

public class AnalyticsManager
{
  public const string BASE_URL = "https://www.google-analytics.com";
  private const string TRACKING_ID = "UA-1644202-29";
  private const string DATA_SOURCE = "dskt_win";
  private const string EVENT_CATEGORY = "desktop_app";
  public const string EVENT_INSTALL = "install";
  public const string EVENT_LOGIN = "login";
  public const string EVENT_SIGN_UP = "sign-up";
  public const string TYPE_GOOGLE = "google";
  public const string TYPE_FB = "facebook";
  public const string TYPE_API_V3 = "email";
  public const string SESSION_START = "start";
  public const string SESSION_END = "end";
  private AnalyticsRestInterface restInterface;
  private UserDataStorage userDataStorage;

  public AnalyticsManager(AnalyticsRestInterface restInterface, UserDataStorage userDataStorage)
  {
    this.restInterface = restInterface;
    this.userDataStorage = userDataStorage;
  }

  public void TrackPage(string page)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "pageview";
    staticParametrs["dp"] = (object) page;
    this.Track(staticParametrs);
  }

  public void TrackInstall()
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "event";
    staticParametrs["ec"] = (object) "desktop_app";
    staticParametrs["ea"] = (object) "install";
    staticParametrs["el"] = (object) DateTimeOffset.Now.ToString("yyyy.MM.dd");
    this.Track(staticParametrs);
  }

  public void TrackLoginSignUp(string action, string type)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "event";
    staticParametrs["ec"] = (object) "desktop_app";
    staticParametrs["ea"] = (object) action;
    staticParametrs["el"] = (object) type;
    this.Track(staticParametrs);
  }

  public void TrackEvent(string ev, string label = null)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "event";
    staticParametrs["ec"] = (object) "desktop_app";
    staticParametrs["ea"] = (object) ev;
    if (!this.userDataStorage.IsUserPaid() && label == null)
      label = "unpaid_user";
    staticParametrs["el"] = (object) label;
    this.Track(staticParametrs);
  }

  public void TrackSideMenuEvent(string ev)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "event";
    staticParametrs["ec"] = (object) "desktop_app";
    staticParametrs["ea"] = (object) "side_menu";
    staticParametrs["el"] = (object) ev;
    this.Track(staticParametrs);
  }

  public void TrackTraffic(string url)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["utm_sourse"] = (object) "desktop_app";
    staticParametrs["utm_medium"] = (object) "pf_win";
    staticParametrs["dr"] = (object) nameof (url);
    this.Track(staticParametrs);
  }

  public void TrackSession(string startEnd)
  {
    Dictionary<string, object> staticParametrs = this.GetStaticParametrs();
    staticParametrs["t"] = (object) "event";
    staticParametrs["ec"] = (object) "desktop_app";
    staticParametrs["sc"] = (object) startEnd;
    this.Track(staticParametrs);
  }

  private async void Track(Dictionary<string, object> body)
  {
    try
    {
      await this.restInterface.Track(body);
    }
    catch (Exception ex)
    {
    }
  }

  private Dictionary<string, object> GetStaticParametrs()
  {
    return new Dictionary<string, object>()
    {
      ["v"] = (object) 1,
      ["tid"] = (object) "UA-1644202-29",
      ["cid"] = (object) DeviceUtils.GetId(),
      ["dh"] = (object) "pdfFiller windows"
    };
  }
}
