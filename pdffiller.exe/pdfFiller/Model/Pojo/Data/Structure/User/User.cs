// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.User.User
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Pojo.Data.User;

public class User
{
  public string id;
  public string firstName;
  public string lastName;
  public string avatar;
  public string email;
  public string internalEmail;
  public string inboundFax;
  public bool isPaid;
  public bool isTrial;
  public bool isTrialMobile;
  public pdfFiller.Model.Pojo.Data.User.User.Mobile mobile;

  public class Mobile
  {
    public bool nativeTrial;
  }
}
