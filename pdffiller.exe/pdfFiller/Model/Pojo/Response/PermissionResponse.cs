// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Response.PermissionResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Pojo.Response;

public class PermissionResponse
{
  private const string ALLOWED = "ALLOWED";
  private const string DENIED = "DENIED";
  private const string LOCKED = "LOCKED";
  public bool result;
  public string permission;
  public string message;
  public string location;
  public string locationTitle;
  public ProjectInfoResponse.Project project;

  public bool IsFreeUser() => this.locationTitle == "Payment";

  public bool IsAllowed() => "ALLOWED" == this.permission;

  public bool IsLocked() => "LOCKED" == this.permission;
}
