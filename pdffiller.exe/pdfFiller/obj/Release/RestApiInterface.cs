// Decompiled with JetBrains decompiler
// Type: pdfFiller.data_manager.api.RestApiInterface
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json.Linq;
using pdfFiller.data_manager.model;
using pdfFiller.Model.Pojo.Data.User;
using pdfFiller.Model.Pojo.Response;
using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.data_manager.api;

[Headers(new string[] {"appKey: vWindowsApp_v1_2", "device: windows"})]
public interface RestApiInterface
{
  [Post("/api_v3/users/{loginOrSignUp}")]
  Task<LoginResponse> LoginOrSignUp([AliasAs("loginOrSignUp")] string loginOrSignUp, [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/users/social/{type}")]
  Task<LoginResponse> SocialLoginOrSignUp(string type, [Query("code")] string code, [Query("device_id")] string deviceId);

  [Post("/api_v3/users/forgotPassword")]
  Task<FillerResponse<object>> ForgotPassword([Query("email")] string email);

  [Get("/api_v3/users/info")]
  Task<pdfFiller.Model.Pojo.Data.User.User> GetUserInfo([Header("token")] string token, [Header("userId")] string userId);

  [Get("/api_v3/tos/getAgreementStatusWithMessage")]
  Task<AgreementStatusResponse> checkPrivacyInfo([Header("token")] string token, [Header("userId")] string userId);

  [Post("/api_v3/tos/acceptAgreement")]
  Task<TOSStatusResponse> AcceptTOS([Header("token")] string token, [Header("userId")] string userId);

  [Get("/api_v3/account/getSubscription")]
  Task<UserSubscription> GetSubscription([Header("token")] string token, [Header("userId")] string userId);

  [Post("/api_v3/folders/getStructure/{folderId}")]
  Task<FoldersStructureResponse> GetFoldersStructure(
    [Header("token")] string token,
    [Header("userId")] string userId,
    string folderId,
    CancellationToken cancelToken,
    [Body(BodySerializationMethod.UrlEncoded)] string showSharedSubfolders = "true");

  [Get("/api_v3/folders/getStructure/{folderId}")]
  Task<FoldersStructureResponse> GetFoldersStructure([Header("token")] string token, [Header("userId")] string userId, string folderId);

  [Get("/api_v3/projects/getStructure/{folderId}")]
  Task<ProjectsStructureResponse> GetProjectsStructure(
    [Header("token")] string token,
    [Header("userId")] string userId,
    string folderId,
    [Query("nameSort")] string nameSort,
    [Query("typeSort")] string typeSort,
    [Query("limit")] int? limit,
    [Query("tabId")] int? tabId,
    [Query("search")] string search,
    [Query("page")] int page,
    CancellationToken cancellationToken);

  [Get("/api_v3/search/run")]
  Task<ProjectsStructureResponse> SearchDocuments(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Query("query")] string query,
    [Query("page")] int page,
    CancellationToken cancellationToken,
    [Query("limit")] int limit = 100);

  [Get("/api_v3/projects/getStructure/{folderId}")]
  Task<ProjectsStructureResponse> GetRecents(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Query("nameSort")] string nameSort = null,
    [Query("typeSort")] string typeSort = null,
    [Query("limit")] int? limit = 5,
    [Query("tabId")] int? tabId = -101,
    [Query("dashboardTab")] int? dashboardTab = 0,
    string folderId = "-20");

  [Multipart("----MyGreatBoundary")]
  [Post("/api_v3/upload/multipart")]
  Task<UploadResponse> UploadFile([Header("token")] string token, [Header("userId")] string userId, [Query("folderId")] long folderId, [AliasAs("pdf")] StreamPart stream);

  [Get("/api_v3/app/getModule")]
  Task<JObject> GetModule([Header("token")] string token, [Header("userId")] string userId, [Query("module")] string module);

  [Get("/api_v3/app/locationByModule")]
  Task<JObject> GetModuleV2([Header("token")] string token, [Header("userId")] string userId, [Query("module")] string module);

  [Get("/api_v3/upload/link")]
  Task<JObject> AddProjectByLink([Header("token")] string token, [Header("userId")] string userId, [Query("folderId")] long folderId, [Query("url")] string url);

  [Get("/api_v3/projects/detailedInfo")]
  Task<FillerResponse<pdfFiller.Model.Pojo.Data.Project>> GetProjectById(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Query("projectId")] long projectId,
    [Query("folderId")] long folderId);

  [Get("/api_v3/projects/info/{projectId}")]
  Task<ProjectInfoResponse> GetProjectInfo([Header("token")] string token, [Header("userId")] string userId, long projectId);

  [Post("/api_v3/export/saveAs/{projectId}")]
  Task<FillerResponse<SaveAsResponse>> SaveAs(
    [Header("token")] string token,
    [Header("userId")] string userId,
    long projectId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/my_forms/delete")]
  Task<FillerResponse<object>> Delete([Header("token")] string token, [Header("userId")] string userId, [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/projects/deleteTrash")]
  Task<FillerResponse<object>> DeleteFromTash(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/folders/restore")]
  Task<FillerResponse<object>> RestoreFromTash(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/projects/addSuggestedFormsByIds")]
  Task<FillerResponse<object>> AddToMyForms(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Get("/api_v3/projects/getUniqFilename/{projectId}")]
  Task<UniqueFileNameResponse> GetUniqueName([Header("token")] string token, [Header("userId")] string userId, long projectId);

  [Post("/api_v3/projects/template/copy/{projectId}")]
  Task<CopyTemplateResponse> CopyTemplate(
    [Header("token")] string token,
    [Header("userId")] string userId,
    long projectId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/folders/rename/{folderId}")]
  Task<FillerResponse<object>> RenameFolder(
    [Header("token")] string token,
    [Header("userId")] string userId,
    long folderId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/projects/rename/{projectId}")]
  Task<FillerResponse<object>> RenameProject(
    [Header("token")] string token,
    [Header("userId")] string userId,
    long projectId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/projects/template/toggle")]
  Task<FillerResponse<object>> CreateTemplate(
    [Header("token")] string token,
    [Header("userId")] string userId,
    [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

  [Post("/api_v3/projects/permission/{action}/{projectId}")]
  Task<PermissionResponse> CheckPermission(
    [Header("token")] string token,
    [Header("userId")] string userId,
    string action,
    long projectId,
    [Query("systemId")] long systemId);

  [Get("/api_v3/projects/emptyTrash")]
  Task<object> EmptyTrash([Header("token")] string token, [Header("userId")] string userId);
}
