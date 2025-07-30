// Decompiled with JetBrains decompiler
// Type: pdfFiller.api.DataProvider
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.data_manager.api;
using pdfFiller.data_manager.model;
using pdfFiller.di;
using pdfFiller.Model.Api;
using pdfFiller.Model.Mapper.Delete;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.Model.Pojo.Data.User;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.Properties;
using pdfFiller.storage;
using pdfFiller.UI.ContextMenus.SortMenu;
using pdfFiller.Utils;
using pdfFiller.Utils.Biometric;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.api;

public class DataProvider
{
  private RestApiInterface _apiInterface;
  private UserDataStorage _storage;
  private BiometricManager _biometricManager;

  public DataProvider(RestApiInterface apiInterface, UserDataStorage storage)
  {
    this._apiInterface = apiInterface;
    this._storage = storage;
    this._biometricManager = new BiometricManager();
  }

  public string GetToken() => this._storage.GetToken();

  public string GetUserId() => this._storage.GetUserId();

  public string GetFillerEmail() => this._storage.GetFillerEmail();

  public string GetUserEmail() => this._storage.GetUserEmail();

  public string GetUserImageUrl() => this._storage.GetUserImageUrl();

  public string GetUserFullName() => this._storage.GetUserFullName();

  public string GetLoginEmail() => this._storage.GetLoginEmail();

  public Task<PermissionResponse> CheckPermission(string action, long projectId, long systemId)
  {
    return this._apiInterface.CheckPermission(this.GetToken(), this.GetUserId(), action, projectId, systemId);
  }

  public async Task<pdfFiller.Model.Pojo.Data.Project> GetProjectById(long projectId, long folderId)
  {
    return (await this._apiInterface.GetProjectById(this.GetToken(), this.GetUserId(), projectId, folderId)).data;
  }

  public Task AddToMyForms(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (Task) this._apiInterface.AddToMyForms(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["ids[]"] = (object) project.projectId
    });
  }

  public Task CreateTemplate(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (Task) this._apiInterface.CreateTemplate(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["ids[0][projectId]"] = (object) project.projectId,
      ["ids[0][serviceId]"] = (object) project.projectId,
      ["folderId]"] = (object) project.folderId
    });
  }

  public void StoreEmail(string email) => this._storage.StoreLoginEmail(email);

  public async Task<string> GetUniqueName(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (await this._apiInterface.GetUniqueName(this.GetToken(), this.GetUserId(), project.projectId)).fileName;
  }

  public async Task<EditorConnector> CopyTemplate(pdfFiller.Model.Pojo.Data.Project project, string name)
  {
    return await this.GetEditorConnector((await this._apiInterface.CopyTemplate(this.GetToken(), this.GetUserId(), project.projectId, new Dictionary<string, object>()
    {
      [nameof (name)] = (object) name
    })).projectId);
  }

  public Task<EditorConnector> GetEditorConnector(pdfFiller.Model.Pojo.Data.Project project)
  {
    if (project.IsSharedWithMe)
      return Task.FromResult<EditorConnector>((EditorConnector) new EditorConnectorImpl(this, project));
    return project.IsSignatureRequest ? Task.FromResult<EditorConnector>((EditorConnector) new EditorConnectorImpl(this, project)) : this.GetEditorConnector(project.projectId);
  }

  public async Task<EditorConnector> GetEditorConnector(long projectId)
  {
    DataProvider dataHelper = this;
    ProjectInfoResponse projectInfo = await dataHelper._apiInterface.GetProjectInfo(dataHelper.GetToken(), dataHelper.GetUserId(), projectId);
    FillerResponse<pdfFiller.Model.Pojo.Data.Project> projectById = await dataHelper._apiInterface.GetProjectById(dataHelper.GetToken(), dataHelper.GetUserId(), long.Parse(projectInfo.project.id), long.Parse(projectInfo.project.folderid));
    return (EditorConnector) new EditorConnectorImpl(dataHelper, projectById.data);
  }

  public Task<bool> Login(string email, string password)
  {
    return this.LoginOrRegistr("login", email, password);
  }

  public Task<bool> Registr(string email, string password)
  {
    return this.LoginOrRegistr("add", email, password);
  }

  private async Task<bool> LoginOrRegistr(string path, string email, string password)
  {
    LoginResponse response = await this._apiInterface.LoginOrSignUp(path, new Dictionary<string, object>()
    {
      {
        nameof (email),
        (object) email
      },
      {
        nameof (password),
        (object) password
      },
      {
        "device_id",
        (object) DeviceUtils.GetId()
      },
      {
        "mobile_native_trial",
        (object) "true"
      }
    });
    pdfFiller.Model.Pojo.Data.User.User user = await this._apiInterface.GetUserInfo(response.token, response.userId);
    UserSubscription subscription = await this._apiInterface.GetSubscription(response.token, response.userId);
    if (await this._biometricManager.CheckBiometricAvailability())
      this._biometricManager.SaveUserCredentials(email, password);
    DIManager.AmplitudeManager.Configure(response.userId);
    DIManager.AmplitudeManager.configureUserProperties(new Dictionary<string, object>()
    {
      {
        "Localisation",
        (object) "en"
      },
      {
        "Biometric",
        Settings.Default.IS_BIOMETRIC_ENABLED_BY_USER ? (object) "on" : (object) "off"
      }
    });
    this._storage.SaveLoginResponse(response.userId, response.token);
    this._storage.SaveUserInfo(user);
    this._storage.SaveSubcription(subscription);
    string action;
    string name;
    if (path == "login")
    {
      action = "login";
      name = "User Logged In";
    }
    else
    {
      action = "sign-up";
      name = "User Registered";
    }
    DIManager.AnalyticsManager.TrackLoginSignUp(action, nameof (email));
    Dictionary<string, object> eventProperties = new Dictionary<string, object>()
    {
      {
        "auth_type",
        (object) "Email"
      }
    };
    DIManager.AmplitudeManager.AddEvent(name, eventProperties);
    bool flag = true;
    response = (LoginResponse) null;
    user = (pdfFiller.Model.Pojo.Data.User.User) null;
    subscription = (UserSubscription) null;
    return flag;
  }

  public async Task<bool> SocialAuth(string userId, string token)
  {
    this._biometricManager.DissableBiometricAvailability();
    pdfFiller.Model.Pojo.Data.User.User user = await this._apiInterface.GetUserInfo(token, userId);
    UserSubscription subscription = await this._apiInterface.GetSubscription(token, userId);
    this._storage.SaveLoginResponse(userId, token);
    this._storage.SaveUserInfo(user);
    this._storage.SaveSubcription(subscription);
    bool flag = true;
    user = (pdfFiller.Model.Pojo.Data.User.User) null;
    return flag;
  }

  public async Task<BiometricState> TryLoginViaBiometric()
  {
    if (!this.GetBiometricFlag() || !this._biometricManager.NeedShowFlow())
      return new BiometricState(1);
    this._biometricManager.SetShowFlag(false);
    KeyValuePair<bool, string> keyValuePair = await this._biometricManager.RequestConsent();
    if (!keyValuePair.Key)
      return new BiometricState(3, keyValuePair.Value);
    int num = await this.LoginOrRegistr("login", this._biometricManager.GetEmail(), this._biometricManager.GetPass()) ? 1 : 0;
    return new BiometricState(2);
  }

  public async Task<string> ForgotPassword(string email)
  {
    return (await this._apiInterface.ForgotPassword(email)).message;
  }

  public async Task<Dictionary<int, FoldersStructure>> GetStructure()
  {
    DataProvider dataProvider = this;
    // ISSUE: reference to a compiler-generated method
    return await dataProvider._apiInterface.GetFoldersStructure(dataProvider.GetToken(), dataProvider.GetUserId(), (string) null).ContinueWith<Dictionary<int, FoldersStructure>>(new Func<Task<FoldersStructureResponse>, Dictionary<int, FoldersStructure>>(dataProvider.\u003CGetStructure\u003Eb__26_0));
  }

  public async Task<ProjectsStructure> GetProjects(
    long folderId,
    int? boxId,
    int page,
    CancellationToken cancellationToken)
  {
    DataProvider dataProvider = this;
    SortMenuItem sortOrderForFolder = SortMenuItemsManager.GetSortOrderForFolder(dataProvider, folderId);
    ProjectsStructureResponse projectsStructure = await dataProvider._apiInterface.GetProjectsStructure(dataProvider.GetToken(), dataProvider.GetUserId(), folderId.ToString(), sortOrderForFolder.SortName, sortOrderForFolder.SortType, new int?(100), boxId, (string) null, page, cancellationToken);
    dataProvider._storage.SaveProjectsMask(projectsStructure.mask);
    return new ProjectsStructure(projectsStructure.rows, projectsStructure.page, projectsStructure.pagesCount, projectsStructure.mask, projectsStructure.countProjects);
  }

  public Task<FoldersStructureResponse> GetFoldersStructure(long id, CancellationToken token)
  {
    return this._apiInterface.GetFoldersStructure(this.GetToken(), this.GetUserId(), id.ToString(), token);
  }

  public async Task<FoldersStructure> GetTrashBinStructure()
  {
    Folder folderByName = (await this._apiInterface.GetFoldersStructure(this.GetToken(), this.GetUserId(), (string) null)).getFolderByName("trash");
    return new FoldersStructure(new List<object>((IEnumerable<object>) folderByName.subFolders.Values.ToList<Folder>()), folderByName);
  }

  public async Task<ProjectsStructure> SearchDocuments(
    string query,
    CancellationToken cancellationToken,
    int page = 1)
  {
    ProjectsStructureResponse structureResponse = await this._apiInterface.SearchDocuments(this.GetToken(), this.GetUserId(), query, page, cancellationToken);
    return new ProjectsStructure(structureResponse.rows, structureResponse.page, structureResponse.pagesCount, structureResponse.mask, structureResponse.countProjects);
  }

  public async Task<List<pdfFiller.Model.Pojo.Data.Project>> GetRecents()
  {
    DataProvider dataProvider = this;
    SortMenuItem sortOrderForFolder = SortMenuItemsManager.GetSortOrderForFolder(dataProvider, -20L);
    return (await dataProvider._apiInterface.GetRecents(dataProvider.GetToken(), dataProvider.GetUserId(), sortOrderForFolder.SortName, sortOrderForFolder.SortType)).rows;
  }

  public void SaveSortOrder(long folderId, SortMenuItem sortOrder)
  {
    this._storage.SaveSortOrder(sortOrder, folderId);
  }

  public SortMenuItem GetSortOrder(long folderId) => this._storage.GetSortOrder(folderId);

  public Task CheckToken()
  {
    return (Task) this._apiInterface.GetUserInfo(this.GetToken(), this.GetUserId());
  }

  public async Task<AgreementStatusResponse> checkPrivacyInfo()
  {
    return await this._apiInterface.checkPrivacyInfo(this.GetToken(), this.GetUserId());
  }

  public async Task<bool> AcceptTos()
  {
    return string.Equals((await this._apiInterface.AcceptTOS(this.GetToken(), this.GetUserId())).Data.Meta.Status, "Accepted", StringComparison.OrdinalIgnoreCase);
  }

  public async Task<List<UploadResponse>> UploadFiles(IEnumerable<string> files)
  {
    List<UploadResponse> responses = new List<UploadResponse>();
    foreach (string file in files)
    {
      FileStream fileStream = System.IO.File.OpenRead(file);
      string fileName = Uri.EscapeDataString(Path.GetFileName(file));
      responses.Add(await this._apiInterface.UploadFile(this.GetToken(), this.GetUserId(), 0L, new StreamPart((Stream) fileStream, fileName, FileUtils.GetMimeType(file))));
    }
    List<UploadResponse> uploadResponseList = responses;
    responses = (List<UploadResponse>) null;
    return uploadResponseList;
  }

  public async Task<string> GetModule(string type)
  {
    return (await this._apiInterface.GetModule(this.GetToken(), this.GetUserId(), type))["location"].ToString();
  }

  public async Task<string> GetModuleV2(string type)
  {
    return (await this._apiInterface.GetModuleV2(this.GetToken(), this.GetUserId(), type))["location"].ToString();
  }

  public async Task<long> AddProjectByLink(string url)
  {
    return long.Parse((await this._apiInterface.AddProjectByLink(this.GetToken(), this.GetUserId(), -20L, url))["id"].ToString());
  }

  public Task<ProjectInfoResponse> GetProjectInfo(long projectId)
  {
    return this._apiInterface.GetProjectInfo(this.GetToken(), this.GetUserId(), projectId);
  }

  public void Logout()
  {
    this._storage.Logout();
    this._biometricManager.Logout();
    DIManager.AmplitudeManager.AddEvent("User Logged Out");
    DIManager.AmplitudeManager.deleteUserId();
  }

  public async Task<SaveAsResponse> SaveAs(long projectId, string type)
  {
    return (await this._apiInterface.SaveAs(this.GetToken(), this.GetUserId(), projectId, new Dictionary<string, object>()
    {
      [nameof (type)] = (object) type
    })).data;
  }

  public Task DownloadFile(string url, string path)
  {
    return new WebClient().DownloadFileTaskAsync(url, path);
  }

  public async Task<bool> DeleteProject(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (await this._apiInterface.Delete(this.GetToken(), this.GetUserId(), DeleteBodyBuildersFactory.GetBuilderByFolderId(project).Build(project))).result;
  }

  public async Task<bool> DeleteProjectFromTrash(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (await this._apiInterface.DeleteFromTash(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["projectsIds[]"] = (object) project.projectId
    })).result;
  }

  public async Task<bool> RestoreProjectFromTrash(pdfFiller.Model.Pojo.Data.Project project)
  {
    return (await this._apiInterface.RestoreFromTash(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["projectsIds[]"] = (object) project.projectId
    })).result;
  }

  public async Task<bool> RestoreFolderFromTrash(Folder folder)
  {
    return (await this._apiInterface.RestoreFromTash(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["foldersIds[]"] = (object) folder.id
    })).result;
  }

  public async Task<bool> DeleteFolder(Folder folder)
  {
    FolderDeleteMapper folderDeleteMapper = new FolderDeleteMapper();
    if (folder.IsShared)
      folderDeleteMapper = (FolderDeleteMapper) new ShareFolderDeleteMapper();
    return (await this._apiInterface.Delete(this.GetToken(), this.GetUserId(), folderDeleteMapper.Build(folder))).result;
  }

  public async Task<bool> RenameFolder(Folder folder, string name)
  {
    return (await this._apiInterface.RenameFolder(this.GetToken(), this.GetUserId(), folder.id, new Dictionary<string, object>()
    {
      [nameof (name)] = (object) name
    })).result;
  }

  public async Task<bool> RenameProject(pdfFiller.Model.Pojo.Data.Project project, string name)
  {
    return (await this._apiInterface.RenameProject(this.GetToken(), this.GetUserId(), project.projectId, new Dictionary<string, object>()
    {
      [nameof (name)] = (object) name
    })).result;
  }

  public async Task<bool> DeleteFolderFromTashBin(Folder folder)
  {
    return (await this._apiInterface.DeleteFromTash(this.GetToken(), this.GetUserId(), new Dictionary<string, object>()
    {
      ["foldersIds[]"] = (object) folder.id
    })).result;
  }

  public Task<object> EmptyTrash()
  {
    return this._apiInterface.EmptyTrash(this.GetToken(), this.GetUserId());
  }

  public bool IsBiometricAvailabile() => this._biometricManager.IsBiometricAvailabile();

  public void SaveBiometricFlag(bool value)
  {
    this._biometricManager.SetBiometricFlag(value);
    DIManager.AmplitudeManager.AddEvent("Biometric Used", new Dictionary<string, object>()
    {
      {
        "switcher",
        value ? (object) "on" : (object) "off"
      }
    });
    DIManager.AmplitudeManager.configureUserProperties(new Dictionary<string, object>()
    {
      {
        "Localisation",
        (object) "en"
      },
      {
        "Biometric",
        value ? (object) "on" : (object) "off"
      }
    });
  }

  public bool GetBiometricFlag() => this._biometricManager.GetBiometricFlag();

  public void DisposeBiometricFlowFlag() => this._biometricManager.SetShowFlag(true);

  public void EraseToken() => this._storage.SaveLoginResponse("", "");
}
