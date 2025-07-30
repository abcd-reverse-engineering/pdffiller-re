// Decompiled with JetBrains decompiler
// Type: pdfFiller.data_manager.model.LoginResponse
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.data_manager.model;

public class LoginResponse
{
  public bool isCorporate;
  public bool isPaid;
  public bool isGuest;
  public bool isFamilyMaster;
  public bool isTrial;
  public bool isWebTrial;
  public string userId;
  public string token;
  public string pdfEmail;
  public string email;
  public string phone;
}
