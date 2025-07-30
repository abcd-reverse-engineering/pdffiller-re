// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Onboarding.OnboardingItem
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.UI.Onboarding;

public class OnboardingItem
{
  public static List<OnboardingItem> GetOnboardingList()
  {
    return new List<OnboardingItem>()
    {
      new OnboardingItem("/pdfFiller;component/Resources/Images/Onboarding/onboarding_1.png", ResourcesUtils.GetStringResource("onboarding_title_1"), ResourcesUtils.GetStringResource("onboarding_message_1")),
      new OnboardingItem("/pdfFiller;component/Resources/Images/Onboarding/onboarding_2.png", ResourcesUtils.GetStringResource("onboarding_title_2"), ResourcesUtils.GetStringResource("onboarding_message_2")),
      new OnboardingItem("/pdfFiller;component/Resources/Images/Onboarding/onboarding_3.png", ResourcesUtils.GetStringResource("onboarding_title_3"), ResourcesUtils.GetStringResource("onboarding_message_3"))
    };
  }

  public string Image { get; set; }

  public string Title { get; set; }

  public string Message { get; set; }

  public OnboardingItem(string image, string title, string message)
  {
    this.Image = image;
    this.Title = title;
    this.Message = message;
  }
}
