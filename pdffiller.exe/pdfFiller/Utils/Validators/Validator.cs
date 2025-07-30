// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Validators.Base.Validator
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Exceptions;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Utils.Validators.Base;

public class Validator : IValidator
{
  private List<IValidationRule> rules;

  public Validator(List<IValidationRule> rules) => this.rules = rules;

  public void validate(string text)
  {
    IValidationRule validationRule = (IValidationRule) null;
    foreach (IValidationRule rule in this.rules)
    {
      if (!rule.checkRule(text))
      {
        validationRule = rule;
        break;
      }
    }
    if (validationRule != null)
      throw new ValidationException(validationRule.getMessage());
  }
}
