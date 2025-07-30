// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.Main.MainViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.CSharp.RuntimeBinder;
using pdfFiller.Bus;
using pdfFiller.common;
using pdfFiller.di;
using pdfFiller.Dialogs;
using pdfFiller.Model.Pojo.Response;
using pdfFiller.ViewModel;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace pdfFiller.UI.Main;

public class MainViewModel : BaseViewModel, RouterObserver
{
  public static string KEY = nameof (MainViewModel);
  private bool skipDataLoaded;
  private MainControlContent _content;
  private MainControlContent _contentFull = MainControlContent.EMPTY;

  public MainControlContent Content
  {
    get => this._content;
    set
    {
      this._content = value;
      this.NotifyProperty(nameof (Content));
    }
  }

  public MainControlContent ContentFull
  {
    get => this._contentFull;
    set
    {
      this._contentFull = value;
      this.NotifyProperty(nameof (ContentFull));
    }
  }

  public MainViewModel()
  {
    DIManager.BusManager.CreateRouter(MainViewModel.KEY).RegisterObserver(MainViewModel.KEY, (RouterObserver) this);
    DIManager.BusManager.CreateFoldersBackStackHandler(MainViewModel.KEY);
  }

  public void ObserveData(object dataContainer)
  {
    // ISSUE: reference to a compiler-generated field
    if (MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, MainControlContent>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (MainControlContent), typeof (MainViewModel)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__0.Target((CallSite) MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__0, dataContainer) == MainControlContent.FIND_PDF)
    {
      // ISSUE: reference to a compiler-generated field
      if (MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, MainControlContent>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (MainControlContent), typeof (MainViewModel)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.ContentFull = MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__1.Target((CallSite) MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__1, dataContainer);
    }
    else
    {
      this.ContentFull = MainControlContent.EMPTY;
      // ISSUE: reference to a compiler-generated field
      if (MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, MainControlContent>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (MainControlContent), typeof (MainViewModel)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.Content = MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__2.Target((CallSite) MainViewModel.\u003C\u003Eo__11.\u003C\u003Ep__2, dataContainer);
    }
  }

  private void ClosingEventHandler() => this.LoadData();

  private async void OnPrivacyAccepted()
  {
    MainViewModel mainViewModel = this;
    DialogFactory.ShowLoader();
    try
    {
      if (await mainViewModel.dataManager.AcceptTos())
      {
        DialogFactory.DissmisLoader();
        LifecycleEventDispatcherControl.GetInstance().BackPress();
      }
      else
        DialogFactory.DissmisLoader();
    }
    catch (Exception ex)
    {
      mainViewModel.skipDataLoaded = false;
      DialogFactory.DissmisLoader();
      mainViewModel.HandleError(ex, new DialogFactory.ClosingEventHandler(mainViewModel.ClosingEventHandler));
    }
  }

  public async void LoadData()
  {
    MainViewModel mainViewModel = this;
    if (mainViewModel.skipDataLoaded)
      return;
    DialogFactory.ShowLoader();
    try
    {
      AgreementStatusResponse agreementStatusResponse = await mainViewModel.dataManager.checkPrivacyInfo();
      if (agreementStatusResponse.Data.ShouldSign)
      {
        DialogFactory.DissmisLoader();
        DialogFactory.ShowPrivacyDialog(agreementStatusResponse.Data.Message, new Action(mainViewModel.OnPrivacyAccepted));
        mainViewModel.skipDataLoaded = true;
      }
      else
        DialogFactory.DissmisLoader();
    }
    catch (Exception ex)
    {
      DialogFactory.DissmisLoader();
      mainViewModel.HandleError(ex, new DialogFactory.ClosingEventHandler(mainViewModel.ClosingEventHandler));
    }
  }
}
