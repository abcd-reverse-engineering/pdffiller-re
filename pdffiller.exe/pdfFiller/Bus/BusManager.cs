// Decompiled with JetBrains decompiler
// Type: pdfFiller.Bus.BusManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus.Refresh;
using pdfFiller.Model.Pojo.Data;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Bus;

public class BusManager
{
  private Dictionary<string, Router> _routers = new Dictionary<string, Router>();
  private Dictionary<string, RefreshDispatcher> _refreshDispatchers = new Dictionary<string, RefreshDispatcher>();
  private Dictionary<string, BackStackHandler<Folder>> _backstacksFolders = new Dictionary<string, BackStackHandler<Folder>>();
  private Dictionary<string, BackStackHandler<UserControl>> _backstacksControls = new Dictionary<string, BackStackHandler<UserControl>>();

  public Router CreateRouter(string key)
  {
    BusRouter router = new BusRouter();
    this._routers[key] = (Router) router;
    return (Router) router;
  }

  public Router GetRouter(string key)
  {
    try
    {
      return this._routers[key];
    }
    catch (Exception ex)
    {
      return (Router) null;
    }
  }

  public RefreshDispatcher CreateRefreshDispatcher(string key)
  {
    RefreshDispatcher refreshDispatcher = new RefreshDispatcher();
    this._refreshDispatchers[key] = refreshDispatcher;
    return refreshDispatcher;
  }

  public RefreshDispatcher GetRefreshDispatcherr(string key)
  {
    try
    {
      return this._refreshDispatchers[key];
    }
    catch (Exception ex)
    {
      return (RefreshDispatcher) null;
    }
  }

  public BackStackHandler<Folder> CreateFoldersBackStackHandler(string key)
  {
    BackStackHandler<Folder> backStackHandler = new BackStackHandler<Folder>();
    this._backstacksFolders[key] = backStackHandler;
    return backStackHandler;
  }

  public BackStackHandler<Folder> GetFoldersBackStackHandler(string key)
  {
    try
    {
      return this._backstacksFolders[key];
    }
    catch (Exception ex)
    {
      return (BackStackHandler<Folder>) null;
    }
  }

  public BackStackHandler<UserControl> CreateControlsBackStackHandler(string key)
  {
    BackStackHandler<UserControl> backStackHandler = new BackStackHandler<UserControl>();
    this._backstacksControls[key] = backStackHandler;
    return backStackHandler;
  }

  public BackStackHandler<UserControl> GetControlsBackStackHandler(string key)
  {
    try
    {
      return this._backstacksControls[key];
    }
    catch (Exception ex)
    {
      return (BackStackHandler<UserControl>) null;
    }
  }
}
