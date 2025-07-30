// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.AppStartUI.SignUp.SignUpControl
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace pdfFiller.UI.AppStartUI.SignUp;

public partial class SignUpControl : UserControl, IComponentConnector
{
  internal TextBox Email;
  internal PasswordBox Password;
  internal Button Register;
  internal Button Terms_of_Service;
  internal Button Privacy_Policy;
  internal Button Facebook;
  internal Button GetStarted;
  private bool _contentLoaded;

  public SignUpControl() => this.InitializeComponent();

  private void Password_PasswordChanged(object sender, RoutedEventArgs e)
  {
    PasswordBoxUtils.ProvideHint(sender as PasswordBox);
  }

  private void Loader_Loaded(object sender, RoutedEventArgs e)
  {
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/pdfFiller;component/ui/appstartui/signup/signupcontrol.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.Email = (TextBox) target;
        break;
      case 2:
        this.Password = (PasswordBox) target;
        this.Password.PasswordChanged += new RoutedEventHandler(this.Password_PasswordChanged);
        break;
      case 3:
        this.Register = (Button) target;
        break;
      case 4:
        this.Terms_of_Service = (Button) target;
        break;
      case 5:
        this.Privacy_Policy = (Button) target;
        break;
      case 6:
        this.Facebook = (Button) target;
        break;
      case 7:
        this.GetStarted = (Button) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
