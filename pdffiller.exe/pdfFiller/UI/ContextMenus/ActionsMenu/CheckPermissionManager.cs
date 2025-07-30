// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.ActionsMenu.CheckPermissionManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Response;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.ContextMenus.ActionsMenu;

public class CheckPermissionManager
{
  public const string SAVE_AS_ACTION = "SAVE_AS";
  private DataProvider _dataProvider;

  public CheckPermissionManager() => this._dataProvider = DIManager.DataProvider;

  public Task<PermissionResponse> CheckPermission(string action, long projectId, long systemId)
  {
    return this._dataProvider.CheckPermission(action, projectId, systemId);
  }

  public Task<PermissionResponse> CheckPermission(string action, pdfFiller.Model.Pojo.Data.Project project)
  {
    return this.CheckPermission(action, project.projectId, project.systemId);
  }
}
