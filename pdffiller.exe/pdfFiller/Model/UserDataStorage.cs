// Decompiled with JetBrains decompiler
// Type: pdfFiller.storage.UserDataStorage
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using pdfFiller.Model.Pojo.Data.Structure.Actions;
using pdfFiller.Model.Pojo.Data.User;
using pdfFiller.Properties;
using pdfFiller.UI.ContextMenus.SortMenu;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.storage;

public class UserDataStorage
{
  private const string LOGIN_RESPONSE_KEY = "LOGIN_RESPONSE";
  private const string USER_INFO_KEY = "USER_INFO";
  private const string SUBSCRIPTION_KEY = "SUBSCRIPTION";
  private const string SORTING = "SORTING";
  public const string PROJECTS_MASK = "PROJECTS_MASK";
  public const string FOLDERS_MASK = "FOLDERS_MASK";
  private const string USER_ID_KEY = "USER_ID_KEY";
  private const string TOKEN_KEY = "TOKEN_KEY";
  private Settings _storage;

  public string GetToken()
  {
    return this.GetLoginResponse() == null ? (string) null : this.GetLoginResponse()["TOKEN_KEY"];
  }

  public string GetUserId()
  {
    return this.GetLoginResponse() == null ? (string) null : this.GetLoginResponse()["USER_ID_KEY"];
  }

  public UserDataStorage() => this._storage = Settings.Default;

  public void StoreLoginEmail(string email)
  {
    this._storage.EMAIL = email;
    this._storage.Save();
  }

  public string GetLoginEmail() => this._storage.EMAIL;

  public void SaveLoginResponse(string userId, string token)
  {
    this._storage["LOGIN_RESPONSE"] = (object) JsonConvert.SerializeObject((object) new Dictionary<string, string>()
    {
      ["USER_ID_KEY"] = userId,
      ["TOKEN_KEY"] = token
    });
    this._storage.Save();
  }

  public void Logout()
  {
    this._storage["LOGIN_RESPONSE"] = (object) null;
    this._storage.EMAIL = (string) null;
    this._storage.Save();
  }

  public Dictionary<string, string> GetLoginResponse()
  {
    return this._storage["LOGIN_RESPONSE"] == null ? (Dictionary<string, string>) null : JsonConvert.DeserializeObject<Dictionary<string, string>>((string) this._storage["LOGIN_RESPONSE"]);
  }

  public void SaveUserInfo(pdfFiller.Model.Pojo.Data.User.User user)
  {
    this._storage["USER_INFO"] = (object) JsonConvert.SerializeObject((object) user);
    this._storage.Save();
  }

  public pdfFiller.Model.Pojo.Data.User.User GetUserInfo()
  {
    return JsonConvert.DeserializeObject<pdfFiller.Model.Pojo.Data.User.User>((string) this._storage["USER_INFO"]);
  }

  public bool IsUserPaid()
  {
    pdfFiller.Model.Pojo.Data.User.User userInfo = this.GetUserInfo();
    return userInfo.isPaid || userInfo.isTrialMobile;
  }

  public void SaveSubcription(UserSubscription subscription)
  {
    this._storage["SUBSCRIPTION"] = (object) JsonConvert.SerializeObject((object) subscription);
    this._storage.Save();
  }

  public UserSubscription GetSubscription()
  {
    return JsonConvert.DeserializeObject<UserSubscription>((string) this._storage["SUBSCRIPTION"]);
  }

  public void SaveSortOrder(SortMenuItem sortOrder, long folderId)
  {
    Dictionary<string, Dictionary<long, SortMenuItem>> dictionary = this._storage["SORTING"] == null || this._storage["SORTING"] as string == "" ? new Dictionary<string, Dictionary<long, SortMenuItem>>() : JsonConvert.DeserializeObject<Dictionary<string, Dictionary<long, SortMenuItem>>>(this._storage["SORTING"] as string);
    try
    {
      dictionary[this.GetUserId()][folderId] = sortOrder;
    }
    catch (KeyNotFoundException ex)
    {
      dictionary[this.GetUserId()] = new Dictionary<long, SortMenuItem>();
      dictionary[this.GetUserId()][folderId] = sortOrder;
    }
    this._storage["SORTING"] = (object) JsonConvert.SerializeObject((object) dictionary);
    this._storage.Save();
  }

  public SortMenuItem GetSortOrder(long folderId)
  {
    if (this._storage["SORTING"] != null)
    {
      if (!(this._storage["SORTING"] as string == ""))
      {
        try
        {
          return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<long, SortMenuItem>>>(this._storage["SORTING"] as string)[this.GetUserId()][folderId];
        }
        catch (Exception ex)
        {
          return (SortMenuItem) null;
        }
      }
    }
    return (SortMenuItem) null;
  }

  public string GetFillerEmail() => this.GetUserInfo().internalEmail;

  public string GetUserEmail() => this.GetUserInfo().email;

  public string GetUserFullName()
  {
    pdfFiller.Model.Pojo.Data.User.User userInfo = this.GetUserInfo();
    return $"{userInfo.firstName} {userInfo.lastName}";
  }

  internal string GetUserImageUrl() => this.GetUserInfo().avatar;

  public void SaveProjectsMask(ActionsConstants mask)
  {
    this._storage["PROJECTS_MASK"] = (object) mask.ToString();
    this._storage.Save();
  }

  public void SaveFoldersMask(ActionsConstants mask)
  {
    this._storage["FOLDERS_MASK"] = (object) mask.ToString();
    this._storage.Save();
  }
}
