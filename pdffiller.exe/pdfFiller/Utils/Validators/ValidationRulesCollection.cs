// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Validators.ValidationRulesCollection
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Utils.Validators;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ValidationRulesCollection
{
  public class EmptyFieldValidationRule : IValidationRule
  {
    public bool checkRule(string text) => !string.IsNullOrEmpty(text);

    public string getMessage() => ResourcesUtils.GetStringResource("empty_field_error_message");
  }

  public class EmailFieldValidationRule : IValidationRule
  {
    public bool checkRule(string text)
    {
      return !string.IsNullOrEmpty(text) && new EmailAddressAttribute().IsValid((object) text);
    }

    public string getMessage()
    {
      return ResourcesUtils.GetStringResource("email_validation_error_message");
    }
  }

  public class PasswordFieldValidationRule : IValidationRule
  {
    private string message;
    private int passLength;

    public PasswordFieldValidationRule(int passLength) => this.passLength = passLength;

    public bool checkRule(string text)
    {
      if (string.IsNullOrEmpty(text) || text.Length < this.passLength)
      {
        this.message = ResourcesUtils.GetStringResource("password_validation_error_message");
        return false;
      }
      if (!text.Contains(" "))
        return true;
      this.message = ResourcesUtils.GetStringResource("password_validation_space_error_message");
      return false;
    }

    public string getMessage() => this.message;
  }
}
