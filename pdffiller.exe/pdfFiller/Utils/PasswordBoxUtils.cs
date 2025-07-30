// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.PasswordBoxUtils
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Utils;

public class PasswordBoxUtils
{
  public static void ProvideHint(PasswordBox field)
  {
    TextBlock name = (TextBlock) field.Template.FindName("placeholder", (FrameworkElement) field);
    if (field.SecurePassword.Length > 0)
      name.Visibility = Visibility.Collapsed;
    else
      name.Visibility = Visibility.Visible;
  }
}
