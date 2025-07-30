// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.WPFValidators.EmailWPFValidationRule
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Utils.WPFValidators;

public class EmailWPFValidationRule : ValidationRule
{
  private EmailAddressAttribute emailValidator = new EmailAddressAttribute();

  public override System.Windows.Controls.ValidationResult Validate(
    object value,
    CultureInfo cultureInfo)
  {
    string str = value as string;
    if (string.IsNullOrEmpty(str))
      return new System.Windows.Controls.ValidationResult(false, (object) ResourcesUtils.GetStringResource("empty_field_error_message"));
    return !this.emailValidator.IsValid((object) str) ? new System.Windows.Controls.ValidationResult(false, (object) ResourcesUtils.GetStringResource("email_validation_error_message")) : new System.Windows.Controls.ValidationResult(true, (object) null);
  }
}
