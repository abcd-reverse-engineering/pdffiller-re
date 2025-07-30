// Decompiled with JetBrains decompiler
// Type: pdfFiller.Dialogs.GoToMyDocs.GoToMyDocsDialogViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.Dialogs.YesNo;
using pdfFiller.Utils;

#nullable disable
namespace pdfFiller.Dialogs.GoToMyDocs;

public class GoToMyDocsDialogViewModel : YesNoDialogViewModel
{
  protected override string GetMessage() => ResourcesUtils.GetStringResource("editor_exit_message");

  protected override string GetNoButtonText()
  {
    return ResourcesUtils.GetStringResource("editor_no_button");
  }

  protected override string GetTitle() => ResourcesUtils.GetStringResource("editor_exit_title");

  protected override string GetYesButtonText()
  {
    return ResourcesUtils.GetStringResource("editor_yes_button");
  }

  protected override void OnConfirmCommand() => DialogFactory.HideDialog();

  protected override void OnCancelCommand()
  {
    DialogFactory.HideDialog();
    LifecycleEventDispatcherControl.GetInstance().BackPress();
  }
}
