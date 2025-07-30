// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.User.UserSubscription
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Model.Pojo.Data.User;

public class UserSubscription
{
  public UserSubscription.Subcription subcription;
  public UserSubscription.Corporate corporate;

  public class Subcription
  {
    public string type;
    public string term;
    public string created;
    public string expires;
    public bool isPaid;
    public bool isTrial;
    public bool isTrialMobile;
    public bool isApplePay;
    public bool isGooglePay;
    public bool isSupport;
    public bool isPayPal;
    public bool canUpgrade;
    public bool canceled;
    public bool isAirslate;
    public int trialDaysRemaining;
    public int trialDaysRemainingMobile;
    public int trialDaysRemainigMobileNative;
    public bool isInvited;
    public int invitedUsers;
    public UserSubscription.Subcription.Mobile mobile;

    public class Mobile
    {
      public bool nativeTrial;
    }
  }

  public class Corporate
  {
    public bool isInvited;
    public bool invitedUsers;
  }
}
