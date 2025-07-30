// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Onboarding.OnboardingViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Commnands;
using pdfFiller.common;
using pdfFiller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace pdfFiller.UI.Onboarding;

public class OnboardingViewModel : BaseViewModel
{
  private List<OnboardingItem> items;
  private int currentOnboardingIndex;
  private string currentOnboardingImage;
  private string currentOnboardingTitle;
  private string currentOnboardingMessage;

  public SimpleCommand NextCommand { get; }

  public SimpleCommand SkipCommand { get; }

  public OnboardingViewModel()
  {
    this.NextCommand = new SimpleCommand(new Action(this.OnNextButtonClicked));
    this.SkipCommand = new SimpleCommand(new Action(this.OnSkipButtonClicked));
    this.items = OnboardingItem.GetOnboardingList();
    this.CurrentOnboardingIndex = 0;
    this.SetCurrentOnboardingItem();
  }

  public int OnboardingItemsSize => this.items.Count;

  public int CurrentOnboardingIndex
  {
    get => this.currentOnboardingIndex;
    set
    {
      this.currentOnboardingIndex = value;
      this.NotifyProperty(nameof (CurrentOnboardingIndex));
    }
  }

  public string CurrentOnboardingImage
  {
    get => this.currentOnboardingImage;
    set
    {
      this.currentOnboardingImage = value;
      this.NotifyProperty(nameof (CurrentOnboardingImage));
    }
  }

  public string CurrentOnboardingTitle
  {
    get => this.currentOnboardingTitle;
    set
    {
      this.currentOnboardingTitle = value;
      this.NotifyProperty(nameof (CurrentOnboardingTitle));
    }
  }

  public string CurrentOnboardingMessage
  {
    get => this.currentOnboardingMessage;
    set
    {
      this.currentOnboardingMessage = value;
      this.NotifyProperty(nameof (CurrentOnboardingMessage));
    }
  }

  private void OnNextButtonClicked()
  {
    ++this.CurrentOnboardingIndex;
    this.SetCurrentOnboardingItem();
  }

  private void OnSkipButtonClicked() => LifecycleEventDispatcherControl.GetInstance().BackPress();

  private void SetCurrentOnboardingItem()
  {
    if (this.CurrentOnboardingIndex == this.OnboardingItemsSize)
    {
      this.OnSkipButtonClicked();
    }
    else
    {
      OnboardingItem onboardingItem = this.items.ElementAt<OnboardingItem>(this.CurrentOnboardingIndex);
      this.CurrentOnboardingImage = onboardingItem.Image;
      this.CurrentOnboardingTitle = onboardingItem.Title;
      this.CurrentOnboardingMessage = onboardingItem.Message;
    }
  }
}
