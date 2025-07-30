// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Api.EditorConnectorImpl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.Model.Pojo.Data;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace pdfFiller.Model.Api;

internal sealed class EditorConnectorImpl : EditorConnector
{
  private DataProvider _dataHelper;
  private Project _project;

  public EditorConnectorImpl(DataProvider dataHelper, Project project)
  {
    this._dataHelper = dataHelper;
    this._project = project;
  }

  public void BuildConfigs(ConfigsCallback<EditorConfigs> configsCallback)
  {
    StringBuilder stringBuilder = new StringBuilder().Append(ApiConstants.BASE_URL).Append("/api_v3/editor/editorProjectUrl?projectId={projectId}".Replace("{projectId}", this._project.projectId.ToString())).Append("&doneSingle=true").Append("&viewerId=" + this._dataHelper.GetUserId().ToString()).Append("&token=" + this._dataHelper.GetToken().ToString()).Append("&isWebView=true");
    if (this._project.IsSignatureRequest)
    {
      string str = this._project.systemId.ToString();
      if (this._project.IsNewS2S)
        str = "flow_" + str;
      stringBuilder.Append("&s2s=" + str);
    }
    configsCallback.OnConfigsReady(new EditorConfigs(stringBuilder.ToString(), new Dictionary<string, object>()
    {
      {
        "token",
        (object) this._dataHelper.GetToken()
      },
      {
        "userId",
        (object) this._dataHelper.GetUserId()
      },
      {
        "device",
        (object) "windows"
      },
      {
        "appKey",
        (object) "vWindowsApp_v1_2"
      },
      {
        "Cache-Control",
        (object) "no-cache"
      },
      {
        "isWebView",
        (object) "true"
      }
    }, this._project.Name));
  }
}
